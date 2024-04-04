
using System.Reflection;

namespace GameCollection.Games
{
    public class GameRepository : IGameRepository
    {
        private readonly List<Type> _gameList;
        public GameRepository()
        { 
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var implementingTypes = types.Where(t => typeof(IPlayable).IsAssignableFrom(t) && t.IsClass);
            _gameList=implementingTypes.ToList();
        }

        public List<Type> GetAllGames()
        {
            return _gameList;
        }
    }
}
