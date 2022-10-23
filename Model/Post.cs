namespace ApiTutorial.Model;

public class Post
{
    public Post(int id, string title, string content)
    {
        Id = id;
        Title = title;
        Content = content;
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }
}

