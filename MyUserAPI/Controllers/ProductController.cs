using System;
using Microsoft.AspNetCore.Mvc;
using MyUserAPI.Data;
using MyUserAPI.Models;

namespace MyUserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController :ControllerBase
    {
		
        private readonly DatabaseContext context;

        public ProductController(DatabaseContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<productModel> Get()
        {
            return context.Products;
        }

        [HttpGet("{productid}")]
        public productModel Get(int Id)
        {
            // return object or throw 404 error
            try
            {
                return context.Products.Find(Id);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        [HttpPost]
        public productModel Post([FromBody] productModel product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        [HttpPut("{productid}")]
        public productModel Put(int Id, [FromBody] productModel product)
        {
            var existingProduct = context.Products.Find(Id);
            existingProduct.description = product.description;
            existingProduct.image = product.image;
            existingProduct.pricing = product.pricing;
            existingProduct.shippingCost = product.shippingCost;
            existingProduct.shippingaddress = product.shippingaddress;
            context.SaveChanges();
            return existingProduct;
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            var product = context.Products.Find(Id);
            context.Products.Remove(product);
            context.SaveChanges();
        }   
    }
}

