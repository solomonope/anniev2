using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworkSystem.Annie.BO
{
    public class Tank
    {
       
        
        public Guid TankId
        {
            get;
            set;
        }
      
        public String TankName
        {
            get;
            set;
        }
        public Guid FluidId
        {
            get;
            set;
        }
        public bool Serviceable
        {
            get;
            set;
        }
        public double TankVolume
        {
            get;
            set;
        }
        public Fluid Fluid
        {

            get;
            set;
        }

        public ICollection<TankActivity> TankActivities { get; set; }
        public ICollection<TankReading> TankReadings { get; set; }
        public ICollection<TankVolumeLogg> TankVolumeLoggs { get; set; }

        public override string ToString()
        {
            return String.Format("Type : Tank | TankId:{0}|TankName:{1}|FluidId:{2}|Serviceable:{3}|TankVolume{4}|Fluid:{5}", this.TankId, this.TankName, this.FluidId, this.Serviceable, this.TankName, this.Fluid);
        }
    }
}
