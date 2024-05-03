using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Archivements
{
    public interface IArchivable
    {
        string Name { get; }
        int Level { get; }
        IArchivmentScore GetScore();

    }
}
