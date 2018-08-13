using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collection.DSL;
using Collection.DAL;

namespace InvoiceSystem.Controllers
{
    public class UserController : Controller
    {
        UserDSL iuser = new UserDSL();
        // GET: User
        public ActionResult Index()
        {
            return View(iuser.GetUsers());
        }

        [HttpGet]
        public ActionResult Add(int id=0)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(User u)
        {
            if (u != null)
            {
                if (iuser.InsertUser(u) == true)
                    iuser.Commit();
                else
                {
                    ViewBag.DuplicateMessage = "username already exists";
                    return View(u);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            if (id > 0)
            {
                iuser.DeleteUser(id);
                iuser.Commit();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(iuser.GetUserByID(id));
        }

        [HttpPost]
        public ActionResult Edit(User u)
        {
            if (u != null)
            {
                if (iuser.UpdateUser(u) == true)
                    iuser.Commit();
                else
                {
                    ViewBag.DuplicateMessage = "username already exists";
                    return View(u);
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User objUser)
        {
            int id = iuser.userlogin(objUser);
            if (id > 0)
            {
                Session["UserID"] = id;
                Session["UserName"] = objUser.UserName;
                return RedirectToAction("Index");
            }

            ViewBag.DuplicateMessage = "Invalid username or password";
            return View(objUser);
        }

    }
}