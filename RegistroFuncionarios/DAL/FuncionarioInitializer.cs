using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RegistroFuncionarios.Models;

namespace RegistroFuncionarios.DAL
{
    public class FuncionarioInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FuncionarioContext>
    {
        protected override void Seed(FuncionarioContext context)
        {
            var funcionarios = new List<Funcionario>
            {
                new Funcionario{Nome="José Silva", Sexo="M", Pis="11111111111", Cpf="11111111111", Salario=2000, Email="jose_si@mail.com", DataAdmissao=DateTime.Parse("2018-06-01") },
                new Funcionario{Nome="Maria Cavalcanti", Sexo="F", Pis="22222222222", Cpf="22222222222", Salario=2500, Email="maria_ca@mail.com", DataAdmissao=DateTime.Parse("2017-09-15") },
                new Funcionario{Nome="João Oliveira", Sexo="M", Pis="33333333333", Cpf="33333333333", Salario=1800, Email="joao_ol@mail.com", DataAdmissao=DateTime.Parse("2017-02-21") },
                new Funcionario{Nome="Ana Santos", Sexo="F", Pis="44444444444", Cpf="44444444444", Salario=2000, Email="ana_so@mail.com", DataAdmissao=DateTime.Parse("2018-04-08") },
                new Funcionario{Nome="Antonio Souza", Sexo="M", Pis="5555555555", Cpf="5555555555", Salario=2000, Email="antonio_so@mail.com", DataAdmissao=DateTime.Parse("2016-07-19") },
                new Funcionario{Nome="Francisca Lima", Sexo="F", Pis="66666666666", Cpf="66666666666", Salario=2000, Email="francisca_li@mail.com", DataAdmissao=DateTime.Parse("2016-07-19") },
                new Funcionario{Nome="Pedro Campos", Sexo="M", Pis="77777777777", Cpf="77777777777", Salario=1750, Email="pedro_ca@mail.com", DataAdmissao=DateTime.Parse("2016-05-19") }
            };

            funcionarios.ForEach(f => context.Funcionarios.Add(f));
            context.SaveChanges();
        }
    }
}