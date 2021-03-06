﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2Project.Models;

namespace WebApi2Project.Controllers
{
    public class ProductsController : ApiController
    {
        // Define the product list
        List<Product> products = new List<Product>();

        public IEnumerable<Product> GetAllProducts()
        {
            GetProducts();
            return products;
        }

        private void GetProducts()
        {
            products.Add(new Product { Id = 1, Name = "Television", Category = "Electronic", Price = 82000 });
            products.Add(new Product { Id = 2, Name = "Refrigeration", Category = "Electronic", Price = 23000 });
            products.Add(new Product { Id = 3, Name = "Mobiles", Category = "Electronic", Price = 20000 });
            products.Add(new Product { Id = 4, Name = "Laptops", Category = "Electronic", Price = 45000 });
            products.Add(new Product { Id = 5, Name = "iPads", Category = "Electronic", Price = 67000 });
            products.Add(new Product { Id = 6, Name = "Toys", Category = "Gift Items", Price = 15000 });
        }

        public IEnumerable<Product> GetProducts(int selectedId)
        {
            if(products.Count() > 0)
            {
                return products.Where(p => p.Id == selectedId);
            }
            else
            {
                GetProducts();
                return products.Where(p => p.Id == selectedId);
            }
        }


        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}