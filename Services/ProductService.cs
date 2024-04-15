using Microsoft.EntityFrameworkCore;
using Product_Prices.Models;
using Product_Prices.ViewModel;

namespace Product_Prices.Services
{
    public class ProductService
    {
        public ProductService(ProductPriceContext context)
        {
            _context = context;
        }

        private ProductPriceContext _context { get; set; }

        public async Task<bool> SubmitPrices(List<RequestAddProductPrices> model)
        {
            foreach (var item in model)
            {
                await _context.ProductPrices.AddAsync(new ProductPrice { Prices = item.Prices ?? 0, ProductId = item.ProductId ?? 0 });
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePrices(List<RequestAddProductPrices> model)
        {

            List<ProductPrice> currentPrices = await _context.ProductPrices
            .Where(v => model.Select(x => x.ProductId).Contains(v.ProductId))
            .ToListAsync();

            foreach (var item in model)
            {
                var existingProduct = currentPrices.FirstOrDefault(x => x.ProductId == item.ProductId);

                if (existingProduct == null)
                {

                    await _context.ProductPrices.AddAsync(new ProductPrice { Prices = item.Prices ?? 0, ProductId = item.ProductId ?? 0 });
                }
                else
                {

                    existingProduct.Prices = item.Prices ?? 0;
                    _context.ProductPrices.Update(existingProduct); // Mark as updated
                }

            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
