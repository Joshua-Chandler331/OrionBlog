using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrionBlog.Models
{
    public class BlogCategory
    {
        //Primary Key section
        public int Id { get; set; }

        // Descriptive properties of this model
        [Required]
        [Display(Name = "Blog Catagory Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and no morethan {1} characters long", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no morethan {1} characters long", MinimumLength = 10)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }


        // public Nullable<DateTime> Updated  { get; set; }
        // public DateTime? Updated { get; set; }

        // Navigation section
        // As A Blog Category I am likely to have or more Category Post children
        public virtual ICollection<CategoryPost> CategoryPosts { get; set; } =
            new HashSet<CategoryPost>();
    }
}


// Blog Category - 
// Name: MVC topics
// Description: This category will house sevel Posts that discuss the MVC design pattern 

// Category Post (1) -
// Parent: MVC Topics
// Title: Security in MVC
// Title: Follow me as I start the discussion on using security features in MVC 
// Body: lorem ipsum..

// Category Post (2) -
// 