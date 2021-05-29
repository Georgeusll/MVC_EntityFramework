using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using testApp.Models.Post_tag_mix;

namespace testApp.Config
{
    public class Tag_config:IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.TagName)
              .IsRequired();
        }
    }
}
