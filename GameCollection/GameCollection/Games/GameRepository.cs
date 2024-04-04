
namespace GameCollection.Games
{
    public class GameRepository : IGameRepository
    {
        public List<IPlayable> GetAllGames()
        {
            return new List<IPlayable>();
        }
    }
}
