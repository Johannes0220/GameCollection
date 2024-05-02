using GameCollection.Archivements;

namespace GameCollection.Controller;

public class ArchivmentController
{
    private readonly ArchivmentFactory _archivmentFactory;

    public ArchivmentController(ArchivmentFactory archivmentFactory)
    {
        _archivmentFactory = archivmentFactory;
    }
    public void RunArchivmentsForGame(Type game, User.User user)
    {
        List<IArchivable> archivments;
        try
        {
            archivments = user.GetArchivments(game);
        }
        catch (Exception e)
        {
             archivments =_archivmentFactory.GetArchivmentsForGame(game);
             user.SetArchivments(game, archivments);
        }

        foreach (var archivment in archivments)
        {
            if (archivment.GetType().IsAssignableFrom(typeof(ITrackable)))
            {
                var trackable=(ITrackable)archivment;
                trackable.StartTracking();
            }
        }
    }

    public void UpdateArchivmentsForGame(Type game, User.User user)
    {
        var archivments=user.GetArchivments(game);
        foreach (var archivment in archivments)
        {
            if (archivment.GetType().IsAssignableFrom(typeof(ITrackable)))
            {
                var trackable = (ITrackable)archivment;
                trackable.StopTracking();
            }
        }
    }
}