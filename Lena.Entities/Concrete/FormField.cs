using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lena.Core.Entities;

namespace Lena.Entities.Concrete
{
    public class FormField : IEntity
    {
        public int Id { get; set; }
        public string DataType { get; set; }
        public string Name { get; set; }
        public int Form { get; set; }
        public int FormId { get; set; }
        public bool Required { get; set; }
    }
}
