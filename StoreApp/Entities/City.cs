using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApp.Entities
{
   // [Table("Cities", Schema ="dboo")]
    public class City
    { 

        //[Key] Auto increment
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength =2)]
        [Column("NAME")]
        public required string Name { get; set; }

        
        [StringLength(100, MinimumLength = 2)]
        public  string? AlterName { get; set; }

        //[NotMapped]
        //public string Test { get; set; }


        // Column -> CountryId

        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country? Country { get; set; }
    }
}
