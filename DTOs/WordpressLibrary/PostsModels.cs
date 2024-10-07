using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.WordpressLibrary
{
    public class PostBase
    {
        public string Slug { get; set; }                          // Unique slug for the post
        public string Status { get; set; }                        // Post status (publish, future, draft, etc.)
        public string Title { get; set; }                         // Post title
        public string Content { get; set; }                       // Post content
        public int? Author { get; set; }                          // Optional author ID
        public string Excerpt { get; set; }                       // Optional post excerpt
        public int? FeaturedMedia { get; set; }                   // Optional featured media ID
        public string CommentStatus { get; set; } = "open";       // Optional comment status (open or closed)
        public string PingStatus { get; set; } = "open";          // Optional ping status (open or closed)
        public string Format { get; set; } = "standard";          // Optional post format (standard, aside, etc.)
        public Dictionary<string, string> Meta { get; set; } = new(); // Optional meta fields (key-value pairs)
        public bool? Sticky { get; set; }                         // Optional sticky flag
        public string Template { get; set; }                      // Optional theme file to use
        public int[] Categories { get; set; }                     // Optional category IDs
        public int[] Tags { get; set; }                           // Optional tag IDs
    }

    public class Post : PostBase
    {
        public int Id { get; set; }                    // Unique identifier for the post
        public DateTime Date { get; set; }             // Date when the post was published (site timezone)
        public DateTime DateGmt { get; set; }          // Date when the post was published (GMT)
        public DateTime Modified { get; set; }         // Date when the post was last modified
    }


    public class CreatePostRequest : PostBase
    {
        public DateTime? Date { get; set; }            // Optional: Date when the post is published (site timezone)
        public DateTime? DateGmt { get; set; }         // Optional: Date when the post is published (GMT)
        public string Password { get; set; }           // Optional: Password to protect content and excerpt
    }

    public class UpdatePostRequest : PostBase
    {
        public DateTime? Date { get; set; }            // Optional: Updated date when the post is published (site timezone)
        public DateTime? DateGmt { get; set; }         // Optional: Updated date when the post is published (GMT)
        public string Password { get; set; }           // Optional: Password to protect content and excerpt
    }

    public class DeletePostRequest
    {
        public int Id { get; set; }                    // Unique identifier for the post
        public bool Force { get; set; } = false;       // Optional: Whether to bypass Trash and force deletion
    }

}
