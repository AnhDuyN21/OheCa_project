using Application;

namespace WebAPI.Middlewares
{
    public class ConfirmationTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public ConfirmationTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Tạo một phạm vi dịch vụ tạm thời
            using (var scope = context.RequestServices.CreateScope())
            {
                // Lấy IUnitOfWork từ phạm vi dịch vụ tạm thời
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var token = context.Request.Query["token"];

                if (!string.IsNullOrEmpty(token))
                {
                    var user = await unitOfWork.UserRepository.GetUserByConfirmationToken(token);

                    if (user != null)
                    {
                        // Xác nhận tài khoản
                        
                        user.ConfirmToken = null;
                        user.IsConfirmed = true;
                        await unitOfWork.SaveChangeAsync();

                        await context.Response.WriteAsync("Email has been confirmed successfully!");
                        return;
                    }
                }
            }

            await _next(context);
        }
    }
}