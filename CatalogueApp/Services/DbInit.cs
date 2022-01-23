using System;
using CatalogueApp.Models;

namespace CatalogueApp.Services{
        public static class DbInit    {
            public static void initData(CatalaogueDbRepository catalaogueDb){
                Console.WriteLine("Data initialisation");
                catalaogueDb.Categories.Add(new Category{Name="Ordinateurs"});
                catalaogueDb.Categories.Add(new Category{Name="Imprimantes"});
                catalaogueDb.Products.Add(new Product{Name="Hp 560",Price=5600,CategoryId=1});
                catalaogueDb.Products.Add(new Product{Name="Dell latitude 560",Price=12000,CategoryId=1});
                catalaogueDb.Products.Add(new Product{Name="Razor Sphynx DD",Price=24000,CategoryId=1});
                catalaogueDb.Products.Add(new Product{Name="Hp Imprmante ddd",Price=2400,CategoryId=2});
                catalaogueDb.SaveChanges();
            }
        }
}