using GC.Core.Entityes;
using GC.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GC.Infrastructure.Persistence.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly DBClinicaContexto _contexto;

        public PacienteRepository(DBClinicaContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task DeleteAsync(int id)
        {

            try
            {
                var paciente = await _contexto.Pacientes.SingleOrDefaultAsync(x => x.Id == id);

                _contexto.Pacientes.Remove(paciente);
                _contexto.SaveChanges();
            }
            catch (ArgumentNullException ex)
            {
                var mensagemErro = $"Erro ao tentar deletar o {nameof(Paciente)} informado, paciente não encontrado. O contexto do banco de dados não pode ser nulo.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var mensagemErro = $"O {nameof(Paciente)} que você está tentando deletar foi modificado por outro usuário. Recarregue os dados e tente novamente.";
                throw new InvalidOperationException(mensagemErro, ex);

            }
            catch (OperationCanceledException ex)
            {
                var mensagemErro = "A operação foi cancelada.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (Exception ex)
            {
                var mensagemErro = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemErro, ex);
            }

        }
        public async Task<IList<Paciente>> GetAllAsync()
        {

            try
            {
                var pacientes = _contexto.Pacientes;

                return await pacientes.ToListAsync();
            }
            catch (ArgumentNullException ex)
            {
                var mensagemErro = $"Erro ao selecionar os {nameof(Paciente)}. O contexto do banco de dados não pode ser nulo.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (OperationCanceledException ex)
            {
                var mensagemErro = "A operação foi cancelada.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (Exception ex)
            {
                var mensagemErro = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemErro, ex);
            }

        }
        public async Task<Paciente> GetByCpfOrTelAsync(string cpfOrTel)
        {

            try
            {
                var paciente = await  _contexto.Pacientes
                .SingleOrDefaultAsync(x => x.Cpf == cpfOrTel || x.Telefone == cpfOrTel);
                
                return paciente;
            }
            catch (ArgumentNullException ex)
            {
                var mensagemErro = $"Erro ao selecionar os {nameof(Paciente)}. O contexto do banco de dados não pode ser nulo.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (OperationCanceledException ex)
            {
                var mensagemErro = "A operação foi cancelada.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (Exception ex)
            {
                var mensagemErro = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemErro, ex);
            }

        }
        public async Task PostAsync(Paciente paciente)
        {

            try
            {
                await _contexto.Pacientes.AddAsync(paciente);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var mensagemErro = $"O {nameof(Paciente)} que você está tentando salvar foi modificado por outro usuário. Recarregue os dados e tente novamente.";
                throw new InvalidOperationException(mensagemErro, ex);

            }
            catch (DbUpdateException ex)
            {
                var mensagemErro = "Erro ao tentar salvar.";

                if (ex.InnerException is SqlException sqlException)
                {
                    mensagemErro = $" Error SQL {sqlException.Number}: {sqlException.Message}";
                }

                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (Exception ex)
            {
                var mensagemErro = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemErro, ex);
            }

        }
        public async Task Putasync(Paciente paciente)
        {

            try
            {
                
                

                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var mensagemErro = $"O {nameof(Paciente)} que você está tentando gravar foi modificado por outro usuário. Recarregue os dados e tente novamente.";
                throw new InvalidOperationException(mensagemErro, ex);

            }
            catch (DbUpdateException ex)
            {
                var mensagemErro = "Erro ao tentar gravar.";

                if (ex.InnerException is SqlException sqlException)
                {
                    mensagemErro = $" Error SQL {sqlException.Number}: {sqlException.Message}";
                }

                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (Exception ex)
            {
                var mensagemErro = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemErro, ex);
            }

        }
        public async Task<Paciente> GetByIdAsync(int id)
        {
            try
            {
                var paciente = await _contexto.Pacientes.SingleOrDefaultAsync(x => x.Id == id);

                return  paciente;
            }
            catch (ArgumentNullException ex)
            {
                var mensagemErro = $"Erro ao selecionar os {nameof(Paciente)}. O contexto do banco de dados não pode ser nulo.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (OperationCanceledException ex)
            {
                var mensagemErro = "A operação foi cancelada.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (Exception ex)
            {
                var mensagemErro = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
        }

    }
}
