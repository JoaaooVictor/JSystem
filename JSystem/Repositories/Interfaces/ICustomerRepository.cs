using JSystem.Models;

namespace JSystem.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<CustomerModel> CreateCustomer(CustomerModel customer);
        Task<List<CustomerModel>> GetCustomer();
        Task<CustomerModel> GetCustomerByIdAsync(Guid id);
        Task<bool> CustomerLogin(CustomerModel customer);
        Task <CustomerModel> UpdateCustomer(Guid Id, CustomerModel customer);
    }
}
