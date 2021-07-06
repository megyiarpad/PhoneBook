using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneRestApi.Model
{
    public class PhoneDTO
    {
        public List<Phone> Phones { get; set; }
        public int TotalCount { get; set; }
    }
}
