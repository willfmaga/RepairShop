using FluentValidation;
using RepairShop.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Application.Validations
{
    public class DocumentValidator: AbstractValidator<DocumentDTO>
    {
        internal DocumentValidator()
        {
            Validate();
        }

        private void Validate()
        {
            RuleFor(s => s.Value)
                .NotEmpty()
                .WithErrorCode("1")
                .WithName("Value")
                .MaximumLength(14)
                .WithErrorCode("1")
                .WithName("Campo Value deve ter no maximo 14 digitos.");

            RuleFor(s => s.TypeId)
                .NotNull()
                .WithErrorCode("2")
                .WithName("Tipo de documento não pode ser nulo.")
                .WithMessage("Tipo de documento não pode ser nulo.") ;

            RuleFor(s => s.TypeId)
                .NotEqual(DocumentType.None)
                .WithErrorCode("2")
                .WithName("Tipo de documento nao pode ser 0 - None");

        }
    }
}
