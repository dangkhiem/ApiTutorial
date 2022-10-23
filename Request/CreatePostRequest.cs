using System.ComponentModel.DataAnnotations;

namespace ApiTutorial.Request;

public class CreatePostRequest
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

}