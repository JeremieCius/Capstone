using Surasshu.Areas.Identity.Data;
using Surasshu.Models;

namespace Surasshu.Interfaces
{
    public interface IDataAccessLayer
    {
        public IEnumerable<Warrior> GetWarriors(string userId);

        public IEnumerable<SurasshuUser> GetUsersInDatabase();

        public int GetWarriorHighestIndexCount();

        Warrior GetWarrior(int? id);

        void AddWarrior(Warrior warrior);

        void DeleteWarrior(int? id);

        SurasshuUser GetUser(string userId);

        void UpdateUser(SurasshuUser user);

        void UpdateWarrior(Warrior warrior);

        void GiveWarriorXp(Warrior winner, Warrior loser);

        void LevelUpWarrior(Warrior warrior);

        IEnumerable<OwnedQuirk> GetOwnedQuirks(int warriorId);

        void EquipNinjaWithQuirk(int warriorId, Quirk q1, Quirk q2, Quirk q3);

        void EquipSamuraiWithQuirk(int warriorId, Quirk q1, Quirk q2);


        Quirk GetQuirkByName(string quirkName);

        Quirk GetQuirkByInt(int? quirkId);

        IEnumerable<Quirk> GetQuirks();

    }
}
