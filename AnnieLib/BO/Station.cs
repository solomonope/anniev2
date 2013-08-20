using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitworkSystem.Annie.BO
{
    public class Station
    {
        private State m_State;
        private City m_City;

  
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
        public Guid CityId
        {
            get;
            set;
        }
        public City City
        {
            get
            {
                return m_City;

            }
            set
            {
                this.m_City = value;
            }
        }

        public Guid StateId
        {
            get;
            set;
        }
        public State State
        {
            get
            {
                return m_State;
            }
            set
            {
                if (value != null)
                {
                    var _State = value as State;
                    if (_State != null)
                    {
                        if (this.StateId != _State.StateId)
                        {
                            m_State = null;
                        }
                        else
                        {
                            m_State = value;
                        }
                    }
                    else
                    {
                        m_State = value;
                    }
                }
                else
                {
                    m_State = value;
                }
            }
        }
        public override string ToString()
        {
            return String.Format("Type : Station |StationId:{0}|StationUniqueKey:{1}|StationName:{2}|StationAdressLineOne:{3}|StationAdressLineTwo:{4}|CityId:{5}|City:{6}:StateId:{7}|State:{8}", this.StationId, this.StationUniqueKey, this.StationName, this.StationAdressLineOne, this.StationAdressLineTwo, this.CityId, this.City, this.StationId, this.State);
        }
    }
}
