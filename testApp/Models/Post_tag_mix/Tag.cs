using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.Models.Post_tag_mix
{
    public class Tag
    {
       
        public Tag()
        {
            PostTags = new HashSet<PostTag>();
        }
        public Tag(string tagName) : this()
        {
            TagName = tagName;
        }

        [Key]
        public int Id { get; set; }
        public string TagName { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
    }
}
