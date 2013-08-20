using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworkSystem.Annie.BO
{
    public class Pump
    {
        
        public Guid PumpId
        {
            get;
            set;
        }
        public String PumpName
        {
            get;
            set;
        }
        public Guid FluidId
        {
            get;
            set;
        }
        public Fluid Fluid
        {
            get;
            set;
        }
        public bool Serviceable
        {
            get;
            set;
        }

        public ICollection<PumpReading> PumpReadings { get; set; }
        public ICollection<PumpSale>    PumpSales { get; set; }
        public override string ToString()
        {
            return String.Format("Type : Pump |PumpId:{0}|PumpName:{1}|FluidId:{2}|Serviceable:{3}|Fluid:{4}", this.PumpId, this.PumpName, this.FluidId, this.Serviceable, this.Fluid);
        }
    }
}
