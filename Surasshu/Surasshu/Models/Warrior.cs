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

        public bool IsNinja { get; set; }

        public int Xp { get; set; }

        public int AttackMod { get; set; }

        public int DieCount { get; set; }

        public int DieSide { get; set; }

        public int Defense { get; set; }

        [Column(TypeName = "varchar(500)")]
        public int Hp { get; set; }

        public int? QuirkOneId {get; set; }
        public int? QuirkTwoId { get; set; }
        public int? QuirkThreeId { get; set; }

        public Warrior(int warriorId, string warriorName, bool isNinja, int xp, int attackMod, int dieCount, int dieSide, int defense, int hp, int? quirkOneId, int? quirkTwoId, int? quirkThreeId)
        {
            WarriorId = warriorId;
            WarriorName = warriorName;
            IsNinja = isNinja;
            Xp = xp;
            AttackMod = attackMod;
            DieCount = dieCount;
            DieSide = dieSide;
            Defense = defense;
            Hp = hp;
            QuirkOneId = quirkOneId;
            QuirkTwoId = quirkTwoId;
            QuirkThreeId = quirkThreeId;
        }

        public Warrior()
        {

        }
    }

}

