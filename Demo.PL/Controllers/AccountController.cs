using Demo.DAL.Model;
using Demo.PL.Helper;
using Demo.PL.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppAuth> userManager;
        private readonly SignInManager<AppAuth> signInManager;

        public AccountController(UserManager<AppAuth> userManager , SignInManager<AppAuth> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM obj)
        {
            if (ModelState.IsValid)
            {
                var user = new AppAuth
                {
                    FName = obj.FName,
                    LName = obj.LName,
                    UserName = obj.UserName,
                    Email = obj.Email,
                };

                var result =await userManager.CreateAsync(user,obj.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }
            } 
            return View(obj);
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM obj)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(obj.Email);
                if(user is not null)
                {
                    var flag =await userManager.CheckPasswordAsync(user, obj.Password);

                    if (flag)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, obj.Password,obj.Rememberme ,false);
                        if(result.Succeeded)
                        {
                            return RedirectToAction("Index", "Department");
                        }
                    }
                    ModelState.AddModelError(string.Empty, "Password is not Existed");
                }
                ModelState.AddModelError(string.Empty, "Email is not Existed");
            }
            return View();
        }

        public async Task<IActionResult> Signout()
        {
             await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(ForgetPasswordVM model)
        {
            if(!ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if(user is not null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordRestlink = Url.Action("ResetPassword", "Account", new { email = user.Email , token = token }, "https", "localhost:7227");
                    var email = new Email
                    {
                        Subject = "Rest Password",
                        To = user.Email,
                        Body = "passwordRestlink",

                    };
                    EmailSetting.SendEmail(email);
                    return RedirectToAction(nameof(CheckYourInbox));
                }
                ModelState.AddModelError(string.Empty, "Email Is Not Exsist");
            }
            return View(model);
        }

        public IActionResult CheckYourInbox()
        {
            return View();
        }




    }
}
