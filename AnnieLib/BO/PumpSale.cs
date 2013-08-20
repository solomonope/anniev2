using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworkSystem.Annie.BO
{
    public class PumpSale
    {
   
        public Guid PumpSaleId
        {
            get;
            set;
        }

        public Guid PumpId
        {
            get;
            set;
        }
        public Pump Pump
        {
            get;
            set;
        }
        public double SoldVolume
        {
            get;
            set;
        }
        public double SalesRate
        {
            get;
            set;
        }
        public DateTime DateTimeOfSale
        {
            get;
            set;
        }
    }
}
