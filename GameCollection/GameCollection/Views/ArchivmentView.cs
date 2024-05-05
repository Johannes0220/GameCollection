using GameCollection.Archivements;

namespace GameCollection.Views;

public class ArchivmentView: BasicView
{
    public Type ChooseGame(List<Type> gameList)
    {
        for( int i=0; i<gameList.Count; i++)
        {

            Console.WriteLine($"[{i}] {gameList[i].Name}");
        }

        var input=ReadNumericInput("Choose the Number of the game of which you would like to see the archivments", 0,
            gameList.Count - 1);
        return gameList[input];
    }

    public void ShowArchivementsForGame(List<IArchivable> archivments, Type game)
    {
        Console.Clear();
        Console.WriteLine("Name\t\tLevel\t Score");
        foreach (var archivable in archivments)
        {
            Console.WriteLine($"{archivable.Name}\t{archivable.Level}\t {archivable.GetScore().GetScore()}");
        }
        Console.WriteLine("Press Enter to return to the main menu!");
        Console.ReadLine();
        Console.Clear();
    }
}