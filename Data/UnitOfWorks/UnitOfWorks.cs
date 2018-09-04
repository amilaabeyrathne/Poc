using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;

namespace Data.UnitOfWorks
{
    public class UnitOfWorks : IDisposable
    {
        private testEntities context = new testEntities();
        private Repository<Student> studentRepository;

        public Repository<Student> StudentRepository
        {
            get {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new Repository<Student>(context);
                }
                return studentRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
