using FluentValidation;
using RepairShop.Application.DTOs;
using DocumentType = RepairShop.Application.DTOs.DocumentType;
using PersonType = RepairShop.Application.DTOs.PersonType;

namespace RepairShop.Application.Validations
{
    public class PersonDocumentValidator : AbstractValidator<PersonDocumentDTO>
    {
        internal PersonDocumentValidator()
        {
            Validate();
        }

        private void Validate()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .WithErrorCode("1")
                .WithName("Name")
                .MaximumLength(50)
                .WithErrorCode("1")
                .WithName("Campo Name deve ter no maximo 50 digitos.");

            RuleFor(s => s.Surname)
                .NotEmpty()
                .WithErrorCode("2")
                .WithName("Surname")
                .MaximumLength(100)
                .WithErrorCode("1")
                .WithName("Campo Surname deve ter no maximo 100 digitos.");

            RuleFor(s => s.TypeId)
                .NotNull()
                .WithErrorCode("3")
                .WithName("Tipo de documento não pode ser nulo.")
                .WithMessage("Tipo de documento não pode ser nulo.");

            RuleFor(s => s.TypeId)
                .NotEqual(PersonType.None)
                .WithErrorCode("3")
                .WithName("Tipo de documento nao pode ser 0 - None");

            Include(new PersonAgeValidator());

            //Document Validation
            RuleFor(s => s.Document.Value)
               .NotEmpty()
               .WithErrorCode("4")
               .WithName("Value")
               .MaximumLength(14)
               .WithErrorCode("4")
               .WithName("Campo Value deve ter no maximo 14 digitos.");

            RuleFor(s => s.Document.TypeId)
                .NotNull()
                .WithErrorCode("5")
                .WithName("Tipo de documento não pode ser nulo.")
                .WithMessage("Tipo de documento não pode ser nulo.");

            RuleFor(s => s.Document.TypeId)
                .NotEqual(DocumentType.None)
                .WithErrorCode("5")
                .WithName("Tipo de documento nao pode ser 0 - None");
        }
    }
    public class PersonAgeValidator : AbstractValidator<PersonDocumentDTO>
    {
        public PersonAgeValidator()
        {
            RuleFor(x => x.BirthDate).Must(BeOver18);
        }

        private bool BeOver18(DateTime? birthDate)
        {
            
            int age = DateTime.Now.Year - birthDate.Value.Year;

            if (DateTime.Now.DayOfYear < birthDate.Value.DayOfYear)
            {
                age = age + 1;
            }

            return age > 18;
        }
    }

}
