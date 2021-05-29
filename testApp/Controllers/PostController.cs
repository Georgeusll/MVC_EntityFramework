using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testApp.Context;
using testApp.Handlers;
using testApp.Models.Post_tag_mix;

namespace testApp.Controllers
{
    public class PostController : Controller 
    {
        private IHandlerInterface _injection;
        private readonly IMapper _mapper;

        public PostController(IHandlerInterface injection, IMapper mapper)
        {
            _injection = injection;
            _mapper = mapper;
        }

        #region Get

        [Authorize]
        [HttpGet]
        public IActionResult AddPost()
        {
            var tags = _injection.GetTags();
            if (tags == null)
                return View();

            List<Stashholder> tagsModelList = new List<Stashholder>();
            foreach (var tag in tags)
            {
                tagsModelList.Add(new Stashholder { TagId = tag.Id, TagName = tag.TagName });

            }
            Stash createPost = new Stash();
            createPost.Stashholder = tagsModelList;
            return View(createPost);

        }
        [Authorize]
        [HttpGet]
        public IActionResult UpdatePost(int id)
        {
            var tags = _injection.GetTags();

            Post post = _injection.GetPost(id);
            var postTags = _injection.PostTagByPostId(id);

            List<Stashholder> tagsModelList = new List<Stashholder>();

            foreach (var tag in tags)
            {
                if (!postTags.Any(x => x.TagId == tag.Id))
                    tagsModelList.Add(new Stashholder { TagId = tag.Id, TagName = tag.TagName });
                else
                    tagsModelList.Add(new Stashholder { TagId = tag.Id, TagName = tag.TagName, IsSelected = true });
            }

            var updatePost = _mapper.Map<UpdateStash>(post);

            updatePost.Stashholder = tagsModelList;

            return View(updatePost);

        }

        [Authorize]
        [HttpGet]
        public IActionResult GetPosts()
        {

            var posts = _injection.GetPosts();


            if (posts != null)
                return View(posts);

            return RedirectToAction("AccessDenied", "User");
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetPostDetails(int id)
        {
            var post = new Post();
            post = _injection.GetPost(id);
           
                return View(post);
        }



        [Authorize]
        [HttpGet]
        public IActionResult AddTag()
        {
            return View();

        }

        [Authorize]
        [HttpGet]
        public IActionResult GetTags()
        {
            List<Tag> tags = _injection.GetTags();


            return View(tags);

        }


        #endregion

        #region Post
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPost(Stash request)
        {
        if(request.Stashholder == null)
            {
                ModelState.AddModelError("", "Error, yes");
                
            }



            request.Tagids = new List<int>();
            for (int i = 0; i < request.Stashholder.Count(); i++)
            {
                if (request.Stashholder[i].IsSelected == true)
                {
                    int id = request.Stashholder[i].TagId;
                    request.Tagids.Add(id);
                }

            }


            var result = _injection.createPost(request);
            



            return View(result);

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTag(Tag request)
        {

            //var exists = _userConnect.Tags.SingleOrDefault(n => n.TagName == request.TagName);
            //if (exists != null)
            //    ModelState.AddModelError(string.Empty, "Let's goooo"); var entity = new Tag(request.TagName);

            //await _userConnect.AddAsync(entity);
            //await _userConnect.SaveChangesAsync();

            var result =  _injection.createTag(request);

            //return RedirectToAction("GetTags");
            return View();

        }

        #endregion



        [Authorize]
        public async Task<IActionResult> UpdatePost(int id, UpdateStash request)
        {
            request.Id = id;

            if (request.Stashholder == null)
            {
                ModelState.AddModelError("", "Provide Tags");
            }


            request.Tagids = new List<int>();
            for (int i = 0; i < request.Stashholder.Count(); i++)
            {
                if (request.Stashholder[i].IsSelected == true)
                {
                    int tagId = request.Stashholder[i].TagId;
                    request.Tagids.Add(tagId);
                }

            }

            var result =  _injection.UpdatePost(request);
            if (result == null)
                return RedirectToAction("AccessDenied", "User");
            return RedirectToAction("GetPosts");
        }


        #region delete

        [Authorize]

        public async Task<IActionResult>DeletePost(int id)
        {
            var result = _injection.deletePost(id);

            if (result==false)
            {
                ModelState.AddModelError("", "Error Occured while deleting");
                return RedirectToAction("GetPosts");

            }


            return RedirectToAction("GetPosts");
        }


        [Authorize]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var result = _injection.deleteTag(id);

           if(result ==false)
            {
                ModelState.AddModelError("", "You should not be using this tag in any posts in order to be able to delete it....yeah....");
                return RedirectToAction("GetTags");
            }

            return RedirectToAction("GetTags");
        }

        #endregion
    }
}
