using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using RegistroFuncionarios.DAL;
using RegistroFuncionarios.Models;

namespace RegistroFuncionarios.Controllers
{
    public class FuncionariosController : Controller
    {
        private FuncionarioContext db = new FuncionarioContext();

        // GET: Funcionarios3
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NomeSortParm = String.IsNullOrEmpty(sortOrder) ? "nome_desc" : "";
            ViewBag.SexoSortParm = sortOrder == "Sexo" ? "sexo_desc" : "Sexo";
            ViewBag.PisSortParm = sortOrder == "Pis" ? "pis_desc" : "Pis";
            ViewBag.CpfSortParm = sortOrder == "Cpf" ? "cpf_desc" : "Cpf";
            ViewBag.SalarioSortParm = sortOrder == "Salario" ? "salario_desc" : "Salario";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "email_desc" : "Email";
            ViewBag.DataSortParm = sortOrder == "Data" ? "data_desc" : "Data";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var funcionarios = from f in db.Funcionarios select f;


            if (!String.IsNullOrEmpty(searchString))
            {
                funcionarios = funcionarios.Where(f => f.Nome.Contains(searchString) || f.Cpf.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "nome_desc":
                    funcionarios = funcionarios.OrderByDescending(f => f.Nome);
                    break;
                case "Sexo":
                    funcionarios = funcionarios.OrderBy(f => f.Sexo);
                    break;
                case "sexo_desc":
                    funcionarios = funcionarios.OrderByDescending(f => f.Sexo);
                    break;
                case "Pis":
                    funcionarios = funcionarios.OrderBy(f => f.Pis);
                    break;
                case "pis_desc":
                    funcionarios = funcionarios.OrderByDescending(f => f.Pis);
                    break;
                case "Cpf":
                    funcionarios = funcionarios.OrderBy(f => f.Cpf);
                    break;
                case "cpf_desc":
                    funcionarios = funcionarios.OrderByDescending(f => f.Cpf);
                    break;
                case "Salario":
                    funcionarios = funcionarios.OrderBy(f => f.Salario);
                    break;
                case "salario_desc":
                    funcionarios = funcionarios.OrderByDescending(f => f.Salario);
                    break;
                case "Email":
                    funcionarios = funcionarios.OrderBy(f => f.Email);
                    break;
                case "email_desc":
                    funcionarios = funcionarios.OrderByDescending(f => f.Email);
                    break;
                case "Data":
                    funcionarios = funcionarios.OrderBy(f => f.DataAdmissao);
                    break;
                case "data_desc":
                    funcionarios = funcionarios.OrderByDescending(f => f.DataAdmissao);
                    break;
                default:
                    funcionarios = funcionarios.OrderBy(f => f.Nome);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(funcionarios.ToPagedList(pageNumber, pageSize));
        }

        // GET: Funcionarios3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: Funcionarios3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Sexo,Pis,Cpf,Salario,Email,DataAdmissao")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funcionario);
        }

        // GET: Funcionarios3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Sexo,Pis,Cpf,Salario,Email,DataAdmissao")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        // GET: Funcionarios3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
