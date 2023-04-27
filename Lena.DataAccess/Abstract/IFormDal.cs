using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lena.Core.DataAccess;
using Lena.Entities.Concrete;

namespace Lena.DataAccess.Abstract
{
    public interface IFormDal : IEntityRepository<Form>
    {
    }
}
