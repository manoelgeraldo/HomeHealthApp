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

        private Paciente() { }

        public Paciente(string cpf, string nome, DateOnly dataNascimento, EnumSexo sexo)
        {
            CPF = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
        }

        public int CalcularIdade()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            int age = today.Year - DataNascimento.Year;
            if (today < DataNascimento.AddYears(age)) age--;
            return age;
        }

        public override string ToString()
        {
            return $"Paciente: {Nome}, CPF: {CPF}, Data de Nascimento: {DataNascimento}, Sexo: {Sexo}, Idade: {CalcularIdade()}";
        }
    }
}
