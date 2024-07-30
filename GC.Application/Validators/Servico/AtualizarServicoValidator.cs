using FluentValidation;
using GC.Application.CQRS.Commands.Servicos.AtualizarServico;
using GC.Application.CQRS.Commands.Servicos.CadstrarServico;

namespace GC.Application.Validators.Servico
{
    public class AtualizarServicoValidator : AbstractValidator<AtualizarServicoCommand>
    {
        public AtualizarServicoValidator()
        {

            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarServicoCommand.Nome)));

            RuleFor(x => x.Nome)
                .MaximumLength(20)
                .MinimumLength(5)
                .WithMessage(ValidatorMethods.MensagemTamanhoCampo(nameof(CadastrarServicoCommand.Nome), 5, 20));

            RuleFor(x => x.Descricao)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarServicoCommand.Descricao)));

            RuleFor(x => x.Descricao)
                .MaximumLength(100)
                .MinimumLength(5)
                .WithMessage(ValidatorMethods.MensagemTamanhoCampo(nameof(CadastrarServicoCommand.Nome), 5, 100));

            RuleFor(x => x.Valor)
                .NotNull()
                .NotEmpty()
                .NotEqual(0)
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarServicoCommand.Valor)));

            RuleFor(x => x.Duracao)
                .NotNull()
                .NotEmpty()
                .NotEqual(0)
                .WithMessage("O tempo de duração do serviço, não pode ser vazio, nulo, ou zero.");

        }
    }
}
