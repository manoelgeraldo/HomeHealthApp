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
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repository;
        private readonly IMapper _mapper;

        public PacienteService(IPacienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PacienteDTO>> ObterPacientesAsync()
        {
            var pacientes = await _repository.ObterPacientesAsync();

            var pacientesViewModel = _mapper.Map<IEnumerable<PacienteDTO>>(pacientes);

            return pacientesViewModel;
        }

        public async Task<PacienteDTO> ObterPacienteAsync(string cpf)
        {
            var paciente = await _repository.ObterPacienteAsync(cpf);

            if (paciente is null) { throw new Exception("Paciente não existe na base de dados!"); }

            var pacienteViewModel = _mapper.Map<PacienteDTO>(paciente);

            return pacienteViewModel;
        }

        public async Task<PacienteDTO> AdicionarPacienteAsync(PacienteDTO novoPaciente)
        {
            var paciente = _mapper.Map<Paciente>(novoPaciente);
            
            paciente = await _repository.AdicionarPacienteAsync(paciente);
            
            var pacienteViewModel = _mapper.Map<PacienteDTO>(paciente);

            return pacienteViewModel;
        }

        public async Task<PacienteDTO> EditarPacienteAsync(PacienteDTO pacienteEditado)
        {
            var paciente = await _repository.ObterPacienteAsync(pacienteEditado.CPF);
            
            if(paciente is null) { throw new Exception("Paciente não existe na base de dados!"); }

            paciente = await _repository.EditarPacienteAsync(paciente, _mapper.Map<Paciente>(pacienteEditado));

            pacienteEditado = _mapper.Map<PacienteDTO>(paciente);

            return pacienteEditado;
        }

        
    }
}
