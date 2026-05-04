namespace gymblog1.Migrations
{
    using gymblog1.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<gymblog1.Models.IdentityModels.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "gymblog1.Models.ApplicationDbContext";
        }

        protected override void Seed(gymblog1.Models.IdentityModels.ApplicationDbContext context)
        {
            context.Posts.AddOrUpdate(p => p.Title,
          new Post
          {
              Title = "Moj prvi Bench Press rekord",
              Content = "Danas sam konačno podigao 100kg! Trening je bio naporan ali se isplatilo. Fokus je bio na pravilnoj formi i disanju.",
              CreatedAt = DateTime.Now
          },
          new Post
          {
              Title = "Plan ishrane za definiciju",
              Content = "Trenutno sam na 2500 kalorija. Cilj je 180g proteina i preko 250g hidrata dnevno. Jaja i ovsene su osnova doručka.",
              CreatedAt = DateTime.Now.AddDays(-1)
          },
          new Post
          {
              Title = "Leg Day & Ramena - Brutalan trening",
              Content = "Danas smo radili čučanj, leg press i military press. Fokus je bio na kontrolisanom negativnom ponavljanju. Energija na vrhuncu!",
              CreatedAt = DateTime.Now.AddDays(-5),
              ImagePath = "/images/legs.jpg"
          },
        new Post
        {
            Title = "Doručak šampiona: Jaja i ovsene",
            Content = "Standardna rutina se vraća. 4 cela jaja i 80g ovsenih pahuljica. Savršen balans masti i sporih hidrata za početak dana.",
            CreatedAt = DateTime.Now.AddDays(-3),
            ImagePath = "/images/breakfast.jpg"
        },
        new Post
        {
            Title = "Kako uneti 180g proteina svaki dan?",
            Content = "Mnogi me pitaju kako stižem do 180g proteina. Ključ je u pripremi: piletina, jaja, whey i posni sir su moji najbolji prijatelji.",
            CreatedAt = DateTime.Now.AddDays(-2),
            ImagePath = "/images/protein.jpg"
        },
        new Post
        {
            Title = "Upper Body - Fokus na grudi i leđa",
            Content = "Danas smo radili zgibove i kosi bench. Osećaj pumpe je bio neverovatan. Sutra je dan za odmor i punjenje hidratima.",
            CreatedAt = DateTime.Now.AddDays(-1),
            ImagePath = "/images/upper.jpg"
        },
        new Post
        {
            Title = "Problem sa 250g hidrata - Rešenje",
            Content = "Nekada je teško pojesti preko 250g hidrata, ali pirinač i krompir čine čuda. Bitno je ne preskakati obroke!",
            CreatedAt= DateTime.Now,
            ImagePath = "/images/carbs.jpg"
        }
      );
        }
    }
}
