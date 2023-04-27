using Lena.DataAccess.Abstract;
using Lena.Entities.Concrete;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lena.Business.Abstract;

namespace Lena.Business.Concrete
{
    public class FormFieldManager : IFormFieldService
    {
        private IFormFieldDal _formFieldDal;
        public FormFieldManager(IFormFieldDal formFieldDal)
        {
            _formFieldDal = formFieldDal;
        }
        public void Add(FormField formField)
        {
            _formFieldDal.Add(formField);
        }

        public void Delete(FormField formField)
        {
            _formFieldDal.Delete(formField);
        }

        public FormField Get(int id)
        {
            return _formFieldDal.Get(h => h.Id == id);
        }

        public List<FormField> GetAll()
        {
            return _formFieldDal.GetAll();
        }
        public void Update(FormField formField)
        {
            _formFieldDal.Update(formField);
        }
    }
}
