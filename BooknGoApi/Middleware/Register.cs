namespace BooknGoApi.Middleware
{
    public class Register
    {
        private readonly RequestDelegate _next;

        private readonly string[] _blockedEndpoints = new[]
        {
        "/register", // <-- This is the endpoint that we want to block
        "/refresh",
        "/confirmEmail",
        "/resendConfirmationEmail",
        "/forgotPassword",
        "/resetPassword",
        "/manage/2fa",
        "/manage/info"
    };

        public Register(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (_blockedEndpoints.Contains(context.Request.Path.Value.ToLower()))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Access to this endpoint is blocked.");
                return;
            }

            await _next(context);
        }
    }
}
