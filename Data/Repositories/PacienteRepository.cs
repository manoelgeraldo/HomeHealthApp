using Data.DataAccess;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PacienteRepository(DataContextAccess data) : IPacienteRepository
    {
        public async Task<IEnumerable<Paciente>> ObterPacientesAsync()
        {
            var pacientes = await data.Pacientes.AsNoTracking().ToListAsync();
            return pacientes;
        }

        public async Task<Paciente> ObterPacienteAsync(string cpf)
        {
            var paciente = await data.Pacientes.AsNoTracking().SingleOrDefaultAsync(x => x.CPF.Equals(cpf));
            return paciente;
        }

        public async Task<Paciente> AdicionarPacienteAsync(Paciente paciente)
        {
            await data.Pacientes.AddAsync(paciente);
            await data.SaveChangesAsync();
            return paciente;
        }

        public async Task<Paciente> EditarPacienteAsync(Paciente paciente, Paciente pacienteEditado)
        {            
            data.Entry(paciente).CurrentValues.SetValues(pacienteEditado);
            await data.SaveChangesAsync();
            return paciente;
        }
    }
}
