using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBlaster9000.Models
{
    public class UserDataModel : ICsvDataModel
    {
        public UserDataModel()
        {
        }

        public UserDataModel(string line)
        {
            var columns = line.Split(',');
            Id = Convert.ToInt32(columns[0]);
            FirstName = columns[1];
            LastName = columns[2];
            Age = Convert.ToInt32(columns[3]);
        }

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string CsvRow
        {
            get
            {
                return String.Format("{0},{1},{2},{3}", Id.ToString("D3"), FirstName, LastName, Age);
            }
        }

        public bool Equals(UserDataModel obj)
        {
            if(Id == obj.Id)
                if(string.Equals(FirstName, obj.FirstName, StringComparison.CurrentCultureIgnoreCase))
                    if(string.Equals(LastName, obj.LastName, StringComparison.CurrentCultureIgnoreCase))
                        if (Age == obj.Age)
                            return true;

            return false;
        }
    }
}