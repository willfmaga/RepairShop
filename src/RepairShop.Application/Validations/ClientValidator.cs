using FluentValidation;

using RepairShop.Application.DTOs;

namespace RepairShop.Application.Validations
{
    public class ClientValidator : AbstractValidator<ClientDTO>
    {
        internal ClientValidator()
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


            Include(new ClientAgeValidator());

            //Document Validation
            RuleFor(s => s.Document)
               .NotEmpty()
               .WithErrorCode("3")
               .WithName("Document")
               .MaximumLength(11)
               .WithErrorCode("4")
               .WithName("Campo Document deve ter no maximo 11 digitos.");
        }
    }
    public class ClientAgeValidator : AbstractValidator<ClientDTO>
    {
        public ClientAgeValidator()
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
