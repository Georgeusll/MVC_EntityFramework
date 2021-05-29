using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.Models.Post_tag_mix
{
    public class Stash
    {
       public string Postname { get; set; }
      public  string Text { get; set; }
        
        public List<int> Tagids { get; set; }
        public List<Stashholder> Stashholder { get; set; }



    }


    public class Stashholder
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public bool IsSelected { get; set; }
    }
}
