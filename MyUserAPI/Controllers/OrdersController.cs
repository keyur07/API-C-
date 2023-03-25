using System;
using Microsoft.AspNetCore.Mvc;
using MyUserAPI.Data;
using MyUserAPI.Models;

namespace MyUserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController :ControllerBase
	{
        private readonly DatabaseContext context;

        public OrdersController(DatabaseContext context)
        {
            this.context = context;
        }


        private string GetRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;

        }

        //[HttpGet]
        //public IEnumerable<Order> Get()
        //{
        //    return context.Orders;
        //}

        [HttpGet("{orderid}")]
        public orderModel Get(int Id)
        {
            // return object or throw 404 error
            try
            {
                var order = context.Order.Find(Id);
                order.Product = context.Products.Find(order.ProductId);
                return order;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        //find order by user id
        [HttpGet()]
        public IEnumerable<orderModel> GetOrderByUID([FromQuery] int userID)
        {
            // return object or throw 404 error
            try
            {
                //var userID = int.Parse( HttpContext.Request.Query["user_id"]);
                var data = context.Order.Where((o) => o.UserID == userID);

                foreach (var d in data)
                {
                    d.Product = context.Products.Find(d.ProductId);
                }

                return data;
            }

            catch (Exception e)
            {
                return null;
            }

        }


        [HttpPost]
        public orderModel Post([FromBody] orderModel order)
        {
            order.CreatedAt = DateTime.Now;
            order.BillNo = GetRandomString();
            order.Status = 0;

            context.Order.Add(order);
            context.SaveChanges();
            return order;
        }
    }
}

