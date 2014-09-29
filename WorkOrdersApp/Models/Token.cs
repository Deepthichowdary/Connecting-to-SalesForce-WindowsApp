using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrdersApp.Models
{
        public static class Token
        {
            public static string AccessToken { get; set; }
            public static string RefreshToken { get; set; }
            public static string InstanceUrl { get; set; }
            public static string Id { get; set; }
        }
        
}
