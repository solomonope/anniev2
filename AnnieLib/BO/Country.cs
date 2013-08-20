using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworkSystem.Annie.BO
{
    public class Country
    {
       
        public Guid CountryId
        {
            get;
            set;
        }

        public String CountryName
        {
            get;
            set;
        }

        public ICollection<State> States { get; set; }
        public override string ToString()
        {
            return String.Format("Type: Country | CountryId:{0}|CountryName:{1}", this.CountryId, this.CountryName);
        }
    }
}
