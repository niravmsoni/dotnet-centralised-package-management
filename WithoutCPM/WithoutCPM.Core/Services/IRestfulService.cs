using System.Collections.Generic;
using System.Threading.Tasks;

namespace WithoutCPM.Core.Services
{
    public interface IRestfulService
    {
        public Task<IEnumerable<ResponseObject>> GetObjects();
    }
}
