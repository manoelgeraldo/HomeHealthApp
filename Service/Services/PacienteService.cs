using AutoMapper;
using Azure.Core.Pipeline;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PacienteService(IPacienteRepository repository, IMapper mapper) : IPacienteService
    {
        public async Task<IEnumerable<PacienteViewModel>> ObterPacientesAsync()
        {
            var pacientes = await repository.ObterPacientesAsync();

            var pacientesViewModel = mapper.Map<IEnumerable<PacienteViewModel>>(pacientes);

            return pacientesViewModel;
        }

        public async Task<PacienteViewModel> ObterPacienteAsync(string cpf)
        {
            var paciente = await repository.ObterPacienteAsync(cpf) ?? throw new Exception("Paciente não existe na base de dados!");
            var pacienteViewModel = mapper.Map<PacienteViewModel>(paciente);

            return pacienteViewModel;
        }

        public async Task<PacienteViewModel> AdicionarPacienteAsync(PacienteViewModel novoPaciente)
        {
            var paciente = mapper.Map<Paciente>(novoPaciente);
            
            paciente = await repository.AdicionarPacienteAsync(paciente);
            
            var pacienteViewModel = mapper.Map<PacienteViewModel>(paciente);

            return pacienteViewModel;
        }

        public async Task<PacienteViewModel> EditarPacienteAsync(PacienteViewModel pacienteEditado)
        {
            var paciente = await repository.ObterPacienteAsync(pacienteEditado.CPF) ?? throw new Exception("Paciente não existe na base de dados!");
            paciente = await repository.EditarPacienteAsync(paciente, mapper.Map<Paciente>(pacienteEditado));

            pacienteEditado = mapper.Map<PacienteViewModel>(paciente);

            return pacienteEditado;
        }

        
    }
}
