using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs;

namespace Business
{
    public interface IstudentBusiness
    {
        void Add(StudentDTO dto);
        void Delete(string id);
        void Update(StudentDTO dto);
        StudentDTO GetBuyId(String id);

        List<StudentDTO> GetAll();
    }
}
