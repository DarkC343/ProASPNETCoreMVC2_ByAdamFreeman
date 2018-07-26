using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpLanguageFeatures.Models;

namespace CSharpLanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View(new string[] { "C#", "Language", "Features" });
        }
        public ViewResult NullConditionalOperator()
        {
            List<String> results = new List<string>();

            foreach (var prod in Product.GetProducts())
            {
                // {{LANGUAGE FEATURE}} Null conditonal operator can avoid to face NullReferenceException. If the value was null, the variable will set to null without any error from obtaining. Otherwise, the value will be sat to the prod.Name or prod.Price
                string Name = prod?.Name;
                decimal? Price = prod?.Price;
                string RelatedName = prod?.Related?.Name;
                // {{LANGUAGE FEATURE}} String interpolation: starts with dollar sign and it is an easier way of approaching the result from the traditional one which pattern was string.Format({0}, Value)
                // {{LANGUAGE FEATURE}} Getting names of properties, class name, method names using the method nameof() can prevent typos and hard-coding
                results.Add(string.Format($"{nameof(Name)}: {Name}, {nameof(Price)}: {Price}, {nameof(RelatedName)}: {RelatedName}"));
            }
            return View(results);
        }
        public ViewResult CombiningConditionalAndCoalescingOperators()
        {
            List<string> results = new List<string>();

            foreach (var prod in Product.GetProducts())
            {
                // {{LANGUAGE FEATURE}} Coalescing operators are used when we want to set a fallback (alternative) values to present null values
                string Name = prod?.Name ?? "<NO_NAME>";
                decimal? Price = prod?.Price ?? 0M;
                string RelatedName = prod?.Related?.Name ?? "<NONE>";
                results.Add(string.Format($"{nameof(Name)}: {Name}, {nameof(Price)}: {Price}, {nameof(RelatedName)}: {RelatedName}"));
            }
            return View(results);
        }
        public ViewResult AutoImplementedPropertyInitializer()
        {
            List<String> list = new List<string>();
            foreach (var laptop in Laptop.GetLaptops())
            {
                string Brand = laptop?.Brand ?? "<No Brand>";
                string Model = laptop?.Model ?? "<No Model>";
                decimal? Price = laptop?.Price ?? 0M;
                string Category = laptop?.Category ?? "<No Category>";
                bool InStock = laptop?.InStock ?? false;
                list.Add(string.Format($"{nameof(Brand)}: {Brand}, " +
                    $"{nameof(Model)}: {Model}, " +
                    $"{nameof(Price)}: {Price}, " +
                    $"{nameof(Category)}: {Category}, " +
                    $"{nameof(InStock)}: {InStock}"
                ));
            }
            return View(list);
        }
        public ViewResult PatternMatching()
        {
            decimal total = 0;
            string myString = "";
            object[] list = new object[] { "Hi", "apple", "Ashly", 430, 290M, 20, 10M, new List<decimal> { 1M, 2M } };
            foreach (var data in list)
            {
                // {{LANGUAGE FEATURE}} Pattern matching using if/else: 'is' keyword checks whether the variable is of the desired type, if yes the variable is assigned to another variable
                if (data is decimal d)
                {
                    total += d;
                }
                else if (data is IEnumerable<decimal> dec)
                {
                    foreach (var item in dec)
                    {
                        total += item;
                    }
                }
            }
            foreach (var data in list)
            {
                switch (data)
                {
                    // {{LANGUAGE FEATURE}} Pattern matching using switch/case: does the some as above, however 'when' keyword adds condition where the output should be of type boolean
                    case string s when s.ToLower().StartsWith('a'):
                        myString += string.Format($"string {nameof(data)} is {s}, ");
                        break;
                    case int i when i > 15:
                        myString += string.Format($"int {nameof(data)} is {i}, ");
                        break;
                    case IEnumerable<decimal> enumDec:
                        foreach (var item in enumDec)
                        {
                            myString += string.Format($"decimal item from decimal list is {item}, ");
                        }
                        break;
                }
            }
            return View(new object[] { total, myString });
        }
        public ViewResult UsingExtenionMethodsPart1()
        {
            ShoppingCart cart = new ShoppingCart() { Laptops = Laptop.GetLaptops() };
            // If we didn't cast the result to object, the following code will be go to the view with the of the result :)
            return View((object)string.Format($"The price will be {cart.TotalPrices()}"));
        }
        public ViewResult AnonymousType()
        {
            var DiskStorages = new[] { new { HDD = 128 }, new { HDD = 256 }, new { HDD = 512 }, new { HDD = 1024 }, new { HDD = 2048 } };
            return View(DiskStorages.Where(p => p.HDD >= 300).Select(s => s.HDD));
        }
        public async Task<ViewResult> UsingAsync()
        {
            MyAsyncMethods myAsync = new MyAsyncMethods();
            long length = await myAsync?.GetPageLength() ?? 0;
            return View(length);
        }
    }
}
