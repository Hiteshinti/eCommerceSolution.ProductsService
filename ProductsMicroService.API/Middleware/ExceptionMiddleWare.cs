using Microsoft.AspNetCore.Http;

namespace ProductsMicroService.API.Middleware
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _context;
        public ExceptionMiddleWare(RequestDelegate context)
        {
            _context = context;
        }
        
        public async Task InvokeAsync(HttpContext request)
        {
            try
            {
                await _context(request);
            }
            catch (Exception ex)
            {
                await request.Response.WriteAsJsonAsync(ex.Message);
            }
        }
    }
}
