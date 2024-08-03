using Application.Interfaces;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;

namespace EXE_02.Controllers
{
    public class PayOSController : BaseController
    {
        private readonly PayOS _payOS;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        public PayOSController(PayOS payOS, IOrderDetailService orderDetailService, IOrderService orderService, IProductService productService)
        {
            _payOS = payOS;
            _orderDetailService = orderDetailService;
            _orderService = orderService;
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> Checkout([FromQuery] int orderId)
        {
            try
            {
                int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
                var total = 0.0;
                List<ItemData> items = new List<ItemData>();
                var order = await _orderDetailService.GetOrderDetailByOrderId(orderId);
                var orders = await _orderService.GetOrderByIdAsync(orderId);
                foreach (var o in order.Data)
                {
                    int productId = (int)o.ProductId;

                    var product = await _productService.GetProductByIdAsync(productId);

                    string itemName = product.Data.Name;

                    int quantity = (int)o.Quantity;

                    int price = (int)o.Price;

                    ItemData item = new(itemName, quantity, price);
                    items.Add(item);
                }

                var successUrl = $"http://localhost:3000/paymentsuccess?orderId={orderId}";
                var cancelUrl = $"http://localhost:3000/paymentfailed";

                // Tạo đối tượng PaymentData để gửi yêu cầu thanh toán
                PaymentData paymentData = new PaymentData(orderCode, (int)orders.Data.TotalPrice, "Thanh toán đơn hàng", items, cancelUrl, successUrl);
                CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

                return Ok(new
                {
                    message = "redirect",
                    url = createPayment.checkoutUrl
                });
            }
            catch (System.Exception exception)
            {
                Console.WriteLine(exception);
                return Redirect("https://localhost:5001/swagger/index.html");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ChangeStatusOfPayment(int orderId)
        {
            var result = _orderService.ChangeStatusOfPaymentAsync(orderId);
            return Ok(result);

        }

    }
}
