using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lena.Business.Abstract;
using Lena.DataAccess.Abstract;
using Lena.Entities.Concrete;

namespace Lena.Business.Concrete
{
    public class FormManager : IFormService
    {
        private IFormDal _formDal;
        public FormManager(IFormDal formDal)
        {
            _formDal = formDal;
        }
        public void Add(Form form)
        {
            _formDal.Add(form);
        }

        public void Delete(Form form)
        {
            _formDal.Delete(form);
        }

        public Form Get(int id)
        {
            return _formDal.Get(h => h.Id == id);
        }

        public List<Form> GetAll()
        {
            return _formDal.GetAll();
        }
        public void Update(Form form)
        {
            _formDal.Update(form);
        }
    }
}
