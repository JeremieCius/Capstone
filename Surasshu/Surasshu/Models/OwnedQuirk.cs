using System.ComponentModel.DataAnnotations;

namespace Surasshu.Models
{
    public class OwnedQuirk
    {
        [Required]
        public int OwnedQuirkId { get; set; }

        [Required]
        public int WarriorId { get; set; }
        [Required]
        public int QuirkId { get; set; }

        [Required]
        public bool IsEquipped { get; set; }
        public OwnedQuirk()
        {

        }

        public OwnedQuirk(int ownedQuirkId, int warriorId, int quirkId, bool isEquipped)
        {
            OwnedQuirkId = ownedQuirkId;
            WarriorId = warriorId;
            QuirkId = quirkId;
            IsEquipped = isEquipped;
        }
    }
}
