namespace GameCollection.Archivements;

public interface IArchivmentFactory
{
    List<IArchivable> GetArchivmentsForGame(Type game);
}