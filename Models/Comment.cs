namespace csBlogger.Models
{
  public class Comment
  {

    public string Content { get; set; }
    public int Id { get; set; }
    public int BlogId { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }



  }
}