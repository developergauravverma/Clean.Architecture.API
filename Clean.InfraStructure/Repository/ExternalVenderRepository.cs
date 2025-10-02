using Clean.Core.Interfaces;
using Clean.Core.Models;
using Clean.InfraStructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.InfraStructure.Repository
{
    public class ExternalVenderRepository(IHttpClientServices services): IExternalVenderRepository
    {
        public async Task<Posts> GetExternalVenderData() => await services.GetData();
    }
}
