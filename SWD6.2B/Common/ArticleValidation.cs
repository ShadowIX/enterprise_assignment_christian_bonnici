using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    class ArticleValidation
    {
        [Required(ErrorMessage = "Article Name is blank")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Header cannot exceed 50 characters")]
        public string article_name { get; set; }

        [Required(ErrorMessage = "Article Name is blank")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Header cannot exceed 50 characters")]
        public string article_sub_heading { get; set; }

        [Required(ErrorMessage = "Article Name is blank")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Category cannot exceed 50 characters")]
        public string category { get; set; }

        [Required(ErrorMessage = "Content is blank")]
        public string content { get; set; }
    }

    [MetadataType(typeof(ArticleValidation))]
    //indicating that validation of user properties
    //will take place in the UserValidation class
    public partial class article
    {

    }
}
