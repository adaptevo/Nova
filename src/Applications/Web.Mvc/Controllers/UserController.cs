using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Nova.Core.Services.Persistence;
using Nova.Core.Services.Context;
using Nova.Core;
using Nova.Core.Domain;
using Nova.Applications.Web.Mvc.Model;

namespace Nova.Applications.Web.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IQueryHandler<AuthenticateUserQuery, User> _authenticateUser;
        private readonly IQueryHandler<CreateUserQuery, User> _registerUser;

        public UserController(IQueryHandler<AuthenticateUserQuery, User> authenticateuser,
            IQueryHandler<CreateUserQuery, User> registerUser)
        {
            _authenticateUser = authenticateuser;
            _registerUser = registerUser;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Authenticate(string username, string password)
        {
            var user =_authenticateUser.Handle(new AuthenticateUserQuery() { Username = username, Password = password });

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return RedirectToAction("Index", "Question");
            }

            return View("Login");
        }

        public ActionResult Register(string username, string password)
        {
            return View();
        }

        public ActionResult Create(UserModel userModel)
        {
            var user = _registerUser.Handle(new CreateUserQuery() { username = userModel.Username, password = userModel.Password, email=userModel.Email, name = userModel.Name });

            if (user != null)
            {
                return Authenticate(user.Username, user.Password);
            }

            return View();
        }

    }
}
