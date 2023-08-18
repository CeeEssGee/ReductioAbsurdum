using System.ComponentModel;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Wizard's Wand",
        Price = 25.00M,
        Available = true,
        ProductTypeId = 4,
        DateStocked = new DateTime(2022, 03, 22)
    },
    new Product()
    {
        Name = "Witch's Hat",
        Price = 15.00M,
        Available = true,
        ProductTypeId = 1,
        DateStocked = new DateTime(2023, 01, 15)
    },
    new Product()
    {
        Name = "Grimoire",
        Price = 35.00M,
        Available = true,
        ProductTypeId = 3,
        DateStocked = new DateTime(2020, 10, 31)
    },
    new Product()
    {
        Name = "Truth Tablet",
        Price = 50.00M,
        Available = true,
        ProductTypeId = 2,
        DateStocked = new DateTime(2023, 08, 01)
    },
    new Product()
    {
        Name = "Health Elixir",
        Price = 30.00M,
        Available = true,
        ProductTypeId = 2,
        DateStocked = new DateTime(2023, 08, 15)
    },
    new Product()
    {
        Name = "Sorceror's Robe",
        Price = 40.00M,
        Available = false,
        ProductTypeId = 1,
        DateStocked = new DateTime(2022, 02, 25)
    }
};

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Id = 1,
        Name = "Apparel"
    },
    new ProductType()
    {
        Id = 2,
        Name = "Potion"
    },
    new ProductType()
    {
        Id = 3,
        Name = "Enchanted Object"
    },
    new ProductType()
    {
        Id = 4,
        Name = "Wand"
    }
};

string greeting = @"Welcome to Reductio & Absurdum!
Where wizards, warlocks, and witches have been buying high-quality magical supplies for nearly 1000 years.";

Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
    0. Exit
    1. View all products
    2. Add a product to inventory
    3. Delete a product from inventory
    4. Update a product's details
    5. Look up a product by product type");

    choice = Console.ReadLine().Trim();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        DisplayAllProducts();
    }
    else if (choice == "2")
    {
        AddProduct();
    }
    else if (choice == "3")
    {
        DeleteProduct();
    }
    else if (choice == "4")
    {
        UpdateProduct();
    }
    else if (choice == "5")
    {
        LookUpByType();
    }
}

void DisplayAllProducts()
{
    Console.WriteLine("All Products: ");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {ProductDetails(products[i])}");
    }
}

void AddProduct()
{
    Console.WriteLine("Please enter the product name");
    string postName = Console.ReadLine().Trim();
    Console.WriteLine("Please enter the price");
    decimal postPrice = decimal.Parse(Console.ReadLine());
    Console.WriteLine("Please enter the 4-digit year added to inventory");
    int postYear = int.Parse(Console.ReadLine());
    Console.WriteLine("Please enter the 1- or 2-digit month added to inventory");
    int postMonth = int.Parse(Console.ReadLine());
    Console.WriteLine("Please enter the 1- or 2-digit day added to inventory");
    int postDay = int.Parse(Console.ReadLine());
    DateTime postDateStocked = new DateTime(postYear, postMonth, postDay);
    Console.WriteLine(@"Please enter the product type by number
1 = Apparel
2 = Potion
3 = Enchanted Object
4 = Wand");
    int postProductType = int.Parse(Console.ReadLine());

    products.Add(new Product()
    {
        Name = postName,
        Price = postPrice,
        DateStocked = postDateStocked,
        ProductTypeId = postProductType,
        Available = true
    });

    Console.WriteLine($"Your {postName} has successfully been added!");
}

void DeleteProduct()
{
    Console.WriteLine(@"Products: 
Please enter the product number for the product you wish to delete from inventory:");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {ProductDetails(products[i])}");
    }
    int deletedProduct = int.Parse(Console.ReadLine());

    products.RemoveAt(deletedProduct - 1);
}

// Select to generate the string
void UpdateProduct()
{
    Console.WriteLine(@"Plants: 
Please enter the product number for the product you wish to update:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {ProductDetails(products[i])}");
    }
    int updatedPlant = int.Parse(Console.ReadLine());

    Console.WriteLine("Please enter the product name");
    string updatedName = Console.ReadLine().Trim();
    Console.WriteLine("Please enter the price");
    decimal updatedPrice = decimal.Parse(Console.ReadLine());
    Console.WriteLine("Please enter the availability as true (if available) or false (if unavailable)");
    bool updatedAvailability = bool.Parse(Console.ReadLine());
    Console.WriteLine("Please enter the 4-digit year added to inventory");
    int postYear = int.Parse(Console.ReadLine());
    Console.WriteLine("Please enter the 1- or 2-digit month added to inventory");
    int postMonth = int.Parse(Console.ReadLine());
    Console.WriteLine("Please enter the 1- or 2-digit day added to inventory");
    int postDay = int.Parse(Console.ReadLine());
    DateTime updatedDateStocked = new DateTime(postYear, postMonth, postDay);
    Console.WriteLine(@"Please enter the updated product type by number:
1 = Apparel
2 = Potion
3 = Enchanted Object
4 = Wand");
    int updatedType = int.Parse(Console.ReadLine());

    products[updatedPlant - 1].Name = updatedName;
    products[updatedPlant - 1].Price = updatedPrice;
    products[updatedPlant - 1].Available = updatedAvailability;
    products[updatedPlant - 1].DateStocked = updatedDateStocked;
    products[updatedPlant - 1].ProductTypeId = updatedType;
}

void LookUpByType()
{
    List<Product> ProductsByType = new List<Product>();

    Console.WriteLine(@"Please enter the product type by number:
1 = Apparel
2 = Potion
3 = Enchanted Object
4 = Wand");
    int userType = int.Parse(Console.ReadLine());
    // where and select
    foreach (Product product in products)
        if (product.ProductTypeId == userType)
        {
            ProductsByType.Add(product);
        }

    foreach (Product product in ProductsByType)
    {
        Console.WriteLine($"{ProductDetails(product)}");
    }

}


string ProductDetails(Product product)
{

    ProductType productTypeName = productTypes.FirstOrDefault(type => product.ProductTypeId == type.Id);

    string productString = $"{product.Name} {(product.Available ? "is available" : "was sold")} for ${product.Price}, was stocked {product.DaysOnShelf} days ago, and is categorized as type: {productTypeName.Name}";

    return productString;
}

