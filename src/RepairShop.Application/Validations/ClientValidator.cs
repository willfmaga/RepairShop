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
                .WithMessage("Campo Name não pode ser null/vazio.");

            RuleFor(s => s.Name)
               .NotEmpty()
               .MinimumLength(3)
               .WithErrorCode("2")
               .WithMessage("Campo Name deve ter no minimo 3 digitos.");

            RuleFor(s => s.Name)
               .MaximumLength(50)
               .WithErrorCode("3")
               .WithName("Campo Name deve ter no maximo 50 digitos.");

            RuleFor(s => s.Surname)
                .NotEmpty()
                .WithErrorCode("4")
                .WithName("Surname")
                .MaximumLength(100)
                .WithErrorCode("4")
                .WithMessage("Campo Surname deve ter no maximo 100 digitos.");


            Include(new ClientAgeValidator());

            //Document Validation
            RuleFor(s => s.Document)
               .NotEmpty()
               .WithErrorCode("5")
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
