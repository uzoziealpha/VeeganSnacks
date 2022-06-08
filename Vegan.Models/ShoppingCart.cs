﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Models.Model;

namespace Vegan.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }


        public int MenuItemId { get; set;}
        [ForeignKey("MenuItemId")]

        public MenuItem MenuItem { get; set; }

        [Range(1, 100 , ErrorMessage = "Please select a count between 1 and 100")]
        public int Count { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
