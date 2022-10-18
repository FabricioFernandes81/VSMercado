using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using WebAdmin.Models;
using WebAdmin.Services;

namespace WebAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ILocalidadeService _localidadeService;

        public AccountController(IAccountService accountService, ILocalidadeService localidadeService)
        {
            _accountService = accountService;
            _localidadeService = localidadeService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Registro");
        }

        [HttpGet]
        public async Task<IActionResult> Registro() 
        {
  
        ViewData["estadoId"] = new SelectList(await _localidadeService.GetEstados(), "Id", "uf");
            
           

            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Registro(RegistroView registroView) 
        {
            var result = await _accountService.Registro(registroView);

            if (result.Success) 
            {
                return RedirectToAction("index", "Home");
            }
            else 
            {
                /// TempData["msg"] = "<script>alertaLogin('error','" + result.Message + "');</script>";
              ModelState.AddModelError("CustomError", result.Message);
            }

            return View(registroView);
        }
        
        public async Task<IActionResult> getCidades(int uf)
        {
           var estadosVM =  await _localidadeService.GetEstados();
            var data = estadosVM.Where(s => s.Id == uf)
                .Select(a=>a.City).ToList();
          
            return Json(data);

        }
    }
}

