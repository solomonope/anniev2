using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworkSystem.Annie.BO
{
    public class PumpReading
    {
       
    
        public Guid PumpReadingId
        {
            get;
            set;
        }
        public DateTime ReadingDate
        {
            get;
            set;
        }
        public double SalesRate
        {
            get;
            set;
        }
        public double StartOfBusiness
        {
            get;
            set;
        }
        public double CloseOfBusiness
        {
            get;
            set;
        }
        public double TotalVolumeSold
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
        public override string ToString()
        {
            return String.Format("Type : PumpReading | PumpReadingId:{0}|ReadingDate:{1}|SalesRate:{2}|StartOfBusiness:{3}|CloseOfBusiness:{4}|TotalVolumeSold:{5}}PumpId:{6}}Tank:{7}", this.PumpReadingId, this.ReadingDate, this.SalesRate, this.StartOfBusiness, this.CloseOfBusiness, this.TotalVolumeSold, this.PumpId, this.Pump);
        }
    }
}
