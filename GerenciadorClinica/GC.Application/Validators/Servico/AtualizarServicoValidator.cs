using FluentValidation;
using GC.Application.CQRS.Commands.Servico.AtualizarServico;

namespace GC.Application.Validators.Servico
{
    public class AtualizarServicoValidator : AbstractValidator<AtualizarServicoCommand>
    {
        public AtualizarServicoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().NotEqual(0).WithMessage("O id do serviço não pode ser vasio, nulo ou zero.");
            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("O nome do serviço não pode ser nulo ou vazio.");
            RuleFor(x => x.Nome).MaximumLength(20).MinimumLength(5).WithMessage("O nome do serviço deve conter entre 5 e 20 carcateres.");

            RuleFor(x => x.Descricao).NotNull().NotEmpty().WithMessage("A descrição do serviço não pode ser nulo ou vazio.");
            RuleFor(x => x.Descricao).MaximumLength(200).MinimumLength(5).WithMessage("A descrição do serviço deve conter entre 5 e 100 carcateres.");

            RuleFor(x => x.Valor).NotNull().NotEmpty().NotEqual(0).WithMessage("O valor do serviço nao pode ser nulo, vazio ou zero.");
            RuleFor(x => x.Duracao).NotNull().NotEmpty().NotEqual(0).WithMessage("O tempo de duração do serviço, não pode ser vazio, nulo, ou zero.");

        }
    }
}
