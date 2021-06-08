using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetCoreRepositoryAndUnitOfWorkPattern.Data.Models
{
    public partial class TextDbContext : DbContext
    {
        public TextDbContext()
        {
        }

        public TextDbContext(DbContextOptions<TextDbContext> options)
            : base(options)
        {

            this.Text.Add(new Text { Id = 1, Content = "Potrebno je napraviti klijent aplikaciju (Console, Wpf, Angular... )koja ce da cita tekst na tri nacina iz File-a, baze ili sam korisnik unosi tekst. Tekst treba da se posalje na server (REST ili WCF) koji ce da izracuna broj reci u tekstu i posalje odgovor na klijent aplikaciju koja ce rezultat obrade prikazati klijentu. Fokus zadatka jeste na aritekturi i pattern-ima, i primeni tog znanja na zadatak - n-tier, SOA, Dependency Injection, Factory, Repository i slično. Koriscenje third party biblioteka je dozvoljeno." });
            this.Text.Add(new Text { Id = 2, Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry" });
            this.Text.Add(new Text { Id = 3, Content = "Lorem Ipsum has been the industrys standard dummy text ever since the 1500s" });
            this.Text.Add(new Text { Id = 4, Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." });
            this.Text.Add(new Text { Id = 5, Content = "Lorem Ipsum " });
            this.Text.Add(new Text { Id = 6, Content = "Lorem Ipsum is simply dummy text " });
            this.Text.Add(new Text { Id = 7, Content = "Lorem    Ipsum    is simply    dummy    text    of the printing and typesetting industry" });
            this.SaveChanges();
        }

        public virtual DbSet<Text> Text { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
