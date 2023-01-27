﻿using Surasshu.Areas.Identity.Data;
using Surasshu.Models;

namespace Surasshu.Interfaces
{
    public interface IDataAccessLayer
    {
        public IEnumerable<Warrior> GetWarriors(string userId);

        public IEnumerable<SurasshuUser> GetUsersInDatabase();

        public int GetWarriorTableCount();

        Warrior GetWarrior(int? id);

        void AddWarrior(Warrior warrior);

        void DeleteWarrior(int? id);
    }
}
