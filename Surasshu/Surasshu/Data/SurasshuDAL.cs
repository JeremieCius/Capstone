using Microsoft.EntityFrameworkCore;
using Surasshu.Areas.Identity.Data;
using Surasshu.Interfaces;
using Surasshu.Models;

namespace Surasshu.Data
{
    public class SurasshuDAL : IDataAccessLayer
    {
        public SurasshuContext db;

        public SurasshuDAL(SurasshuContext indb)
        {
            this.db = indb;
        }

        public SurasshuUser GetUser(string userId)
        {
            return db.AspNetUsers.FirstOrDefault(user => user.Id == userId);
        }

        public IEnumerable<SurasshuUser> GetUsersInDatabase()
        {
            return db.AspNetUsers.ToList();
        }

        public void UpdateUser(SurasshuUser user)
        {
            db.AspNetUsers.Update(user);
            db.SaveChanges();
        }

        public IEnumerable<Warrior> GetWarriors(string userId)
        {
            List<Warrior> warriors = new List<Warrior>();
            // Make a foreach to loop in the database and add results that have the userId to list
            foreach (var userWarriors in db.Warriors)
            {
                if (userWarriors.UserId == userId)
                {
                    warriors.Add(userWarriors);
                }
            }
            return warriors;
        }

        

        public int GetWarriorTableCount()
        {
            return db.Warriors.ToList().Count();
        }

        public Warrior GetWarrior(int? id)
        {
            return db.Warriors.FirstOrDefault(warrior => warrior.WarriorId == id);
        }

        public void AddWarrior(Warrior warrior)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                db.Warriors.Add(warrior);
                db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Warriors ON");
                db.SaveChanges();
                db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Warriors OFF");
                transaction.Commit();
            }
        }

        public void DeleteWarrior(int? id)
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

            foreach (var user in db.AspNetUsers)
            {
                    if (user.WarriorOneId == id)
                    {
                        user.WarriorOneId = null;
                    }
                    if (user.WarriorTwoId == id)
                    {
                        user.WarriorTwoId = null;
                    }
                    if (user.WarriorThreeId == id)
                    {
                        user.WarriorThreeId = null;
                    }
                    if (user.WarriorFourId == id)
                    {
                        user.WarriorFourId = null;
                    }
                    if (user.WarriorFiveId == id)
                    {
                        user.WarriorFiveId = null;
                    }
                    if (user.WarriorSixId == id)
                    {
                        user.WarriorSixId = null;
                    }
                    if (user.WarriorSevenId == id)
                    {
                        user.WarriorSevenId = null;
                    }
                    if (user.WarriorEightId == id)
                    {
                        user.WarriorEightId = null;
                    }
                    if (user.WarriorNineId == id)
                    {
                        user.WarriorTenId = null;
                    }
                    if (user.WarriorElevenId == id)
                    {
                        user.WarriorElevenId = null;
                    }
                    if (user.WarriorTwelveId == id)
                    {
                        user.WarriorTwelveId = null;
                    }
                    if (user.WarriorThirteenId == id)
                    {
                        user.WarriorThirteenId = null;
                    }
                    if (user.WarriorFourteenId == id)
                    {
                        user.WarriorFourteenId = null;
                    }
                    if (user.WarriorFifteenId == id)
                    {
                        user.WarriorFifteenId = null;
                    }
                    if (user.WarriorSixteenId == id)
                    {
                        user.WarriorSixteenId = null;
                    }
                    if (user.WarriorSeventeenId == id)
                    {
                        user.WarriorSeventeenId = null;
                    }
                    if (user.WarriorEighteenId == id)
                    {
                        user.WarriorEighteenId = null;
                    }
                    if (user.WarriorNineteenId == id)
                    {
                        user.WarriorNineteenId = null;
                    }
                    if (user.WarriorTwentyId == id)
                    {
                        user.WarriorTwentyId = null;
                    }
                    if (user.WarriorTwentyOneId == id)
                    {
                        user.WarriorTwentyOneId = null;
                    }
            }
            db.Warriors.Remove(db.Warriors.Find(id));
            db.SaveChanges();
        }
    }
}
