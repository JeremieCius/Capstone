using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surasshu.Models
{
    public class Warrior
    {
        [Required]
        public int WarriorId { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string WarriorName { get; set; }

        public string UserId { get; set; }

        public bool IsNinja { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? ImageLink { get; set; }

        public int Xp { get; set; }

        public int Level { get; set; } = 1;

        public int AttackMod { get; set; }

        public int DieCount { get; set; }

        public int DieSide { get; set; }

        public double Crit { get; set; }

        public int Defense { get; set; }

        public int Hp { get; set; }

        public int? QuirkOneId {get; set; }
        public int? QuirkTwoId { get; set; }
        public int? QuirkThreeId { get; set; }

        public Warrior(int warriorId, string warriorName, string userId, bool isNinja, int xp, int attackMod, int dieCount, int dieSide, 
            double crit, int defense, int hp, int? quirkOneId, int? quirkTwoId, int? quirkThreeId, string? imageLink, int level)
        {
            WarriorId = warriorId;
            WarriorName = warriorName;
            UserId = userId;
            IsNinja = isNinja;
            Xp = xp;
            AttackMod = attackMod;
            DieCount = dieCount;
            DieSide = dieSide;
            Crit = crit;
            Defense = defense;
            Hp = hp;
            QuirkOneId = quirkOneId;
            QuirkTwoId = quirkTwoId;
            QuirkThreeId = quirkThreeId;
            ImageLink = imageLink;
            Level = level;
        }

        public Warrior()
        {

        }
    }

}

