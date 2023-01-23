using System.ComponentModel.DataAnnotations;

namespace Surasshu.Models
{
    public class WarriorTeam
    {
        [Required]
        public int WarriorTeamId { get; set; }

        [Required]
        public int UserId { get; set; } 
        public int? WarriorOneId { get; set; } = null;

        public int? WarriorTwoId { get; set; } = null;

        public int? WarriorThreeId { get; set; } = null;

        public WarriorTeam(int warriorTeamId, int userId, int? warriorOneId, int? warriorTwoId, int? warriorThreeId)
        {
            WarriorTeamId = warriorTeamId;
            UserId = userId;
            WarriorOneId = warriorOneId;
            WarriorTwoId = warriorTwoId;
            WarriorThreeId = warriorThreeId;
        }

        public WarriorTeam()
        {

        }
    }
}
