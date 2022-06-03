using System.ComponentModel.DataAnnotations;

namespace SPVWeb.ViewModel
{
    public class CommentViewModel
    {
        [Required]
        public int MountainId{ get; set; }
        [Required]
        public int MainCommentId { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
