using System.ComponentModel.DataAnnotations;

namespace Surasshu.Models
{
    public class OwnedQuirk
    {
        [Required]
        public int OwnedQuirkId { get; set; }

        [Required]
        public string UserId { get; set; }
        [Required]
        public int QuirkId { get; set; }

        public OwnedQuirk()
        {

        }

        public OwnedQuirk(string userId, int quirkId)
        {
            UserId = userId;
            QuirkId = quirkId;
        }
    }
}
