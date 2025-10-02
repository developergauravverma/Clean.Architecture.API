using Clean.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Interfaces
{
    public interface IExternalVenderRepository
    {
        Task<Posts> GetExternalVenderData();
    }
}
