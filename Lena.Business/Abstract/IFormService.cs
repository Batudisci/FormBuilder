using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lena.Entities.Concrete;

namespace Lena.Business.Abstract
{
    public interface IFormService
    {
        List<Form> GetAll();
        Form Get(int id);
        void Add(Form form);
        void Update(Form form);
        void Delete(Form form);
    }
}
