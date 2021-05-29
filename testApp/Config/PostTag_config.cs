using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testApp.Models.Post_tag_mix;

namespace testApp.Config
{
    public class PostTag_config : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(d => d.Post)
                 .WithMany(d => d.PostTags)
                 .HasForeignKey(d => d.PostId)
                 .HasConstraintName("FK_PostTags_Posts_PostId")
                 .IsRequired()
                 .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(d => d.Tag)
                 .WithMany(d => d.PostTags)
                 .HasForeignKey(d => d.TagId)
                 .HasConstraintName("FK_PostTags_Tags_TagId")
                 .IsRequired()
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
