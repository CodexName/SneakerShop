using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SeakerSop.AttributeValidation;
using SeakerSop.Models;
using SeakerSop.Repository;
using System.Data.Common;

namespace SeakerSop.Controllers
{
    public class AccountController : Controller, IDisposable
    {
        private readonly IRepository Repository;
        private readonly DbContextApplication _Context;
        private readonly IQueryable<User> UsersCollection;
        public const string SessionKeyId = "IdUserKey";
        public AccountController (DbContextApplication context)
        {
            _Context = context;
            Repository = new RealizationRepository(_Context);
            UsersCollection = Repository.ReadDataUser();
            
        }

        [HttpGet]
        public IActionResult RegistrationView() => View("/Views/RegistrationLogin/RegistrationView.cshtml");

        [HttpPost]
        public IActionResult Registration (User usersdataregistration)
        {
            if (usersdataregistration != null)
            {
                foreach (var item in UsersCollection.Select(p => p.Password))
                {
                    if (item == usersdataregistration.Password )
                    {
                        ModelState.AddModelError("Password", ErrorMessage.PasswordDBError);
                        return View("/Views/RegistrationLogin/SuccsesfulRegistration.cshtml");
                    }
                }
                if (ModelState.IsValid)
                {
                    Repository.AddData(usersdataregistration);
                    return View("/Views/RegistrationLogin/SuccsesfulRegistration.cshtml");
                }
            }
            return View("/Views/RegistrationLogin/RegistrationView.cshtml");
        }
        [HttpGet]
        public IActionResult LoginView() => View("/Views/RegistrationLogin/LoginView.cshtml");
        [HttpPost]
        public IActionResult Login (LoginUserNotMap userdatalogin)
        {
            if (userdatalogin != null)
            {
                var usercollection = UsersCollection.ToList();
                foreach (var itemlogin in usercollection )
                {
                    if (userdatalogin.PasswordLogin == itemlogin.Password && userdatalogin.GmailLogin == itemlogin.Gmail)
                    {
                  
                        if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyId)))
                        {
                            var UserTempData = UsersCollection.FirstOrDefault(x => x.Password == userdatalogin.PasswordLogin);
                            int id = UserTempData.Id;
                            HttpContext.Session.SetInt32(SessionKeyId, id);
                            return View("/Views/RegistrationLogin/SuccsesfulLogin.cshtml");
                        }
                    }
                    if (userdatalogin.PasswordLogin != itemlogin.Password)
                    {
                        ModelState.AddModelError("PasswordLogin", ErrorMessage.PasswordlLoginError);
                        return View("/Views/RegistrationLogin/LoginView.cshtml");
                    }
                    if (userdatalogin.GmailLogin != itemlogin.Gmail)
                    {
                        ModelState.AddModelError("GmailLogin", ErrorMessage.GmailLoginError);
                        return View("/Views/RegistrationLogin/LoginView.cshtml");
                    }
                }     
            }
            return View("/Views/RegistrationLogin/LoginView.cshtml");
        }
    } 
}
