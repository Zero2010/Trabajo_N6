using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trabajo_N6.Models;

namespace Trabajo_N6.Controllers
{
    public class UsuarioController : Controller
    {
        public IEnumerable<usuario> listausuarios;
        public IEnumerable<usuario> usu;
        public VeterinariaEntities db = new VeterinariaEntities();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ValidarUsuario(string user, string pass)
        {
            var usu = db.usuario
                     .FirstOrDefault(p => p.Usuario1 == user && p.Clave == pass && p.Activo == true);

            ViewData["usuarios"] = db.usuario
                     .Where(p => p.Usuario1 == user && p.Clave == pass && p.Activo == true);

            usu.InsertDateUsuario = DateTime.Now;
            db.usuario.Add(usu);
            db.SaveChanges();


            if (usu != null)
            {
                return RedirectToAction("Details");
            }

            return View();
        }

        // GET: Usuario/Details/5
        public ActionResult Details()
        {
            using (var Context = new VeterinariaEntities())
            {
                ViewBag.details = Context.usuario
                .ToList();
            }

            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
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

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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
    }
}
