using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworkSystem.Annie.BO
{
    public class Fluid
    {
    
        public Guid FluidId
        {
            get;
            set;
        }
        public string FluidCode
        {
            get;
            set;
        }
        public string FluidName
        {
            get;
            set;
        }

        public ICollection<Pump> Pumps { get; set; }
        public ICollection<Tank> Tanks { get; set; }
        public override string ToString()
        {
            return String.Format("Type : Fluid |FluidId:{0}|FluidCode:{1}|FluidName:{2}", this.FluidId, this.FluidCode, this.FluidName);
        }
    }
}
