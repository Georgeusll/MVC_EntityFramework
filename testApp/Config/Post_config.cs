using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testApp.Models.Post_tag_mix;
using Microsoft.EntityFrameworkCore;


namespace testApp.Config
{
    public class Post_config: IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
              .IsRequired();

            builder.Property(e => e.Text)
             .IsRequired();
        }
    }
}

