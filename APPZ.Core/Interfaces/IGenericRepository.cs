//using APPZ.Core.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace APPZ.Core.Interfaces
//{
//    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
//    {
//        public GmfctnContext Context { get; set; }
//        public DbSet<TEntity> DbSet { get; set; }
//        Task<IEnumerable<TEntity>> GetAll(CancellationToken Cancel);
//        Task<TEntity> GetById(Guid Id, CancellationToken Cancel);
//        Task Create(TEntity Element, CancellationToken Cancel);
//        Task Delete(Guid Id, CancellationToken Cancel);
//        void Update(TEntity Element);
//    }
//}
