using Lena.Business.Abstract;
using Lena.DataAccess.Concrete.EntityFramework;
using Lena.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Lena.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly IFormService _formService;
        private readonly IFormFieldService _formFieldService;
        private readonly UserManager<User> _userManager;
        private readonly LenaContext _context;
        public FormsController(IFormService formService, LenaContext context, IFormFieldService formFieldService, UserManager<User> userManager)
        {
            _formService = formService;
            _context = context;
            _formFieldService = formFieldService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var forms = await _context.Forms
                .Include(u => u.FormFields)//.Where(x => x.CreatedBy == user.Id)
                .ToListAsync();
            return Ok(forms);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var forms = await _context.Forms
                .Include(u => u.FormFields).FirstOrDefaultAsync(x => x.Id == id);
            return Ok(forms);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Form form)
        {
            _formService.Add(form);
            var formId = form.Id;
            foreach (var item in form.FormFields)
            {
                item.Form = form.Id;
                item.FormId = form.Id;
                _formFieldService.Add(item);
            }
            return Ok(form);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var form = _formService.Get(id);
            _formService.Delete(form);
            return Ok();
        }
    }
}
