using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task_app.Controllers
{
    public class AccountController : Controller
    {
        // ハードコードされたユーザー情報（例）
        private const string ValidUsername = "testuser";
        private const string ValidPassword = "password";

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == ValidUsername && password == ValidPassword)
            {
                // ログインが成功した場合、セッション情報を設定する
                HttpContext.Session.Add("username", username);
                return View("TaskView");
            }

            // ログインが失敗した場合、エラーメッセージを表示する
            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            // セッションをクリアする
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Home");
        }
    }
}

