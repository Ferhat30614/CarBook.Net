using CarBook.Dto.LoginDtos;
using CarBook.Dto.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using CarBook.WebUI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;

namespace CarBook.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(createLoginDto),Encoding.UTF8,"application/json");
            var response = await client.PostAsync("https://localhost:7192/api/Login",content);

            if (response.IsSuccessStatusCode)
            {
                var dataJson=await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(dataJson,new JsonSerializerOptions
                {
                    PropertyNamingPolicy=JsonNamingPolicy.CamelCase,//JSON'daki alan isimlerinin camelCase formatında olmasını sağlar.
                });

                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler= new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims=token.Claims.ToList();             // burda token değişkenindeki  claimleri listeleyip aldık     list<claim>  

                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("accesToken",tokenModel.Token));  // burda claims nesneme  yeni bir claim ekledim   . (type(veya claim ismi)=accesToken ,value=tokenModel.Token olan)
                        var claimsIdentity=new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme); // JwtBearerDefaults.AuthenticationScheme değeri, JWT (JSON Web Token) kimlik doğrulama şemasını belirtir.

                        var authProps = new AuthenticationProperties//Token'ın geçerlilik süresi ve oturumun kalıcı olup olmayacağı burada ayarlanır.
                        {
                            ExpiresUtc=tokenModel.ExpireDate,
                            IsPersistent=true,  
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProps);//HttpContext.SignInAsync(): Bu metot, kullanıcının kimlik doğrulamasını yapmak ve oturum açmak için kullanılır.

                        // NOT
                        // Identity sistemi, birçok işlemi arka planda otomatik olarak halleder.
                        // Bu nedenle, HttpContext'i doğrudan kullanmıyorsun çünkü Identity bu işlemler
                        // i otomatik olarak halleder ve HTTP context ile tüm kimlik doğrulama ve oturum bilgilerini yönetir.

                        // yani burada http contextin olması ve identytyde bunların olmamasının sebebbi bukadar basit

                        return RedirectToAction("Index","Default");
                    }
                }
            }            
            return View();
        }
    }
}
