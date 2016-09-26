using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParciaisCartola.Services
{
    public interface IAPIService
    {
        IRequestService RequestService { get; }

        IRequestService RequestServiceGlobo { get; }
    }
}
