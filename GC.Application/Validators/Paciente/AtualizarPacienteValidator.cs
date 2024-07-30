using FluentValidation;
using GC.Application.CQRS.Commands.Pacientes.AtualizarPaciente;

namespace GC.Application.Validators.Paciente
{
    public class AtualizarPacienteValidator : AbstractValidator<AtualizarPacienteCommand>
    {
        public AtualizarPacienteValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarPacienteCommand.Nome)))
                .Length(4, 160)
                .WithMessage(ValidatorMethods.MensagemTamanhoCampo(nameof(AtualizarPacienteCommand.Nome), 4, 160));

            RuleFor(x => x.Sobrenome)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarPacienteCommand.Sobrenome)))
                .Length(4, 160)
                .WithMessage(ValidatorMethods.MensagemTamanhoCampo(nameof(AtualizarPacienteCommand.Sobrenome), 4, 160));

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarPacienteCommand.Email)))
                .EmailAddress()
                .WithMessage(ValidatorMethods.MensagemCampoInvalido(nameof(AtualizarPacienteCommand.Email)));

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarPacienteCommand.Cpf)))
                .Must(ValidatorMethods.ValidateCPF)
                .WithMessage(ValidatorMethods.MensagemCampoInvalido(nameof(AtualizarPacienteCommand.Cpf)));


            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarPacienteCommand.DataNascimento)));

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarPacienteCommand.Telefone)));

            RuleFor(x => x.Endereco)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarPacienteCommand.Endereco)));

            RuleFor(x => x.TipoSanguineo)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(AtualizarPacienteCommand.TipoSanguineo)));
        }
    }
}
