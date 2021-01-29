using System;
using System.ComponentModel.DataAnnotations;

namespace OrionBlog.Models
{
    public class PostComment
    {
        // Keys
        public int Id { get; set; } // Primary Key

        [Display(Name = "Category Post Id")]
        public int CategoryPostId { get; set; } // Parent Key

        [Display(Name = "User Id")]
        public string BlogUserId { get; set; } // Author Key

        // Descriptive properties
        [Display(Name = "Comment Body")]
        public string CommentBody { get; set; } // Body

        [DataType(DataType.DateTime)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; } // Created

        [DataType(DataType.DateTime)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; } // Updated?

        [DataType(DataType.DateTime)]
        [Display(Name = "Time Moderated")]
        public DateTime? Moderated  { get; set; } // ModeratedDate?

        [Display(Name = "Moderated Reason")]
        public string ModeratedReason { get; set; } // ModerationReason

        [Display(Name = "Moderated Body")]
        public string ModeratedBody { get; set; } // ModeratedBody


        // Navigation Property
        public virtual CategoryPost CategoryPost { get; set; }

        public virtual BlogUser BlogUser { get; set; }

    }
}
