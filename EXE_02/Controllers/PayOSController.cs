using Application.Interfaces;
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
        private const decimal USD = 25000m;
        public PayOSController(PayOS payOS, IOrderDetailService orderDetailService, IOrderService orderService)
        {
            _payOS = payOS;
            _orderDetailService = orderDetailService;
            _orderService = orderService;

        }
        [HttpPost]
        public async Task<IActionResult> Checkout([FromQuery] int userId, [FromQuery] int orderId, [FromQuery] int paymentId)
        {
            try
            {
                int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
                var total = 0.0;
                List<ItemData> items = new List<ItemData>();
                var order = await _orderDetailService.GetOrderDetailByIdAsync(orderId);
                var orders = await _orderService.GetOrderByIdAsync(orderId);

                //string itemName = order.Data

                //ItemData item = new ItemData(o.Cart.Product != null ? o.Cart.Product.Name : o.Cart.Diamond.Name, (int)o.Cart.Quantity, (int)(o.Cart.TotalPrice * USD));
                //items.Add(item);

                //var baseUrl = "https://diamond-shopp.azurewebsites.net//api/" + "PayOs/Success";

                //var successUrl = $"{baseUrl}?userId={userId}&orderId={orderId}&paymentId={paymentId}";
                //var cancelUrl = "https://deploy-swp-391.vercel.app/payment/success";
                //PaymentData paymentData = new PaymentData(orderCode, (int)(orders.TotalPrice * USD), "Pay Order", items, cancelUrl, successUrl);
                //CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

                return Ok(new
                {
                    message = "redirect",
                    //url = createPayment.checkoutUrl
                });
            }
            catch (System.Exception exception)
            {
                Console.WriteLine(exception);
                return Redirect("https://deploy-swp-391.vercel.app/payment/cancel");
            }
        }
    }
}
