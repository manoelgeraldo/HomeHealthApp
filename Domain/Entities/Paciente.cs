using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Paciente
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public EnumSexo Sexo { get; set; }
    }
}
