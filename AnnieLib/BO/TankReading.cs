using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworkSystem.Annie.BO
{
    public class TankReading
    {
       
        
        public Guid TankReadingId
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
            return String.Format("Type : TankReading |TankReadingId:{0}|ReadingDate:{1}|SalesRate:{2}|StartOfBusiness:{3}|CloseOfBusiness:{4}|TotalVolumeSold:{5}}TankId:{6}}Tank:{7}", this.TankReadingId, this.ReadingDate, this.SalesRate, this.StartOfBusiness, this.CloseOfBusiness, this.TotalVolumeSold, this.TankId, this.Tank);
        }
    }
}
