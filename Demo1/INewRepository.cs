using System.Collections.Generic;
using System.Security.Policy;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Demo1
{
    internal interface INewRepository
    {
        List<Publisher> GetNews();
        void Save(List<Publisher> publishers);
    }
}