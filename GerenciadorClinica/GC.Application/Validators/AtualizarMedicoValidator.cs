﻿using FluentValidation;
using GC.Application.CQRS.Commands.Medico.AtualizarMedico;

namespace GC.Application.Validators
{
    public class AtualizarMedicoValidator : AbstractValidator<AtualizarMedicoCommand>
    {
        public AtualizarMedicoValidator()
        {
            //Validar campos vazio
            RuleFor(x => x.Nome).NotEmpty().NotNull().WithMessage("O campo nome não pode ser nulo ou vazio.")
                .Length(5, 160).WithMessage("O campo nome deve conter entre 5 à 160 caracteres.");

            RuleFor(x => x.Sobrenome).NotEmpty().NotNull().WithMessage("O campo sobrenome não pode ser nulo ou vazio.")
                .Length(5, 160).WithMessage("O campo sobrenome deve conter entre 5 à 160 caracteres.");

            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("O campo Email não pode ser nulo ou vazio.")
                .EmailAddress().WithMessage("Insira um E-mail valido.");

            RuleFor(x => x.CRM).NotEmpty().NotNull().WithMessage("O campo crm não pode ser nulo ou vazio.");

            RuleFor(x => x.Cpf).NotEmpty().NotNull().WithMessage("O campo cpf não pode ser nulo ou vazio.");

            //RuleFor(x => x.Cpf)
            //    .NotEmpty().NotNull().WithMessage("O campo cpf não pode ser nulo ou vazio.")
            //    .Must(ValidatorMethods.ValidateCPF).WithMessage("CPF inválido");

            RuleFor(x => x.DataNascimento).NotEmpty().NotNull().WithMessage("O campo data de nascimento não pode ser nulo ou vazio.");
            RuleFor(x => x.Telefone).NotEmpty().NotNull().WithMessage("O campo telefone não pode ser nulo ou vazio.");
            RuleFor(x => x.Especialidade).NotEmpty().NotNull().WithMessage("O campo especialidade não pode ser nulo ou vazio.");
            RuleFor(x => x.Endereco).NotEmpty().NotNull().WithMessage("O campo endereco não pode ser nulo ou vazio.");
            RuleFor(x => x.TipoSanguineo).NotEmpty().NotNull().WithMessage("O campo tipo sanguineo não pode ser nulo ou vazio.");
        }
    }
}
