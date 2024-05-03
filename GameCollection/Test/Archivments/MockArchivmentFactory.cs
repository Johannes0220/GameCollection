using GameCollection.Archivements;

namespace Test.Archivments;

public class MockArchivmentFactory : IArchivmentFactory
{
    private readonly List<IArchivable> _mockArchivment;
    public MockArchivmentFactory(IArchivable mockTrackable)
    {
        _mockArchivment = new List<IArchivable>();
        _mockArchivment.Add(mockTrackable);
    }
    public List<IArchivable> GetArchivmentsForGame(Type game)
    {
        return _mockArchivment;
    }
}