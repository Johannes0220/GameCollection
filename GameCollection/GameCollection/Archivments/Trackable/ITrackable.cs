using GameCollection.Archivements;

namespace GameCollection.Archivments.Trackable;

public interface ITrackable : IArchivable
{
    void StartTracking();
    void StopTracking();
}