using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IResponseModel
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
