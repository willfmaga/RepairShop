using FluentValidation.Results;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace RepairShop.Application.Applications
{
    public class Base
    {
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Sucesso;
        public IEnumerable<ValidationFailure> ValidationsFailure { get; set; }

        public virtual string ErrorsToString()
        {
            var errors = ValidationsFailure.Select(e => new { ErroCode = e.ErrorCode, ErroMessage = e.ErrorMessage, ErroSeverity = e.Severity, }).ToList();

            return JsonConvert.SerializeObject(errors);  
        }
        public virtual void Validar() { }
    }

    public enum ApplicationStatus
    {
        Indefinido = 0,
        Sucesso = 1,
        Erro = 2,
        ErroNegocio = 3
    }
}
