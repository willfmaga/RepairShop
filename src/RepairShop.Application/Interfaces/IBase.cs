using RepairShop.Application.Applications;

namespace RepairShop.Application.Interfaces
{
    public interface IBase
    {
        public ApplicationStatus Status { get; }

        public string ErrorsToString();
    }
}
