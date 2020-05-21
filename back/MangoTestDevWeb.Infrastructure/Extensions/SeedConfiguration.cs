using System.Collections.Generic;
using MangoTestDevWeb.Domain;
using Microsoft.EntityFrameworkCore;

namespace MangoTestDevWeb.Infrastructure.Extensions
{
  public static class SeedConfiguration
  {
    public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
    {
      var assembly = typeof(SeedConfiguration).Assembly;
      var embeddedImgs = assembly.GetManifestResourceNames();
      var list = new List<ItemAggregate>();
      int count = 1;

      foreach (var embeddedImg in embeddedImgs)
      {
        using (var stream = assembly.GetManifestResourceStream(embeddedImg))
        {
          byte[] img = new byte[stream.Length];
          stream.Read(img, 0, (int)stream.Length);
          list.Add(ItemAggregate.Create(count, $"img {count}", $"desc {count}", img));
        }
        count++;
      }
      modelBuilder.Entity<ItemAggregate>(b =>
      {
        b.HasData(list);
      });

      return modelBuilder;
    }
  }
}
