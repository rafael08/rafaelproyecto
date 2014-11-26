using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agua_El_Oasis.DA
{
    public class QueryResultSingleton
    {
        public static QueryResultSingleton Intance = new QueryResultSingleton();
        public bool Success { get; set; }
        public string Message { get; set; }

        private QueryResultSingleton()
        {
            Success = false;
            Message = "Not Set";
        }
    }
}