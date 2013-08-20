using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworkSystem.Annie.BO
{
    public class City
    {
    
        
        public Guid CityId
        {
            get;
            set;

        }

        public string CityName
        {
            get;
            set;
        }

        public Guid StateId
        {
            get;
            set;
        }
        public State State
        {
            get;
            set;
        }
        public override string ToString()
        {
            return String.Format("Type: City |CityId:{0}|CityName:{1}|StateId:{2}|State:{3}", this.CityId, this.CityName, this.StateId, this.State);
        }
    }
}
