using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBlaster9000.Models
{
    public interface ICsvDataModel
    {
        string CsvRow { get; } 
    }
}