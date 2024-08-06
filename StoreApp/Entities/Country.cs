﻿using System.ComponentModel.DataAnnotations;

namespace StoreApp.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength =2)]
        public required string Name { get; set; }
        public virtual ICollection<City>? Cities { get; set; }
    }
}
