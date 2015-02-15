using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace DogOnline.Models
{
    public class Details
    {
        public int DetailsId { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public string Gender { get; set; }

        public string Age { get; set; }

        public string Location{ get; set; }

        public string Contact{ get; set; }

        public byte[] Image { get; set; }

        public string ImageFileName { get; set; }

    }
}