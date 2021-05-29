using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testApp.Context;
using testApp.Models.Post_tag_mix;

namespace testApp.Mappings
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            
            CreateMap<Stash, Post>().ReverseMap();
            CreateMap<UpdateStash, Post>().ReverseMap();
            CreateMap<Stash, Tag>().ReverseMap();

        }
    }
}

