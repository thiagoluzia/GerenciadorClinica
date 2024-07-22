using GC.Core.Entityes;
using GC.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GC.Infrastructure.Persistence.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly DBClinicaContexto _contexto;

        public MedicoRepository(DBClinicaContexto contexto)
        {
            _contexto = contexto;
        }


        public async Task PutAsync(Medico medico)
        {
            try
            {
                _contexto.Update(medico);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var mensagemErro = $"O {nameof(Medico)} que você está tentando atualizar foi modificado por outro usuário. Recarregue os dados e tente novamente.";
                throw new InvalidOperationException(mensagemErro, ex);

            }
            catch(DbUpdateException ex)
            {
                var mensagemErro = "Erro ao tentar gravar.";

                if (ex.InnerException is SqlException sqlException)
                {
                    mensagemErro = $" Error SQL {sqlException.Number}: {sqlException.Message}";
                }

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

        public async Task<Medico> GetByIdAsync(int id)
        {
            try
            {
                var medico = await _contexto.Medico.SingleOrDefaultAsync(x => x.Id == id);

                return medico;
            }
            catch (ArgumentNullException ex)
            {
                var mensagemErro = $"Erro ao selecionar o {nameof(Medico)} solicitado. O contexto do banco de dados não pode ser nulo.";
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

        /// <summary>
        /// Buscar todos os medicos.
        /// </summary>
        /// <returns>Uma coleção coleção de  <see cref="Medico"/>.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<IList<Medico>> GetAllAsync()
        {
            try
            {
                var medicos = _contexto.Medico;

                return await medicos.ToListAsync();
            }
            catch (ArgumentNullException ex)
            {
                var mensagemErro = $"Erro ao selecionar os {nameof(Medico)}. O contexto do banco de dados não pode ser nulo.";
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

        public async Task PostAsync(Medico medico)
        {
            try
            {
                await _contexto.Medico.AddAsync(medico);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var mensagemErro = $"O {nameof(Medico)} que você está tentando salvar foi modificado por outro usuário. Recarregue os dados e tente novamente.";
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

        public async  Task DeleteAsync(int id)
        {
            try
            {
                var medico = await _contexto.Medico.SingleOrDefaultAsync(x => x.Id == id);

                _contexto.Medico.Remove(medico);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var mensagemErro = $"O {nameof(Medico)} que você está tentando excluir foi modificado por outro usuário. Recarregue os dados e tente novamente.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (DbUpdateException ex)
            {
                var mensagemErro = $"Erro ao tentar excluir o {nameof(Medico)}.";

                if (ex.InnerException is SqlException sqlException)
                {
                    mensagemErro = $" Error SQL {sqlException.Number}: {sqlException.Message}";
                }

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
