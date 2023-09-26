using JSystem.Dados.Context;
using JSystem.Models;
using JSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JSystem.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ContextWeb _contextWeb;

        public CustomerRepository(ContextWeb contextWeb)
        {
            _contextWeb = contextWeb;
        }

        public async Task<CustomerModel> CreateCustomer(CustomerModel customer)
        {
            _contextWeb.Customers.Add(customer);
            await _contextWeb.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> CustomerLogin(CustomerModel customer)
        {
            if (string.IsNullOrEmpty(customer.Email) || string.IsNullOrEmpty(customer.Password))
            {
                return false;
            }

            var existingCustomer = await _contextWeb.Customers
                .FirstOrDefaultAsync(x => x.Email == customer.Email);

            if (existingCustomer != null && existingCustomer.Password == customer.Password)
            {
                return true; 
            }

            return false; 
        }

        public async Task<List<CustomerModel>> GetCustomer()
        {
            return _contextWeb.Customers.ToList();
        }

        public async Task<CustomerModel> GetCustomerByIdAsync(Guid id)
        {
            return await _contextWeb.Customers.FindAsync(id);
        }

        public async Task<CustomerModel> UpdateCustomer(Guid Id, CustomerModel customer)
        {
            var customerReturn = await GetCustomerByIdAsync(Id);

            if (customerReturn is null)
                return customer;
            else
            {
                customerReturn.Name = customer.Name;
                customerReturn.Email = customer.Email;
                customerReturn.Password = customer.Password;
                return customerReturn;
            }
        }
    }
}
