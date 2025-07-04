using LogistikaApi.DBContext;
using LogistikaApi.Interface;
using LogistikaApi.Model;
using LogistikaApi.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LogistikaApi.Service
{
    public class ProductService : IProductService
    {
        private readonly ContextDB _context;
        public ProductService(ContextDB context) => _context = context;

        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _context.Product.ToListAsync();
            return new OkObjectResult(new { products = data });
        }

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null) return new NotFoundObjectResult(new { message = "Product not found" });
            return new OkObjectResult(new { product });
        }

        public async Task<IActionResult> CreateAsync(ProdReq product)
        {
            var prod = new Product();
            prod.Name = product.Name;
            prod.BatchNumber = product.BatchNumber;
            prod.ExpirationDate = product.ExpirationDate;
            prod.StorageConditions = product.StorageConditions;
            prod.Quantity = product.Quantity;
            await _context.Product.AddAsync(prod);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Product created", product });
        }

        public async Task<IActionResult> UpdateAsync(int id, ProdReq updatedProduct)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null) return new NotFoundObjectResult(new { message = "Product not found" });

            product.Name = updatedProduct.Name;
            product.BatchNumber = updatedProduct.BatchNumber;
            product.Quantity = updatedProduct.Quantity;
            product.ExpirationDate = updatedProduct.ExpirationDate;
            product.StorageConditions = updatedProduct.StorageConditions;

            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Product updated", product });
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null) return new NotFoundObjectResult(new { message = "Product not found" });

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Product deleted" });
        }
    }

}
