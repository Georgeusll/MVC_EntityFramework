using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testApp.Context;
using testApp.Models.Post_tag_mix;

namespace testApp.Handlers
{
    public class Handler : IHandlerInterface
    {
        private UserConnect _userConnect;


        public Handler(UserConnect userConnect)
        {
          _userConnect = userConnect;
            
        }
        public Stash createPost(Stash post )
        {
            var entity = new Post(post.Postname, post.Text);
            var tags = GetTags();

            foreach (var item in post.Tagids)
            {
                if (!tags.Any(o => o.Id == item))
                    return null;
            }



            foreach (var tagId in post.Tagids)
                entity.PostTags.Add(new PostTag { TagId = tagId });


            _userConnect.Add(entity);
            _userConnect.SaveChanges();

            return post;

        }
        
        public Tag createTag(Tag tag)
        {
            var TagExists = _userConnect.Tags.SingleOrDefault(x => x.TagName == tag.TagName);
            if (TagExists != null)
                return null;
            var entity = new Tag(tag.TagName);

            _userConnect.AddAsync(entity);
            _userConnect.SaveChangesAsync();

            return entity;
        }

        public bool deletePost(int id)
        {
            var post = GetPost(id);
            if (post == null)
                return false;
            _userConnect.Remove(post);
            _userConnect.SaveChanges();
            return true;
        }
        

        public bool deleteTag(int id)
        {
            var tag = _userConnect.Tags.FirstOrDefault(x => x.Id == id);

            if (tag == null)
                return false;

            var post = _userConnect.PostTags.FirstOrDefault(x => x.TagId == id);
            if (post != null)
                return false;

            _userConnect.Remove(tag);
            _userConnect.SaveChanges();
            return true;
        }

        public Post GetPost(int id)
        {

            return _userConnect.Posts.SingleOrDefault(x => x.Id == id);


        }

        public List<Post> GetPosts()
        {
            var result = _userConnect.Posts.ToList();
            return result;

            
        }

        public List<Tag> GetTags()
        {
            return _userConnect.Tags.ToList();
        }

        public List<PostTag> PostTagByPostId(int postId)
        {
            var tags = _userConnect.PostTags.ToList();
            var result = tags.Where(x => x.PostId == postId);
            return result.ToList();
        }

        public Post UpdatePost(UpdateStash post)
        {
            var entity = _userConnect.Posts.FirstOrDefault(x => x.Id == post.Id);

            if (entity == null)
                throw new NullReferenceException();

            var postTags = _userConnect.PostTags.ToList();

            foreach (var item in postTags)
            {
                if (item.PostId == post.Id)
                    _userConnect.Remove(item);
            }


            foreach (var tagId in post.Tagids)
            {
                _userConnect.AddAsync(new PostTag { PostId = post.Id, TagId = tagId });
            }


            entity.Title = post.Postname;
            entity.Text = post.Text;

            _userConnect.Update(entity);
            _userConnect.SaveChanges();

            return entity;
        }
    }
}
