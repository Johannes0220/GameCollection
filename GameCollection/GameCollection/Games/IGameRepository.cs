namespace GameCollection.Games;

public interface IGameRepository
{
    List<IPlayable> GetAllGames();
}