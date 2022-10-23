using ApiTutorial.Model;
using ApiTutorial.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace ApiTutorial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PostController : ControllerBase
    {
        public static List<Post> _posts = new List<Post>(){
             new Post(1, "title 1", "Content 1"),
             new Post(2, "title 2", "Content 2")
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_posts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Post post = findPost(id);
            if (post == null) {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreatePostRequest request)
        {
            int newPostId = 1;
            Post? lastPost = _posts.MaxBy(i => i.Id);
            if (lastPost != null) { 
                newPostId = lastPost.Id + 1;
            }
            Post newPost = new Post(newPostId, request.Title, request.Content);
            _posts.Add(newPost);

            return Ok(newPost);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePostRequest request)
        {
            var post = findPost(id);
            if (post == null)
            {
                return NotFound();
            };

            foreach (Post item in _posts)
            {
                if (item.Id == id)
                {
                    post.Title = request.Title;
                    post.Content = request.Content;
                    break;
                }
            }

            return Ok(findPost(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var post = findPost(id);
            if (post == null) {
                return NotFound();
            };
            _posts.Remove(post);
            return Ok();
        }

        private Post? findPost(int id)
        {
            return _posts.Find(delegate (Post post){
                return post.Id == id;
            });
        }
    }
}

