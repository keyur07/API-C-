using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyUserAPI.Models
{
	public class commentModel
	{
        public int commentid { get; set; }

        public int userid { get; set; }
        public virtual productModel product { get; set; } = null!;

        public string? user { get; set; }
        public string? rating { get; set; }
        public string? text { get; set; }

        [Column(TypeName = "text")]
        public string? image { get; set; }
    }
}

