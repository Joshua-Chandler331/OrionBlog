using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrionBlog.Models
{
    public class CategoryPost
    {
        //Keys
        public int Id { get; set; } // Primary

        [Display(Name = "Blog Catagory Id")]
        public int BlogCategoryId { get; set; } // Parent

        // Descriptive Properties
        //[Required]
        public string Title { get; set; } // Title

        //[Required]
        public string Abstract { get; set; } // Abstract still have question

        [Required]
        [Display(Name = "Post Body")]
        public string PostBody { get; set; } // Content
        [Display(Name = "Production Ready?")]
        public bool IsProductionReady { get; set; } // IsProductionReady

        // Programmatically derived properties
        public string Slug { get; set; } // Slug

        [DataType(DataType.DateTime)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; } // Created

        [DataType(DataType.DateTime)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; } // Updated?

        //Navigation section
        [Display(Name = "Blog Catagory")]
        public virtual BlogCategory BlogCategory { get; set; } // Reference from my Parent
        
        public virtual ICollection<PostComment> PostComments { get; set; } = 
            new HashSet<PostComment>(); // Has Category Posts as Children

        //Many to many relationship
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>(); // Has Category Posts as Tags as Children

    }
}
