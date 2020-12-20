using System.Collections.Generic;
using Minify.Model;

namespace Minify.Interfaces{
    public interface IRepository
    {
        void Add(MinifyData minifyData);
        IEnumerable<MinifyData> Get();

        MinifyData Get(string key);

        void Delete(string key);
    }
}