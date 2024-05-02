using GameCollection.Archivements;
using GameCollection.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.User
{
    public class User
        
    {
        public Guid Id;
        public string Name;
        private Dictionary<Type, List<IArchivable>> _archivments;
        public User(Guid id, string name)
        {
            Id=id; 
            Name=name;
            _archivments = new();
        }
        //private Archivements[]
        // private Dictionary<IGame, IScore> GameScores;
        public void SetArchivments(Type game,List<IArchivable> archivments)
        {
            _archivments.Add(game,archivments);
        }
        public List<IArchivable> GetArchivments(Type game)
        {
            return _archivments[game];
        }
    }
}
