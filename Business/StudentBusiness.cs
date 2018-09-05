using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.DTOs;
using Data.UnitOfWorks;

namespace Business
{
    public class StudentBusiness : IstudentBusiness
    {
        private UnitOfWorks unitofworks = new UnitOfWorks();
        
        public void Add(StudentDTO dto)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<StudentDTO> GetAll()
        {
            var list = unitofworks.StudentRepository.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<object, StudentDTO>());

            List<StudentDTO> listOut = Mapper.Map<object[], List<StudentDTO>>(list);
        }

        public void GetBuyId(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentDTO dto)
        {
            throw new NotImplementedException();
        }

        StudentDTO IstudentBusiness.GetBuyId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
