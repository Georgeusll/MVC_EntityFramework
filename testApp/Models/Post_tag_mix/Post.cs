using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.Models.Post_tag_mix
{
    public class Post
    {
        public Post()
        {
            PostTags = new HashSet<PostTag>();
        }
        public Post(string Title, string text) : this()
        {
            this.Title = Title;
            this.Text = text;
        }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
        
    }
}

