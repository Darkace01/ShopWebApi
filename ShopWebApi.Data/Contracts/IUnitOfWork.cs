using ShopWebApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Core
{
    interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
