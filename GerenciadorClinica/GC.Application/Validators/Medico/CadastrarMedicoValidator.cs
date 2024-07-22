using FluentValidation;
using GC.Application.CQRS.Commands.Medicos.CadastrarMedico;

namespace GC.Application.Validators.Medico
{
    public class CadastrarMedicoValidator : AbstractValidator<CadastrarMedicoCommand>
    {
        public CadastrarMedicoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarMedicoCommand.Nome)))
                .Length(5, 160)
                .WithMessage(ValidatorMethods.MensagemTamanhoCampo(nameof(CadastrarMedicoCommand.Sobrenome), 5, 160));

            RuleFor(x => x.Sobrenome)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarMedicoCommand.Sobrenome)))
                .Length(5, 160)
                .WithMessage(ValidatorMethods.MensagemTamanhoCampo(nameof(CadastrarMedicoCommand.Sobrenome), 5, 160));

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarMedicoCommand.Email)))
                .EmailAddress()
                .WithMessage(ValidatorMethods.MensagemCampoInvalido(nameof(CadastrarMedicoCommand.Email)));

            RuleFor(x => x.CRM)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarMedicoCommand.CRM)));

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarMedicoCommand.Cpf)));

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarMedicoCommand.DataNascimento)));

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarMedicoCommand.Telefone)));

            RuleFor(x => x.Especialidade)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarMedicoCommand.Endereco)));

            RuleFor(x => x.Endereco)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarMedicoCommand.Nome)));

            RuleFor(x => x.TipoSanguineo)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarMedicoCommand.TipoSanguineo)));
        }
    }
}
