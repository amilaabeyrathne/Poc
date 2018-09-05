using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.DTOs;

namespace Data.Repository
{
    public class Repository<T> : IRepostory<T> where T : class
    {
        private testEntities dbEntites;
        private DbSet<T> dbSet;

        public Repository(testEntities dbEntity)
        {
            this.dbEntites = dbEntity;
            dbSet = dbEntites.Set<T>();
        }
        public void Delete(object Id)
        {
            try
            {
                T entityToDelete = dbSet.Find(Id);
                dbSet.Remove(entityToDelete);
                dbEntites.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public IEnumerable<T> GetAll()
        {
            var list =  dbSet.ToList();

            var listOut = MapToDtoList<,> (list);


            return dbSet.ToList();
        }

        public T GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T obj)
        {
            dbSet.Add(obj);
            try
            {
                dbEntites.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(T obj)
        {
            try
            {
                dbSet.Attach(obj);
                dbEntites.Entry(obj).State = EntityState.Modified;
                dbEntites.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual IEnumerable<TDto> MapToDtoList<TEntity, TDto>(IEnumerable<TEntity> entity)
            where TEntity : class
            where TDto : class
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TEntity, TDto>());
            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entity);
        }
    }
}
