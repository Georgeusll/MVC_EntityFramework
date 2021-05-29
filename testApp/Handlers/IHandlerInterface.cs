using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testApp.Models.Post_tag_mix;

namespace testApp.Handlers
{
    public interface IHandlerInterface
    {
        Stash createPost(Stash post);
        Tag createTag(Tag tag);

        List<Post> GetPosts();
        Post GetPost(int id);
        List<Tag> GetTags();
        
        Post UpdatePost(UpdateStash post);

        List<PostTag> PostTagByPostId(int request);

        bool deletePost(int id);

        bool deleteTag(int id);

        

        

    }
}
