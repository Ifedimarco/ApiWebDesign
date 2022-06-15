using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebDesign.Models
{
    public class ResponseModel<TData>
    {
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }
    }
}

