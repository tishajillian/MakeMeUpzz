using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Modules
{
    public class Response<T>
    {
        public String Message { get; set; }
        public T payload { get; set; }
        public Boolean IsSuccess { get; set; }
    }
}