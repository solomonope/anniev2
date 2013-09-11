using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitworkSystem.Annie.BO;
namespace BitworkSystem.Annie.BLL.Contract
{
    //
    public interface IManager<T>
    {
		bool Validate(List<ValidationError> _ValidationErrors ,T _T);
    }
}
