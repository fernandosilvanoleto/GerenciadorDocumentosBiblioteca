using GerenciarDocumentos.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciarDocumentos.Models
{
    public class DocumentoContext : DbContext
    {
        public DocumentoContext(DbContextOptions<DocumentoContext> options) : base(options)
        {
        }
        public DbSet<Documento> Documentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}