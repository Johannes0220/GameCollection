using GameCollection.Archivements;

namespace GameCollection.Archivments.Incrementable;

public interface IIncrementable : IArchivable
{
    void Increment(int? score);

}