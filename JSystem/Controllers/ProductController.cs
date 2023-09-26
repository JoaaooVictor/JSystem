using Microsoft.AspNetCore.Mvc;
using JSystem.Models;
using JSystem.Repositories.Interfaces;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productRepository.GetAllProductsAsync();
        return View(products);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductModel product)
    {
        if (ModelState.IsValid)
        {
            await _productRepository.CreateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, ProductModel updatedProduct)
    {
        if (id != updatedProduct.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            var result = await _productRepository.UpdateProductAsync(id, updatedProduct);

            if (result == null)
            {
                return NotFound(); 
            }

            return RedirectToAction(nameof(Index));
        }

        return View(updatedProduct);
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var result = await _productRepository.DeleteProductAsync(id);

        if (!result)
        {
            return NotFound(); 
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Search(string name)
    {
        var products = await _productRepository.SearchProductsByNameAsync(name);
        return View(products);
    }
}

