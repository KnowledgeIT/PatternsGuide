Scaffold-DbContext "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Src\KiT\PatternsGuide\Sales.Infrastructure\Sql\Sales.mdf;Integrated Security=True;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -Context Context -ContextDir C:\Src\KiT\PatternsGuide\Sales.Infrastructure\Contexts -OutputDir C:\Src\KiT\PatternsGuide\Sales.Model\Entities -ContextNamespace Sales.Infrastructure.Contexts -Namespace Sales.Model.Entities -NoPluralize -DataAnnotations -UseDatabaseNames -Force -NoOnConfiguring -Tables Category, CategoryTax, Item, ItemCategory, ItemPrice, Order, OrderItem, Tax