using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworkSystem.Annie.BO
{
    public class Station
    {
        

  
        public Guid StationId
        {
            get;
            set;
        }
        public string StationUniqueKey
        {
            get;
            set;
        }
        public string StationName
        {
            get;
            set;
        }
        public string StationAdressLineOne
        {
            get;
            set;
        }
        public string StationAdressLineTwo
        {
            get;
            set;
        }
        
        public string City {
			get;
			set;
        }

       
        public string  State 
		{
           
			get;
			set;
        }
        public override string ToString()
        {
            return String.Format("Type : Station |StationId:{0}|StationUniqueKey:{1}|StationName:{2}|StationAdressLineOne:{3}|StationAdressLineTwo:{4}|CityId:{5}|City:{6}:StateId:{7}|State:{8}", this.StationId, this.StationUniqueKey, this.StationName, this.StationAdressLineOne, this.StationAdressLineTwo, this.City, this.City, this.StationId, this.State);
        }
    }
}
