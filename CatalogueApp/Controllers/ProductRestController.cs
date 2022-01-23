using CatalogueApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CatalogueApp.Controllers{
    [Route("/api/products")]
    public class ProductRestController:Controller{


        public CatalaogueDbRepository catalaogueRepository {get;set;}

        public ProductRestController(CatalaogueDbRepository repository){
            this.catalaogueRepository=repository;
        }

        [HttpGet]
        public IEnumerable<Product> findAll(){
            return catalaogueRepository.Products.Include(p=>p.Category);
        }
        [HttpGet("paginate")]
        public IEnumerable<Product> page(int page=0,int size=1){
            int skip=(page-1)*size;

            return catalaogueRepository.
            Products
            .Include(p=>p.Category)
            .Skip(skip)
            .Take(size);
        }
        [HttpGet("{Id}")]
        public Product getOne(int Id ){
            return catalaogueRepository.Products.Include(p=>p.Category)
            .FirstOrDefault(p=>p.ProductId==Id);
        }
         
        [HttpGet("search")]
        public IEnumerable<Product> search (string kw ){
            return 
            catalaogueRepository
            .Products
            .Include(p=>p.Category)
            .Where(p=>p.Name.Contains(kw));
        }
        [HttpPost]
        public Product save ([FromBody] Product Product){
             catalaogueRepository.Products.Add(Product);
             catalaogueRepository.SaveChanges();
             return Product;
        }
        [HttpPut("{Id}")]
        public Product update ([FromBody] Product Product,int Id){
             Product.ProductId=Id;
             catalaogueRepository.Products.Update(Product);
             catalaogueRepository.SaveChanges();
             return Product;
        }
        [HttpDelete("Id")]
        public void delete (int Id){
            Product Product= catalaogueRepository.Products.FirstOrDefault(p=>p.ProductId==Id);
             catalaogueRepository.Products.Remove(Product);
             catalaogueRepository.SaveChanges();
        }


    }
}