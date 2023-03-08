using Microsoft.EntityFrameworkCore;
using Surasshu.Areas.Identity.Data;
using Surasshu.Interfaces;
using Surasshu.Models;

namespace Surasshu.Data
{
    public class SurasshuDAL : IDataAccessLayer
    {
        public SurasshuContext db;

        private Random random = new Random();

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

        public void UpdateWarrior(Warrior warrior)
        {
            db.Warriors.Update(warrior);
            db.SaveChanges();
        }

        public void GiveWarriorXp(Warrior winner, Warrior loser)
        {
            winner.Xp += 100 / winner.Level; 
            var dbWinner = GetWarrior(winner.WarriorId);
            dbWinner.Xp = winner.Xp;

            loser.Xp += 20 / loser.Level;
            var dbLoser = GetWarrior(loser.WarriorId);
            dbLoser.Xp = loser.Xp;


            LevelUpWarrior(dbWinner);
            LevelUpWarrior(dbLoser);
        }

        public void LevelUpWarrior(Warrior warrior)
        {
            if (warrior.Xp >= 100)
            {
                warrior.Level += 1;
                // Ninja Level Tree
                if (warrior.IsNinja)
                {
                    switch (warrior.Level % 5)
                    {
                        case 1:
                            warrior.Hp += random.Next(10) + 1;
                            break;
                        case 2:
                            warrior.Hp += random.Next(6) + 1;
                            warrior.Crit += 0.25;
                            break;
                        case 3:
                            warrior.Hp += random.Next(6) + 1;
                            warrior.AttackMod += 1;
                            warrior.DieSide += 1;
                            break;
                        case 4:
                            warrior.Hp += random.Next(6) + 1;
                            warrior.Defense += 1;
                            break;
                        case 0:
                            warrior.Hp += random.Next(4) + 4;
                            warrior.Crit += 0.25;
                            warrior.DieCount += 1;
                            warrior.AttackMod += 1;

                            return;
                    }
                }
                // Samurai Level Tree
                else
                {
                    switch (warrior.Level % 8)
                    {
                        case 1:
                            warrior.Hp += random.Next(12) + 1;
                            break;
                        case 2:
                            warrior.Hp += random.Next(10) + 1;
                            break;
                        case 3:
                            warrior.Hp += random.Next(8) + 1;
                            warrior.Defense += 2;
                            break;
                        case 4:
                            warrior.Hp += random.Next(8) + 1;
                            warrior.AttackMod += 1;
                            break;
                        case 5:
                            warrior.Hp += random.Next(10) + 1;
                            break;
                        case 6:
                            warrior.Hp += random.Next(8) + 1;
                            warrior.AttackMod += 1;
                            break;
                        case 7:
                            warrior.Hp += random.Next(8) + 1;
                            warrior.DieSide += 1;
                            break;
                        case 0:
                            warrior.Hp += random.Next(8) + 4;
                            warrior.Crit += 0.25;
                            warrior.Defense += 3;
                            warrior.DieCount += 1;
                            warrior.AttackMod += 1;
                            return;
                    }
                }

                warrior.Xp -= 100;
            }

            UpdateWarrior(warrior);
        }

        public IEnumerable<OwnedQuirk> GetOwnedQuirks(int warriorId)
        {
            var ownedQuirks = new List<OwnedQuirk>();
            foreach (var warriorQuirk in db.OwnedQuirks)
            {
                if (warriorQuirk.WarriorId == warriorId)
                {
                    ownedQuirks.Add(warriorQuirk);
                }
            }

            return ownedQuirks;
        }

        public void EquipNinjaWithQuirk(int warriorId, Quirk q1, Quirk q2, Quirk q3) 
        {
            var warrior = GetWarrior(warriorId);

            warrior.QuirkOneId = q1.QuirkId;
            warrior.QuirkTwoId = q2.QuirkId;
            warrior.QuirkThreeId = q3.QuirkId;

            UpdateWarrior(warrior);
        }

        public void EquipSamuraiWithQuirk(int warriorId, Quirk q1, Quirk q2)
        {
            var warrior = GetWarrior(warriorId);

            warrior.QuirkOneId = q1.QuirkId;
            warrior.QuirkTwoId = q2.QuirkId;

            UpdateWarrior(warrior);
        }

        public IEnumerable<Quirk> GetQuirks()
        {
            return db.Quirks;
        }

        public Quirk GetQuirkByName(string quirkName)
        {
            var foundQuirk = new Quirk();
            foreach (var quirk in db.Quirks)
            {
                if (quirk.QuirkName == quirkName)
                {
                    foundQuirk = quirk;
                }
            }

            return foundQuirk;
        }

        public Quirk GetQuirkByInt(int? quirkId)
        {
            return db.Quirks.FirstOrDefault(quirk => quirk.QuirkId == quirkId);
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

        

        public int GetWarriorHighestIndexCount()
        {
            var highestIndex = 0;
            foreach (var warriors in db.Warriors)
            {
                if (warriors.WarriorId > highestIndex)
                {
                    highestIndex = warriors.WarriorId;
                }
            }

            return highestIndex;
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
