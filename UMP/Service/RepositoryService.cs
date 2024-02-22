
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UMP.Data;

namespace UMP.Service
{
    public class RepositoryService<TEntity, IModel> : IRepositoryService<TEntity, IModel> where TEntity : class, new() where IModel : class
    {
        private readonly ApplicationDbContext _context; 
        private readonly IMapper _mapper;

        public RepositoryService(IMapper mapper,ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context; 
            _dbSet = _context.Set<TEntity>();
        }

        private DbSet<TEntity> _dbSet { get; }

        public async Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entity=await _dbSet.ToListAsync(cancellationToken);
            if (entity==null)
            {
                return null;
            }
            var data = _mapper.Map<IEnumerable<IModel>>(entity);
            return data;    
        }

        public async Task<IModel> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return null;
            var data= _mapper.Map<TEntity,IModel>(entity);
            return data;
        }

        public async Task<IModel> InsertAsync(IModel model, CancellationToken cancellationToken)
        {
           var entity= _mapper.Map<IModel,TEntity>(model);
            _dbSet.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            // when entity source and Imodel Destination
            var data=_mapper.Map<TEntity, IModel>(entity);
            return data;
        }

        public async Task<IModel> UpdateAsync(int id, IModel model, CancellationToken cancellationToken)
        {
            var entity =await _dbSet.FindAsync(id);
            if (entity == null) return null;
            _mapper.Map(model, entity);
            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            var data = _mapper.Map<TEntity, IModel>(entity);
            return data;
        }

        public async Task<IModel>Delete(int id,CancellationToken cancellation)
        {
            var entity= await _dbSet.FindAsync(id);
            if (entity==null)
            {
                return null;
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellation);
            var data=_mapper.Map<TEntity,IModel>(entity);
            return data;
        }
    }
}
