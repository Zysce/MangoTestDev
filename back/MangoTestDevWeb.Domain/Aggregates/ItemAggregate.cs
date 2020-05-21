namespace MangoTestDevWeb.Domain
{
  public class ItemAggregate : IAggregateRoot
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public byte[] Image { get; set; }

    public static ItemAggregate Create(int id, string title, string description, byte[] img)
    {
      return new ItemAggregate
      {
        Id = id,
        Title = title,
        Description = description,
        Image = img
      };
    }
  }
}
