using Clean.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.InfraStructure.Services
{
    public interface IHttpClientServices
    {
        Task<Posts> GetData();
    }
}
