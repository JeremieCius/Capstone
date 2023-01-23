using Surasshu.Interfaces;
using Surasshu.Models;

namespace Surasshu.Data
{
    public class SurasshuDAL : IDataAccessLayer
    {
        private SurasshuContext db;

        public IEnumerable<Warrior> GetWarriors()
        {
            return db.Warriors.ToList();
        }

        public Warrior GetWarrior(int? id)
        {
            return db.Warriors.FirstOrDefault(warrior => warrior.WarriorId == id);
        }

        public void AddWarrior(Warrior warrior)
        {
            db.Add(warrior);
            db.SaveChanges();
        }

        public void DeleteWarrior(int? id)
        {
            if (id > 0)
            {
                foreach (var warriorTeam in db.WarriorTeams)
                {
                    if (warriorTeam.WarriorOneId == id)
                    {
                        warriorTeam.WarriorOneId = null;
                    }
                    if (warriorTeam.WarriorTwoId == id)
                    {
                        warriorTeam.WarriorTwoId = null;
                    }
                    if (warriorTeam.WarriorThreeId == id)
                    {
                        warriorTeam.WarriorThreeId = null;
                    }
                }
                db.Warriors.Remove(db.Warriors.Find(id));
            }
        }
    }
}
