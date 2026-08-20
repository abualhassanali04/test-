# Product Catalog Console
---(generated with AI assistance)---

A simple in-memory product catalog management system built as a console application in C#. This project was built as Task 01 of the Switch developer training program (C#/.NET track).

## Overview

The application lets you manage products and categories entirely in memory (no database) through a menu-driven console interface. It demonstrates core C# and OOP concepts: classes, interfaces, encapsulation, collections, LINQ, and basic input validation.

## Features

1. **Add Category** — create a new category (Id is generated automatically)
2. **Add Product** — add a product under an existing category; if a product with the same name already exists, its stock is increased instead of creating a duplicate
3. **Display all information** — view all products and categories in a formatted table
4. **Display products by category** — filter and view products belonging to a chosen category
5. **Search product by name** — case-insensitive, partial-match search
6. **Update product** — edit an existing product's details by Id
7. **Remove product** — delete a product by Id, with a confirmation prompt
8. **Reports** (LINQ-based):
   - Total inventory value (price × stock, summed across all products)
   - Most expensive product
   - Out-of-stock products
   - Category statistics: number of products and average price per category
9. **Exit**

## Project Structure

```
ProductCatalogConsole/
├── Program.cs                  # Menu and user interaction only
├── Models/
│   ├── Product.cs              # Product entity (Id, Name, Price, Stock, CategoryId, CreatedAt)
│   └── Category.cs             # Category entity (Id, Name)
├── Services/
│   ├── ICatalogService.cs      # Contract for catalog operations
│   └── CatalogService.cs       # Business logic: add, search, update, remove, reports
└── Validation/
    └── Validation.cs           # Input validation helpers (safe int/decimal/string reads)
```

## Design Notes

- **Separation of concerns:** `Program.cs` only handles menu display and user input/output. All business logic (storage, validation of business rules, LINQ queries) lives in `CatalogService`.
- **Encapsulation:** Product and category lists are private fields inside `CatalogService`, accessed only through public methods — never exposed directly.
- **Auto-generated Ids:** Product and category Ids are assigned automatically by internal counters in `CatalogService`; the user never enters an Id when adding a new item.
- **Interface-based design:** `CatalogService` implements `ICatalogService`, so the console UI depends only on the interface — the same pattern that will carry over to a Web API + database in a future stage.
- **Safe input handling:** All numeric and string input goes through validation helpers that loop until a valid value is entered, so invalid input (letters instead of numbers, empty strings) never crashes the program.
- **Money handling:** All monetary values use `decimal`, not `double`, for accuracy.
- **Reports use LINQ only** — `Sum`, `OrderByDescending`, `Where`, `GroupBy`, `Average`, `Count` — no manual loops for calculations.

## How to Run

```bash
dotnet run
```

Follow the on-screen menu to add categories and products, then explore the search, update, and reporting features.

## Requirements

- .NET 10 SDK