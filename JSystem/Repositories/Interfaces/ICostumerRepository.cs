using JSystem.Models;

namespace JSystem.Repositories.Interfaces
{
    public interface ICostumerRepository
    {
        public List<CostumerModel> GetCostumers();
        public CostumerModel GetCostumerById(int id);
        public bool ConstumerLogin(CostumerModel costumer);
        public CostumerModel UpdateCostumer(Guid Id, CostumerModel costumer);
    }
}
