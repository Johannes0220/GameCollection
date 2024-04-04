
namespace GameCollection.Games
{
    public class Game:IPlayable
    {
        private readonly Guid Id;
        private readonly string Name;
        public string getName()
        {
            return Name;
        }
    }
}
