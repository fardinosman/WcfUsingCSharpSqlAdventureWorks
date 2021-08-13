using ProductInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFProductService" in both code and config file together.
    public class WCFProductService : IWCFProductService
    {
        public ProductData GetProduct(string productNumber)
        {
            ProductData productData = null;
            try
            {
                using (adventureworksEntities database = new adventureworksEntities())
                {
                    product matchingProduct = database.product.First((p) => p.ProductNumber == productNumber);

                    productData = new ProductData();
                    productData.Name = matchingProduct.Name;
                    productData.ProductNumber = matchingProduct.ProductNumber;
                    productData.ListPrice = matchingProduct.ListPrice;
                    productData.Color = matchingProduct.Color;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return productData;
        }

        public List<string> ListProducts()
        {
            Console.WriteLine("Listproduct() has been called by a client");
            List<string> productslist = new List<string>();
            try
            {
                using(adventureworksEntities database = new adventureworksEntities())
                {
                    //other way to do that
                    //foreach (var p in database.product)
                    //{
                    //    productslist.Add(p.ProductNumber);
                    //}

                    //Linq
                    var products = from p in database.product
                                   select p.ProductNumber;
                    productslist = products.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return productslist;
        }
    }
}
