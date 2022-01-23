using CatalogueApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CatalogueApp.Controllers{
    [Route("/api/categories")]
    public class CategoryRestController:Controller{


        public CatalaogueDbRepository catalaogueRepository {get;set;}

        public CategoryRestController(CatalaogueDbRepository repository){
            this.catalaogueRepository=repository;
        }

        [HttpGet]
        public IEnumerable<Category> listCats(){
            return catalaogueRepository.Categories;
        }
        [HttpGet("{Id}")]
        public Category getCat(int Id ){
            return catalaogueRepository.Categories.FirstOrDefault(c=>c.CategoryID==Id);
        }

        [HttpGet("{Id}/products")]
        public IEnumerable<Product> products (int Id ){
            Category category=catalaogueRepository.Categories.Include(c=>c.Products)
            .FirstOrDefault(c=>c.CategoryID==Id);
            return category.Products;
        }
       
        

        [HttpPost]
        public Category save ([FromBody] Category category){
             catalaogueRepository.Categories.Add(category);
             catalaogueRepository.SaveChanges();
             return category;
        }
        [HttpPut("{Id}")]
        public Category update ([FromBody] Category category,int Id){
             category.CategoryID=Id;
             catalaogueRepository.Categories.Update(category);
             catalaogueRepository.SaveChanges();
             return category;
        }
        [HttpDelete("Id")]
        public void delete (int Id){
            Category category= catalaogueRepository.Categories.FirstOrDefault(c=>c.CategoryID==Id);
             catalaogueRepository.Categories.Remove(category);
             catalaogueRepository.SaveChanges();
        }


    }
}