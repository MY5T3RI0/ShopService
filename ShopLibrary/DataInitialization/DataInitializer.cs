using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ShopDAL.Models;
using ShopDAL.EF;

namespace ShopDAL.DataInitialization
{
    public class DataInitializer
    {
        public static void InitializeData(ShopContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var Customers = new List<Customer>
            {
                new Customer {Name = "Dave"},
                new Customer {Name ="Mike" },
                new Customer {Name = "Matt"},
                new Customer {Name ="Steve"},
                new Customer {Name ="Johj"},
                new Customer {Name ="Ann"},
                new Customer {Name ="Lucy"},
                new Customer {Name ="Johsh"},
                new Customer {Name ="Endrew"},
                new Customer {Name ="Phillip"},
                new Customer {Name ="Pit", }
            };

            Customers.ForEach(x => context.Customers.Add(x));
            context.SaveChanges();

            var Categories = new List<Category>
            {
                new Category {Name = "Electronics"},
                new Category {Name = "Cloves"},
                new Category {Name = "Furniture"},
                new Category {Name = "Other"}
            };

            Categories.ForEach(x => context.Categories.Add(x));
            context.SaveChanges();

            var Manufacturers = new List<Manufacturer>
            {
                new Manufacturer {Name = "Toytota"},
                new Manufacturer {Name = "Pepsico"},
                new Manufacturer {Name = "Ikea"},
                new Manufacturer {Name = "Tesla"}
            };

            Manufacturers.ForEach(x => context.Manufacturers.Add(x));
            context.SaveChanges();

            var Products = new List<Product>
            {
                new Product {Name = "TV",
                    Manufacturer = Manufacturers[new Random().Next(0, 4)],
                    Category = Categories[new Random().Next(0, 4)],
                    Price = new Random().Next(100,10000),
                },
                new Product {Name = "Trousers",
                    Manufacturer = Manufacturers[new Random().Next(0, 4)],
                    Category = Categories[new Random().Next(0, 4)],
                    Price = new Random().Next(100,10000),
                },
                new Product {Name = "Table",
                    Manufacturer = Manufacturers[new Random().Next(0, 4)],
                    Category = Categories[new Random().Next(0, 4)],
                    Price = new Random().Next(100,10000),
                },
                new Product {Name = "Radio",
                    Manufacturer = Manufacturers[new Random().Next(0, 4)],
                    Category = Categories[new Random().Next(0, 4)],
                    Price = new Random().Next(100, 10000),
                },
                new Product {Name = "Boots",
                    Manufacturer = Manufacturers[new Random().Next(0, 4)],
                    Category = Categories[new Random().Next(0, 4)],
                    Price = new Random().Next(100, 10000),
                },
                new Product {Name = "Chair",
                    Manufacturer = Manufacturers[new Random().Next(0, 4)],
                    Category = Categories[new Random().Next(0, 4)],
                    Price = new Random().Next(100, 10000),
                },
                new Product {Name = "Gum",
                    Manufacturer = Manufacturers[new Random().Next(0, 4)],
                    Category = Categories[new Random().Next(0, 4)],
                    Price = new Random().Next(100, 10000),
                },
                new Product {Name = "Phone",
                    Manufacturer = Manufacturers[new Random().Next(0, 4)],
                    Category = Categories[new Random().Next(0, 4)],
                    Price = new Random().Next(100, 10000),
                },
                new Product {Name = "Dress",
                    Manufacturer = Manufacturers[new Random().Next(0, 4)],
                    Category = Categories[new Random().Next(0, 4)],
                    Price = new Random().Next(100, 10000),
                },
                new Product {Name = "Dishwasher",
                    Manufacturer = Manufacturers[new Random().Next(0, 4)],
                    Category = Categories[new Random().Next(0, 4)],
                    Price = new Random().Next(100, 10000),
                },
                new Product {Name = "Paper",
                    Manufacturer = Manufacturers[new Random().Next(0, 4)],
                    Category = Categories[new Random().Next(0, 4)],
                    Price = new Random().Next(100, 10000),
                }
            };

            Products.ForEach(x => context.Products.Add(x));
            context.SaveChanges();

            var PriceChanges = new List<PriceChange>();
            for (int i = 0; i < 10; i++) PriceChanges.Add(
                new PriceChange
                {
                    DateOfChange = DateOnly.FromDateTime(DateTime.Now.AddDays(new Random().Next(0, 365))),
                }
            );
            PriceChanges.ForEach(x => context.PriceChanges.Add(x));
            context.SaveChanges();

            var ChangesDetails = new List<ChangesDetails>();
            for (int i = 0; i < 10; i++) ChangesDetails.Add(
                new ChangesDetails
                {
                    Product = Products[new Random().Next(0, 10)],
                    NewPrice = Products[new Random().Next(0, 10)].Price * (decimal)(2 * new Random().NextDouble()),
                    PriceChange = PriceChanges[new Random().Next(0, 10)]
                }
            );

            ChangesDetails.ForEach(x => context.ChangesDetails.Add(x));
            context.SaveChanges();

            var Stores = new List<Store>
            {
                new Store {
                    Name = "KPK-energy"
                },
                new Store {
                    Name = "STORE-Service"
                },
                new Store {
                    Name = "Your Store"
                },
                new Store {
                    Name = "Mineral Trade"
                }
            };

            Stores.ForEach(x => context.Stores.Add(x));
            context.SaveChanges();

            var ProductsInStore = new List<ProductsInStore>();
            for (int i = 0; i < 10; i++) ProductsInStore.Add(
                new ProductsInStore
                {
                    Product = Products[new Random().Next(0, 10)],
                    Count = new Random().Next(0, 100),
                    Store = Stores[new Random().Next(0, 4)]
                }
            );

            ProductsInStore.ForEach(x => context.ProductsInStore.Add(x));
            context.SaveChanges();

            var Purchases = new List<Purchase>();
            for (int i = 0; i < 10; i++) Purchases.Add(
                new Purchase
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(new Random().Next(0, 365))),
                    Customer = Customers[new Random().Next(0, 10)]
                }
            );
            Purchases.ForEach(x => context.Purchases.Add(x));
            context.SaveChanges();

