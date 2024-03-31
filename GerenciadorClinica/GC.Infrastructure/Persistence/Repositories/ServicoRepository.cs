using GC.Core.Entityes;
using GC.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GC.Infrastructure.Persistence.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly DBClinicaContexto _contexto;


        public ServicoRepository(DBClinicaContexto contexto)
        {
            _contexto = contexto;
        }


        public async Task<List<Servico>> GetAllAsync()
        {
            try
            {
                var servicos = _contexto.Servicos;

                return await servicos.ToListAsync();
            }
            catch (ArgumentNullException ex)
            {
                var mensagemErro = $"Erro ao selecionar os {nameof(Servico)}. O contexto do banco de dados não pode ser nulo.";
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

        public async Task<Servico> GetByIdAsync(int id)
        {
            try
            {
                var servico = await _contexto.Servicos.SingleOrDefaultAsync(x => x.Id == id);

                return servico;
            }
            catch (OperationCanceledException ex)
            {
                var mensagemErro = "A operação foi cancelada.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (ArgumentNullException ex)
            {
                var mensagemErro = $"Erro ao selecionar o {nameof(Servico)}. O contexto do banco de dados não pode ser nulo.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch (Exception ex)
            {
                var mensagemErro = "Ocorreu um erro ao processar sua solicitação. Por favor, tente novamente mais tarde.";
                throw new InvalidOperationException(mensagemErro, ex);
            }
        }

        public async Task PostAysnc(Servico servico)
        {
            try
            {
                _contexto.Update(servico);
                await _contexto.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                var mensagemErro = $"O {nameof(Servico)} que você está tentando atualizar foi modificado por outro usuário. Recarregue os dados e tente novamente.";
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
            catch(OperationCanceledException ex)
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

        public async Task PutAsync(Servico servico)
        {
            try
            {
                _contexto.Update(servico);
                await _contexto.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                var mensagemErro = $"O {nameof(Servico)} que esta tentando atualizar, ja foi modificado, por outro usuário. Recarregue os dados e tente novamente.";
                throw new InvalidOperationException(mensagemErro , ex);
            }
            catch(DbUpdateException ex)
            {
                var mensagemErro = "Erro ao tentar gravar.";

                if (ex.InnerException is SqlException sqlException)
                    mensagemErro = $"Error SQL {sqlException.Number}:{sqlException.Message}";

                throw new InvalidOperationException(mensagemErro, ex);
            }
            catch(OperationCanceledException ex)
            {
                var mensagemErro = "Operação foi cancelada.";
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
