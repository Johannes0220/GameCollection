using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public interface ICustomJsonSerializer
    {
        string Serialize(object obj);

        public T Deserialize<T>(string json);
    }
}
