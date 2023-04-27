using Lena.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Lena.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Lena.UI.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        HttpClient _client;
        HttpResponseMessage _response;
        private readonly ILogger<FormController> _logger;
        private readonly UserManager<User> _userManager;

        public FormController(ILogger<FormController> logger, UserManager<User> userManager)
        {
            _client = new HttpClient();
            _logger = logger;
            _userManager = userManager;
        }
        private async Task<string> GetApiResponseAsync(string apiUrl)
        {
            _response = await _client.GetAsync("https://localhost:7092/api/" + apiUrl);
            return await _response.Content.ReadAsStringAsync();
        }

        private async Task<string> PostApiResponseAsync(string apiUrl, object payload)
        {
            var jsonObject = JsonConvert.SerializeObject(payload);
            var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            _response = await _client.PostAsync("https://localhost:7092/api/" + apiUrl, stringContent);
            return await _response.Content.ReadAsStringAsync();
        }

        private async Task<T> PostApiResponseAsync<T>(string apiUrl, object payload)
        {
            var jsonObject = JsonConvert.SerializeObject(payload);
            var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            _response = await _client.PostAsync("https://api.zbilet.com/api/" + apiUrl, stringContent);
            var jsonString = await _response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        public async Task<IActionResult> Forms(int id)
        {
            return View();
        }
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }                                       
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> GetForms()
        {
            var forms = await GetApiResponseAsync("Forms");
            return Json(forms);
        } 
        public async Task<IActionResult> GetFormsById(int id)
        {
            var form = await GetApiResponseAsync("Forms/" + id);
            return Json(form);
        }
        [HttpPost]
        public async Task<IActionResult> CreateForm([FromBody]Form form)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            form.CreatedBy = user.Id;
            form.CreatedAt = DateTime.Now;
            var result = await PostApiResponseAsync("Forms", form);
            if(_response.IsSuccessStatusCode)
                return Json(result);
            return BadRequest();
        }


    }
}