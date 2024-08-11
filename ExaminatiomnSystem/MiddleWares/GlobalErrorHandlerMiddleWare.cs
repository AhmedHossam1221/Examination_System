namespace ExaminatiomnSystem.MiddleWares
{
    public class GlobalErrorHandlerMiddleWare
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlerMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public Task InvokeAsync (HttpContext context)
        {
            return _next(context);
        }
    }
}
