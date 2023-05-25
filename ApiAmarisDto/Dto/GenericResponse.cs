using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiAmarisDto.Dto
{
    public class GenericResponse
    {
        public string message { get; set; }
        public string status { get; set; }
        public object data { get; set; }
    }
}
