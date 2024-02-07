using MOM.Business.IServices;
using MOM.Domain.Entities;
using MOM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOM.Business.Services
{
    public class PersonInfoService : IPersonInfoService
    {

        private readonly IGenericRepository<IkcopersonInfo> _personInfoRepository;

        public PersonInfoService(IGenericRepository<IkcopersonInfo> PersonInfoRepository)
        {
            _personInfoRepository = PersonInfoRepository;   
        }

        public IEnumerable<IkcopersonInfo> GetAll()
        {
            try
            {
                return _personInfoRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
