using FluentValidation;
using GC.Application.CQRS.Commands.Medicos.AtualizarMedico;

namespace GC.Application.Validators.Medico
{
    public class AtualizarMedicoValidator : AbstractValidator<AtualizarMedicoCommand>
    {
        public AtualizarMedicoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarMedicoCommand.Nome)))
                .Length(5, 160)
                .WithMessage(ValidatorMethods.MensagemTamanhoCampo(nameof(AtualizarMedicoCommand.Sobrenome), 5, 160));

            RuleFor(x => x.Sobrenome)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarMedicoCommand.Sobrenome)))
                .Length(5, 160)
                .WithMessage(ValidatorMethods.MensagemTamanhoCampo(nameof(AtualizarMedicoCommand.Sobrenome), 5, 160));

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarMedicoCommand.Email)))
                .EmailAddress()
                .WithMessage(ValidatorMethods.MensagemCampoInvalido(nameof(AtualizarMedicoCommand.Email)));

            RuleFor(x => x.CRM)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarMedicoCommand.CRM)));

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarMedicoCommand.Cpf)));

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarMedicoCommand.DataNascimento)));

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarMedicoCommand.Telefone)));

            RuleFor(x => x.Especialidade)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarMedicoCommand.Endereco)));

            RuleFor(x => x.Endereco)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarMedicoCommand.Nome)));

            RuleFor(x => x.TipoSanguineo)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarMedicoCommand.TipoSanguineo)));
        }
    }
}
