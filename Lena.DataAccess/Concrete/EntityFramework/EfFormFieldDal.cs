using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lena.Core.DataAccess.EntityFramework;
using Lena.DataAccess.Abstract;
using Lena.Entities.Concrete;

namespace Lena.DataAccess.Concrete.EntityFramework
{
    public class EfFormFieldDal : EfEntityRepositoryBase<FormField,LenaContext>,IFormFieldDal
    {
    }
}
