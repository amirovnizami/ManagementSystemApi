using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagmentSystem.Common.GlobalResponses.Generics
{
    public class Result<T> : Result
    {
        public T Data { get; set; }
        public Result()
        {
        }

        public Result(List<string> errors) : base(errors)
        {
        }
    }
}