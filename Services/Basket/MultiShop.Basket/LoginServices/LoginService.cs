namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public LoginService(IHttpContextAccessor httpcontextAccessor)
        {
            _httpcontextAccessor = httpcontextAccessor;
        }

        public string GetUsreId => _httpcontextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
