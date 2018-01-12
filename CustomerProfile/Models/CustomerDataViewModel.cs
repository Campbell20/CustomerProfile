using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerProfile.Models
{
    public class CustomerDataViewModel
    {
        public CustomerData CustomerDatas { get; set; }
        public CustomerImage CustomerImages { get; set; }

        //[Required, FileExtensions(Extensions = "jpg,gif,png",
        //    ErrorMessage = "Specify a file")]
        //[Required]
        public HttpPostedFileBase File { get; set; }
    }
}