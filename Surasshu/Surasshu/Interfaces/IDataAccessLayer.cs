using Surasshu.Models;

namespace Surasshu.Interfaces
{
    public interface IDataAccessLayer
    {
        public IEnumerable<Warrior> GetWarriors();

        Warrior GetWarrior(int? id);

        void AddWarrior(Warrior warrior);

        void DeleteWarrior(int? id);
    }
}
