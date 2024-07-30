using FluentValidation;
using GC.Application.CQRS.Commands.Pacientes.CadastrarPaciente;

namespace GC.Application.Validators.Paciente
{
    public class CadastrarPacienteValidator : AbstractValidator<CadastrarPacienteCommand>
    {
        public CadastrarPacienteValidator()
        {
            RuleFor(x => x.Nome)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarPacienteCommand.Nome)))
                   .Length(4, 160)
                   .WithMessage(ValidatorMethods.MensagemTamanhoCampo(nameof(CadastrarPacienteCommand.Nome), 4, 160));

            RuleFor(x => x.Sobrenome)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarPacienteCommand.Sobrenome)))
                .Length(4, 160)
                .WithMessage(ValidatorMethods.MensagemTamanhoCampo(nameof(CadastrarPacienteCommand.Sobrenome), 4, 160));

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarPacienteCommand.Email)))
                .EmailAddress()
                .WithMessage(ValidatorMethods.MensagemCampoInvalido(nameof(CadastrarPacienteCommand.Email)));

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarPacienteCommand.Cpf)))
                .Must(ValidatorMethods.ValidateCPF)
                .WithMessage(ValidatorMethods.MensagemCampoInvalido(nameof(CadastrarPacienteCommand.Cpf)));


            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarPacienteCommand.DataNascimento)));

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarPacienteCommand.Telefone)));

            RuleFor(x => x.Endereco)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarPacienteCommand.Endereco)));

            RuleFor(x => x.TipoSanguineo)
                .NotEmpty()
                .NotNull()
                .WithMessage(ValidatorMethods.MensagemCampoVazioNulo(nameof(CadastrarPacienteCommand.TipoSanguineo)));

        }
    }
}
