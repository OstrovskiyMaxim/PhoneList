﻿using PhoneList.Models.ViewModels;
using PhoneList.Repository;
using PhoneList.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneList.Controllers
{
    public class MainController : BaseController
    {
        Services.UserService service = new Services.UserService();
        int UserId = 0;
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(int userId)
        {
            this.UserId = userId;
            return RedirectToAction("AddressBook");

        }

        public ActionResult AddressBook()
        {
            return View(service.GetAllPersons(User.Id));
        }

        // GET: Main/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Main/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Main/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreatePerson()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CreatePerson(PersonViewModel person)
        {
            person.UserId = User.Id;
            service.CreatePerson(person);
            return RedirectToAction("Index");
        }
        // GET: Main/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Main/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Main/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult Upload()
        {
            string fileName = "";
            foreach (string file in Request.Files)
            {
                var upload = Request.Files[file];
                if (upload != null)
                {

                    // получаем имя файла
                    fileName = System.IO.Path.GetFileName(upload.FileName);
                    // сохраняем файл в папку Files в проекте
                    upload.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                }
            }
            return Json(fileName);
        }

        [HttpGet]
        [CustomAuthorize(Roles = "user,admin")]
        public ActionResult Cabinet()
        {
            return View(service.GetUserById(User.Id));
        }

        [HttpPost]
        public ActionResult Cabinet(UserViewModel model)
        {
            service.UpdateUser(User.Id, model);
            return View(model);
        }
    }
}
