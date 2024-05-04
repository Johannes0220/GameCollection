using GameCollection.Archivements;
using GameCollection.Archivments.Trackable;

namespace Test.Archivments;

public class MockTrackable :ITrackable
{
    public bool StartedTracking = false;
    public bool StoppedTracking = false;
    public void StartTracking()
    {
        StartedTracking = true;
    }

    public void StopTracking()
    {
        StoppedTracking = true;
    }

    public string Name { get; }
    public int Level { get; }
    public IArchivmentScore GetScore()
    {
        throw new NotImplementedException();
    }
}