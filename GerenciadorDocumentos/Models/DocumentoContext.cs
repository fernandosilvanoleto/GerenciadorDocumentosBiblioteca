using GerenciadorDocumentos.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciarDocumentos.Models
{
    public class DocumentoContext : DbContext
    {
        public DocumentoContext(DbContextOptions<DocumentoContext> options) : base(options)
        {
        }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<LivroAutor> LivroAutors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* ESSA ABORDAGEM É MAIS SIMPLES
             modelBuilder.Entity<LivroAutor>()
                .HasKey(x => new { x.LivroId, x.AutorId });
             */
            // abordagem mais completa => definindo o relacionamento explicitamente
            modelBuilder.Entity<LivroAutor>()
                .HasOne(la => la.Livro)
                .WithMany(livro => livro.LivrosAutores)
                .HasForeignKey(la => la.LivroId);

            modelBuilder.Entity<LivroAutor>()
                .HasOne(la => la.Autor)
                .WithMany(autor => autor.LivrosAutores)
                .HasForeignKey(la => la.AutorId);
        }
    }
}