using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrionBlog.Models
{
    public class Tag
    {
        // Keys
        public int Id { get; set; } // Primary Key

        // Descriptive properties
        public string Name { get; set; }

        //Added myself
        [DataType(DataType.DateTime)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; } // Created

        [DataType(DataType.DateTime)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; } // Updated?

        //Navigation properties
        public virtual ICollection<CategoryPost> CategoryPosts { get; set; } =
            new HashSet<CategoryPost>();
    }
}
