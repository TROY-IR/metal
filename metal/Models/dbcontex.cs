using Microsoft.EntityFrameworkCore;
using metal.Domain.Entities.posters;
//db set
public class AppDbContext //: DbContext
{
  //  public AppDbContext(DbContextOptions<AppDbContext> op) { }

  //  public DbSet<Poster> posters0 { get; set; }

 //   public DbSet<Poster1> posters1 { get; set; }

 //   public DbSet<element1> element1 { get; set; }

  //  public DbSet<element2> elemen2 { get; set; }

  //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  //  {
  //      optionsBuilder.UseSqlServer(@"Server=Ahmadreza\MYDB;Database=metalposters;Trusted_Connection=True;TrustServerCertificate=True;");
  //  }

    public List<element1> Element1s { get; set; }
}
