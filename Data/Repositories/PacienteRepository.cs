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
    public class PacienteRepository : IPacienteRepository
    {
        private readonly DataContextAccess _context;

        public PacienteRepository(DataContextAccess data)
        {
            _context = data;
        }

        public async Task<IEnumerable<Paciente>> ObterPacientesAsync()
        {
            var pacientes = await _context.Pacientes.AsNoTracking().ToListAsync();
            return pacientes;
        }

        public async Task<Paciente> ObterPacienteAsync(string cpf)
        {
            var paciente = await _context.Pacientes.AsNoTracking().SingleOrDefaultAsync(x => x.CPF.Equals(cpf));
            return paciente;
        }

        public async Task<Paciente> AdicionarPacienteAsync(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<Paciente> EditarPacienteAsync(Paciente paciente, Paciente pacienteEditado)
        {            
            _context.Entry(paciente).CurrentValues.SetValues(pacienteEditado);
            await _context.SaveChangesAsync();
            return paciente;
        }
    }
}
