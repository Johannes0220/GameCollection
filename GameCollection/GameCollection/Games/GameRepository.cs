
using System.Reflection;

namespace GameCollection.Games
{
    public class GameRepository : IGameRepository
    {
        public GameRepository()
        { 
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var implementingTypes = types.Where(t => typeof(IPlayable).IsAssignableFrom(t) && t.IsClass);
        }

        public List<IPlayable> GetAllGames()
        {
            return new List<IPlayable>();
        }
    }
}
