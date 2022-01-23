using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogueApp.Models{
    public class Product{
        public int ProductId{get;set;}
        public string Name{get;set;}

        public double Price{get;set;} 
        public int CategoryId{get;set;}
        [ForeignKey("CategoryId")]
        public virtual Category Category {get;set;}
    }
}