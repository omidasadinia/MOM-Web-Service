using MOM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOM.Business.IServices
{
    public interface IPersonInfoService
    {
        IEnumerable<IkcopersonInfo> GetAll();
    }
}
