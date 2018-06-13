using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RegistroFuncionarios.Models
{
    public class Funcionario
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(1)]
        public string Sexo { get; set; }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string Pis { get; set; }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Required]
        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public double Salario { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Data de Admissão")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataAdmissao { get; set; }
    }
}