using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testApp.Models;
using testApp.Models.Post_tag_mix;

namespace testApp.Context
{
    public class UserConnect : IdentityDbContext <User, IdentityRole, string> {



        public UserConnect(DbContextOptions<UserConnect> options) : base(options)
        {

        }


        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
    }

    
}
