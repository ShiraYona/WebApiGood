using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly StoreDataBase1Context _myStoreContext;

        public ProductRepository(StoreDataBase1Context myStoreContext)
        {
            _myStoreContext = myStoreContext;
        }


        //public async Task<IEnumerable<Product>> getAllProduct()
        //{
           
        //    return await _myStoreContext.Products.ToListAsync();
        //}
        public async Task<IEnumerable<Product>> getAllProducts(string? desc, int? minPrice, int? maxPrice,
           int?[] categoryIds)
        {

            var query = _myStoreContext.Products.Where(product =>
            (desc == null ? (true) : (product.Description.Contains(desc)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId)))).OrderBy(product => product.Price);
            List<Product> products = await query.ToListAsync();
            return products;


            //return await _myStoreContext.Products.Where(product =>
            //(desc == null ? (true) : (product.Description.Contains(desc)))
            //&& ((minPrice == null) ? (true) : (product.Price >= minPrice))
            //&& ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            //&& ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId)))).OrderBy(product => product.Price).ToListAsync();
        }
    }



}



















