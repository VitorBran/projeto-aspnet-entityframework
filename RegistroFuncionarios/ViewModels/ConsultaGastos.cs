using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroFuncionarios.ViewModels
{
    public class ConsultaGastos
    {
        public double TotalSalarioConsultado = 0;
        public double TotalSalarioAtual = 0;
        public DateTime DataConsulta = DateTime.Today;
        public DateTime DataAltual = DateTime.Today;
    }
}