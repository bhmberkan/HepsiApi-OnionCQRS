using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Exeptions
{
    public class ExceptionModel : ErrorStatusCode
    {
        public IEnumerable<string> Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
            // gelen erorları stringe çevirip serialize ettik
        }
    }

    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
    }

}
