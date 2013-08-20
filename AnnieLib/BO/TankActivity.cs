using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworkSystem.Annie.BO
{
    public class TankActivity
    {
        
        
        public Guid TankActivityId
        {
            get;
            set;
        }
        public ActivityType ActivityType
        {
            get;
            set;
        }
        public double TotalVolume
        {
            get;
            set;
        }
        public DateTime ActivityDate
        {
            get;
            set;
        }
        public Guid TankId
        {
            get;
            set;
        }
        public Tank Tank
        {
            get;
            set;
        }
        public override string ToString()
        {
            return String.Format("Type :TankActivity| TankActivityId:{0}|ActivityType:{1}|TotalVolume:{2}|ActivityDate:{3}|TankId:{4}|Tank:{5}", this.TankActivityId, this.ActivityType, this.TotalVolume, this.ActivityDate, this.TankId, this.Tank);
        }
    }
}