            var StoreProducts = new List<StoreProducts>();
            for (int i = 0; i < 10; i++) StoreProducts.Add(
                new StoreProducts
                {
                    Store = Stores[new Random().Next(0, 4)],
                    Purchase = Purchases[new Random().Next(0, 10)],
                }
            );

            StoreProducts.ForEach(x => context.StoreProducts.Add(x));
            context.SaveChanges();

            var PurchaseDetailses = new List<PurchaseDetails>();
            for (int i = 0; i < 10; i++) PurchaseDetailses.Add(
                new PurchaseDetails
                {
                    Product = Products[new Random().Next(0, 10)],
                    ProductCount = new Random().Next(0, 100),
                    Discount = new Random().Next(0, 50),
                    StoreProducts = StoreProducts[new Random().Next(0, 10)]
                }
            );
            PurchaseDetailses.ForEach(x => context.PurchaseDetailses.Add(x));
            context.SaveChanges();

            var Deliveries = new List<Delivery>();
            for (int i = 0; i < 10; i++) Deliveries.Add(
                new Delivery
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(new Random().Next(0, 365))),
                    Store = Stores[new Random().Next(0, 4)],
                }
            );
            Deliveries.ForEach(x => context.Deliveries.Add(x));
            context.SaveChanges();

            var DeliveryInfos = new List<DeliveryInfo>();
            for (int i = 0; i < 10; i++) DeliveryInfos.Add(
                new DeliveryInfo
                {
                    Product = Products[new Random().Next(0, 10)],
                    ProductCount = new Random().Next(0, 100),
                    Delivery = Deliveries[new Random().Next(0, 10)]
                }
            );
            DeliveryInfos.ForEach(x => context.DeliveryInfos.Add(x));
            context.SaveChanges();

        }

        public static void RecreateDatabase(ShopContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Database.EnsureDeleted();
            context.Database.Migrate();

        }

        public static void ClearData(ShopContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            ExecuteDeleteSql(context, "Category");
            ExecuteDeleteSql(context, "StoreProducts");
            ExecuteDeleteSql(context, "Customer");
            ExecuteDeleteSql(context, "Delivery");
            ExecuteDeleteSql(context, "Store");
            ExecuteDeleteSql(context, "Manufacturer");
            ExecuteDeleteSql(context, "PriceChange");
            ExecuteDeleteSql(context, "Product");
            ExecuteDeleteSql(context, "Purchase");
            ExecuteDeleteSql(context, "PurchaseDetails");
            ExecuteDeleteSql(context, "ChangeDetails");
            ExecuteDeleteSql(context, "DeliveryInfo");
            ExecuteDeleteSql(context, "ProductsInStore");
            Resetldentity(context);

        }

        private static void ExecuteDeleteSql(ShopContext context, string tableName)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentException($"\"{nameof(tableName)}\" не может быть неопределенным или пустым.", nameof(tableName));
            }

            var rawSqlString = $"Delete from dbo.{tableName}";
            context.Database.ExecuteSqlRaw(rawSqlString);
        }
        private static void Resetldentity(ShopContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var tables = new[] {
                "Category",
                "StoreProducts",
                "Customer",
                "Delivery",
                "Store",
                "Manufacturer",
                "PriceChange",
                "Product",
                "Purchase",
                "PurchaseDetails",
                "DeliveryInfo",
                "ProductsInStore"
            };
            foreach (var itm in tables)
            {
                var rawSqlString = $"DBCC CHECKIDENT (\"dbo.{itm}\", RESEED, -1);";
                context.Database.ExecuteSqlRaw(rawSqlString);
            }
        }
    }
}
