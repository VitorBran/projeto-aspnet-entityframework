using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistroFuncionarios.DAL;
using RegistroFuncionarios.ViewModels;

namespace RegistroFuncionarios.Controllers
{
    public class HomeController : Controller
    {
        private FuncionarioContext db = new FuncionarioContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GastosSalario(string searchString)
        {
            ConsultaGastos cg = new ConsultaGastos();

            DateTime auxData = DateTime.Today;

            var funcionarios = from f in db.Funcionarios select f;

            cg.DataConsulta = auxData;

            funcionarios = funcionarios.Where(f => f.DataAdmissao <= cg.DataAltual);

            foreach (var f in funcionarios)
            {
                cg.TotalSalarioAtual += f.Salario;
            }

            if (!String.IsNullOrEmpty(searchString) && DateTime.TryParse(searchString, out auxData))
            {
                auxData = DateTime.Parse(searchString);

                cg.DataConsulta = auxData;

                if (!String.IsNullOrEmpty(searchString))
                {
                    funcionarios = funcionarios.Where(f => f.DataAdmissao <= auxData);
                }


                foreach (var f in funcionarios)
                {
                    cg.TotalSalarioConsultado += f.Salario;
                }

                

                return View(cg);
            }
            else
            {
                return View(cg);
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}