using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworkSystem.Annie.BO
{
    public class SalesRate
    {
        private Fluid m_Fluid;
      
        public Guid SalesRateId
        {
            get;
            set;
        }
        public double Rate
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
            get
            {
                return m_Fluid;
            }
            set
            {
                this.m_Fluid = value;
            }
        }
        public override string ToString()
        {
            return String.Format("SalesRateId:{0}|Rate:{1}|FluidId:{2}|Fluid:{3}", this.SalesRateId, this.Rate, this.FluidId, this.Fluid);
        }
    }
}
