using JSystem.Dados.Context;
using JSystem.Models;
using JSystem.Repositories.Interfaces;

namespace JSystem.Repositories
{
    public class CostumerRepository : ICostumerRepository
    {
        private readonly ContextWeb _contextWeb;

        public CostumerRepository(ContextWeb contextWeb)
        {
            _contextWeb = contextWeb;
        }

        public bool ConstumerLogin(CostumerModel costumer)
        {
           CostumerModel GetCostumer = _contextWeb.Costumers.FirstOrDefault(c => c.Email == costumer.Email && c.Password == costumer.Password)!;
            return true;
        }

        public CostumerModel GetCostumerById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CostumerModel> GetCostumers()
        {
            throw new NotImplementedException();
        }

        public CostumerModel UpdateCostumer(Guid Id, CostumerModel costumer)
        {
            throw new NotImplementedException();
        }
    }
}
