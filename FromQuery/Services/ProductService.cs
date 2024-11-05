using FromQuery.Models;

namespace FromQuery.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Category = Category.Electronics, Price = 1000 },
            new Product { Id = 2, Name = "Jeans", Category = Category.Clothing, Price = 50 },
            new Product { Id = 3, Name = "Milk", Category = Category.Groceries, Price = 3 },
            new Product { Id = 4, Name = "Book", Category = Category.Books, Price = 15 },
            new Product { Id = 5, Name = "Smartphone", Category = Category.Electronics, Price = 700 },
            new Product { Id = 6, Name = "T-Shirt", Category = Category.Clothing, Price = 20 },
            new Product { Id = 7, Name = "Bread", Category = Category.Groceries, Price = 2 },
            new Product { Id = 8, Name = "Novel", Category = Category.Books, Price = 12 },
            new Product { Id = 9, Name = "Tablet", Category = Category.Electronics, Price = 300 },
            new Product { Id = 10, Name = "Jacket", Category = Category.Clothing, Price = 100 },
            new Product { Id = 11, Name = "Eggs", Category = Category.Groceries, Price = 5 },
            new Product { Id = 12, Name = "Textbook", Category = Category.Books, Price = 40 },
            new Product { Id = 13, Name = "Headphones", Category = Category.Electronics, Price = 150 },
            new Product { Id = 14, Name = "Shorts", Category = Category.Clothing, Price = 25 },
            new Product { Id = 15, Name = "Cheese", Category = Category.Groceries, Price = 4 },
            new Product { Id = 16, Name = "Biography", Category = Category.Books, Price = 20 },
            new Product { Id = 17, Name = "Monitor", Category = Category.Electronics, Price = 250 },
            new Product { Id = 18, Name = "Sweater", Category = Category.Clothing, Price = 60 },
            new Product { Id = 19, Name = "Juice", Category = Category.Groceries, Price = 3 },
            new Product { Id = 20, Name = "Comic Book", Category = Category.Books, Price = 8 }
        };

        public IEnumerable<Product> GetProducts(ProductQueryParameters queryParameters)
        {
            var products = _products.AsQueryable();

            if (!string.IsNullOrEmpty(queryParameters.Name))
            {
                products = products.Where(p => p.Name.Contains(queryParameters.Name, StringComparison.OrdinalIgnoreCase));
            }

            if (queryParameters.Category.HasValue)
            {
                products = products.Where(p => p.Category == queryParameters.Category.Value);
            }

            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (queryParameters.SortBy.Equals("price"))
                {
                    products = queryParameters.SortDescending ? products.OrderByDescending(p => p.Price) :
                        products.OrderBy(p => p.Price);
                }
                if (queryParameters.SortBy.Equals("name"))
                {
                    products = queryParameters.SortDescending ? products.OrderByDescending(p => p.Name) :
                        products.OrderBy(p => p.Name);
                }
            }

            return products
                .Skip((queryParameters.Page - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .ToList();
        }
    }
}
