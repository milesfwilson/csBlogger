namespace csBlogger.Models
{
  public class Blog
  {
    public string Title { get; set; }
    public bool IsPublished { get; set; }
    public string Content { get; set; }
    public int Id { get; set; }

    public string CreatorId { get; set; }
    public Profile Creator { get; set; }

  }
}