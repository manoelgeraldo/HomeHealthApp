using Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class PacienteViewModel
    {
        public string CPF { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public int Idade { get; set; }

        public EnumSexo Sexo { get; set; }
    }
}
