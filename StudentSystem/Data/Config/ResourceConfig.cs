using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.Config
{
    public class ResourceConfig : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Name).HasColumnType("VARCHAR")
                .IsRequired().HasMaxLength(50);

            builder.Property(x => x.ResourceType).IsRequired();

           
            builder.Property(x => x.URL).IsRequired();



            builder.ToTable("Resources");


           builder.HasData(
                // Resources for Mathematics (CourseId = 1)
                new { Id = 1, Name = "Math Resource 1", ResourceType = ResourceType.Video, URL = "http://example.com/math1", CourseId = 1 },
                new { Id = 2, Name = "Math Resource 2", ResourceType = ResourceType.Video, URL = "http://example.com/math2", CourseId = 1 },
                new { Id = 3, Name = "Math Resource 3", ResourceType = ResourceType.Video, URL = "http://example.com/math3", CourseId = 1 },
                new { Id = 4, Name = "Math Resource 4", ResourceType = ResourceType.Presentation, URL = "http://example.com/math4", CourseId = 1 },
                new { Id = 5, Name = "Math Resource 5", ResourceType = ResourceType.Document, URL = "http://example.com/math5", CourseId = 1 },
                new { Id = 6, Name = "Math Resource 6", ResourceType = ResourceType.Other, URL = "http://example.com/math6", CourseId = 1 },

                // Resources for Physics (CourseId = 2)
                new { Id = 7, Name = "Physics Resource 1", ResourceType = ResourceType.Video, URL = "http://example.com/physics1", CourseId = 2 },
                new { Id = 8, Name = "Physics Resource 2", ResourceType = ResourceType.Document, URL = "http://example.com/physics2", CourseId = 2 },
                new { Id = 9, Name = "Physics Resource 3", ResourceType = ResourceType.Other, URL = "http://example.com/physics3", CourseId = 2 },

                // Resources for Computer Science (CourseId = 3)
                new { Id = 10, Name = "CS Resource 1", ResourceType = ResourceType.Video, URL = "http://example.com/cs1", CourseId = 3 },
                new { Id = 11, Name = "CS Resource 2", ResourceType = ResourceType.Video, URL = "http://example.com/cs2", CourseId = 3 },
                new { Id = 12, Name = "CS Resource 3", ResourceType = ResourceType.Video, URL = "http://example.com/cs3", CourseId = 3 },
                new { Id = 13, Name = "CS Resource 4", ResourceType = ResourceType.Video, URL = "http://example.com/cs4", CourseId = 3 },
                new { Id = 14, Name = "CS Resource 5", ResourceType = ResourceType.Video, URL = "http://example.com/cs5", CourseId = 3 },
                new { Id = 15, Name = "CS Resource 6", ResourceType = ResourceType.Video, URL = "http://example.com/cs6", CourseId = 3 },
                new { Id = 16, Name = "CS Resource 7", ResourceType = ResourceType.Video, URL = "http://example.com/cs7", CourseId = 3 }
            );



        }
    }
    
    }
