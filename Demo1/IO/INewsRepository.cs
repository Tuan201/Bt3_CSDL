using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.IO
{
    public interface INewsRepository
    {
        List<Publisher> GetNew();

        void Save(List<Publisher> publisher);
        List<Models.Publisher> GetNews();
        void Save(List<Models.Publisher> publishers);
    }
}
