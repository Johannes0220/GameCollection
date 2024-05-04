using System.ComponentModel;
using GameCollection.Archivements;
using GameCollection.Archivments.Trackable;

namespace GameCollection.Controller;

public class ArchivmentController
{
    private readonly IArchivmentFactory _archivmentFactory;

    public ArchivmentController(IArchivmentFactory archivmentFactory)
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
            if (archivment is ITrackable)
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
            if (archivment is ITrackable)
            {
                var trackable = (ITrackable)archivment;
                trackable.StopTracking();
            }
        }
    }
}