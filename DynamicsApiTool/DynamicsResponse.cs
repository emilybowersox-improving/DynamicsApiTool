using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsApiTool
{
    public class DynamicsResponse<T>
    {
        public List<T> Value { get; set; }
    }
}
