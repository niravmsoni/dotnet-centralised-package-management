using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPM.Core.Services
{
    public interface IRestfulService
    {
        public Task<IEnumerable<ResponseObject>> GetObjects();
    }
}
