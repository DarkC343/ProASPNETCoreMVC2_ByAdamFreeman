using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpLanguageFeatures.Models
{
    public class Laptop
    {
        public Laptop(bool TrueOrFalse = true)
        {
            InStock = TrueOrFalse;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        // {{LANGUAGE FEATURE}} Auto-implemented property inintializer allows us to set a defaul value to property which can be set later with different value. Otherwise, the default value will be set for the property of the object without mentioning the property in object defenition
        public decimal? Price { get; set; } = 0M;
        public string Category { get; set; } = "Multimedia";
        // {{LANGUAGE FEATURE}} Read-only auto-implemeted property can be assigned through the constructor and there is no other way to do so. The following property is also initialized through auto-implemented property inintializer feature
        public bool InStock { get; } = true;

        public static Laptop[] GetLaptops()
        {
            // {{LANGUAGE FEATURE}} Object initializer let us specify the properties of an object in a single line. 
            Laptop dellXps = new Laptop { Brand = "Dell", Model = "XPS", Price = 1500M };
            Laptop dellG = new Laptop(false) { Brand = "Dell", Model = "G", Price = 2000M, Category = "Gaming" };
            // {{LANGUAGE FEATURE}} Collection initializer makes it possible to define a collection inline. In this case, returning a list doesn't require to make a list in previos lines and then returning the list via it's nme
            return new Laptop[] { dellXps, dellG, null };
        }
    }
}
