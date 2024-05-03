namespace GameCollection.Archivements;

public interface ITrackable: IArchivable
{
    void StartTracking();
    void StopTracking();
}