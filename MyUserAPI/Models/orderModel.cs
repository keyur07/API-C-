using System;
namespace MyUserAPI.Models
{
	public class orderModel
	{
        public int orderid { get; set; }

        public virtual productModel? Product { get; set; } = null!;

        public int userid { get; set; }


        public int? invoiceno { get; set; }
        public string? image { get; set; }

        public int quantity { get; set; }
        public int price { get; set; }

        public int tax { get; set; }
        public int ratting { get; set; }
        public int payment { get; set; }

        // public DateTime CreatedAt { get; set; }
    }
}

