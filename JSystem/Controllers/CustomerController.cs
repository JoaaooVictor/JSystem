using Microsoft.AspNetCore.Mvc;
using JSystem.Models; 
using JSystem.Repositories.Interfaces;

public class CustomerController : Controller
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(CustomerModel customer)
    {
        if (ModelState.IsValid)
        {
            var createdCustomer = await _customerRepository.CreateCustomer(customer);

            if (createdCustomer != null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Falha no registro. Verifique os dados fornecidos.");
            }
        }
        return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(CustomerModel customer)
    {
        if (ModelState.IsValid)
        {
            var loggedInCustomer = await _customerRepository.CustomerLogin(customer);

            if (loggedInCustomer != null)
            {

                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login falhou. Verifique suas credenciais.");
            }
        }

        return View(customer);
    }
}

