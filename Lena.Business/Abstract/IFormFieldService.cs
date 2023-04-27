using Lena.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Business.Abstract
{
    public interface IFormFieldService
    {
        List<FormField> GetAll();
        FormField Get(int id);
        void Add(FormField formField);
        void Update(FormField formField);
        void Delete(FormField formField);
    }
}
