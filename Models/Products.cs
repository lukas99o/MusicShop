using System.ComponentModel.DataAnnotations.Schema;

namespace MusicShop.Models
{
    public class Products
    {

        public int Id { get; set; } 

        public string Name { get; set; }    


        public string Description { get; set; } 


        public string ImageUrl { get; set; }    


        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]

        public Categorey Categorey { get; set; }

  }
}
