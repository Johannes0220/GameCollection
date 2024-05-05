using System.ComponentModel;
using GameCollection.Archivements;
using GameCollection.Archivments.Incrementable;
using GameCollection.Archivments.Trackable;
using GameCollection.Games;

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

    public void UpdateArchivmentsForGame(Type game, User.User user, IGameResult gameResult)
    {
        var archivments=user.GetArchivments(game);
        foreach (var archivment in archivments)
        {
            if (archivment is ITrackable)
            {
                var trackable = archivment as ITrackable;
                trackable.StopTracking();
            }

            if (archivment is IIncrementable)
            {
                var incrementable = archivment as IIncrementable;
                if (gameResult is IWinGameResult)
                {
                    var winGameResult = gameResult as IWinGameResult;
                    if (winGameResult.Result)
                    {
                        incrementable.Increment(null);
                    }
                }

                if (gameResult is IScoreGameResult)
                {
                    var scoreGameResult=gameResult as IScoreGameResult;
                    incrementable.Increment(scoreGameResult.Score);
                }
            }
        }
    }
}