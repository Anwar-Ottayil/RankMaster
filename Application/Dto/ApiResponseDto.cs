using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ApiResponseDto<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public ApiResponseDto(int statusCode, string message=null, T data=default)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

    }
}
