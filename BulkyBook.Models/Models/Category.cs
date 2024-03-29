﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookModels.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be in a range from 1 to 100")]
        public int DisplayOrder { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
