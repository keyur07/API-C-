using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyUserAPI.Models
{
	public class productModel
	{
		//public productModel()
		//{
           // this.comments = new HashSet<commentModel>();
        //}

        public int productid { get; set; }
        public string? description { get; set; } = null!;

        [Column(TypeName = "text")]
        public string? image { get; set; }

        [Column(TypeName = "decimal(20,5)")]
        public decimal pricing { get; set; }

        [Column(TypeName = "decimal(20,5)")]
        public decimal shippingCost { get; set; }

        public string? shippingaddress { get; set; }

        //public virtual ICollection<commentModel>? comments { get; set; }
    }
}

