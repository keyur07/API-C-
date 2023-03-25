using System;
namespace MyUserAPI.Models
{
	public class cartModel
	{
        public int cartid { get; set; }
        public int productid { get; set; }
        public virtual userModel? user { get; set; } = null!;
        public int userid { get; set; }
        public int quantities { get; set; }
    }
}

