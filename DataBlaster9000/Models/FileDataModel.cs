using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBlaster9000.Models
{
    public class FileDataModel
    {
        public Guid Uid { get; set; }
        public List<string> Lines { get; set; } 
 }
}