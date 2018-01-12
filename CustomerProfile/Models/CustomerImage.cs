using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerProfile.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string ImageName { get; set; }
    }
}