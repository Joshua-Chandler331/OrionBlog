using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OrionBlog.Models
{
    public class BlogUser : IdentityUser
    {
        [Required]
        [StringLength(55, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
      
        //[NotMapped]
        //[StringLength(55, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        //[Display(Name = "Display Name")]
        //public string DisplayName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        // Navigation properties
        public virtual ICollection<PostComment> PostComments { get; set; } = new HashSet<PostComment>();
    }
}
