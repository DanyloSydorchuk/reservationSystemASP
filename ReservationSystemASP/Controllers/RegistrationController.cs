using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationSystemASP.Models;
using Microsoft.AspNetCore.Identity;

namespace ReservationSystemASP.Controllers
{
    public class RegistrationController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        public RegistrationController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName, Email=model.Email, PhoneNumber=model.PhoneNumber};
                var res = await _userManager.CreateAsync(user, model.PasswordHash);

                if (res.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index","home");

                }
                foreach(var error in res.Errors)
                {
                    ModelState.AddModelError(" ", error.Description);
                }
            }
            return View(model);
        }
    }
}
