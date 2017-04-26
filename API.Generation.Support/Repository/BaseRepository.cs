using API.Generation.Support.Proxies;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace API.Generation.Support.Repository {

    public abstract class BaseRepository<TContext, TEntity, TKey> where TEntity : class where TContext : IDbContextDuckType {

        protected TContext Context { get; set; }

        protected IProxy<TContext, TEntity> Proxy { get; set; }

        protected BaseRepository(TContext ctx, IProxy<TContext, TEntity> proxy = null) {
            Context = ctx;
            Proxy = proxy;
        }

        public IEnumerable<TEntity> All {
            get {
                return Set;
            }
        }

        public Task<TEntity> FindAsync(TKey key, params string[] includes) {
            var query = includes.Aggregate(Set.AsQueryable(), (q, s) => q.Include(s));
            return GetAsync(query, key);
        }

        public abstract TKey GetKeyFromEntity(TEntity e);

        protected abstract Task<TEntity> GetAsync(IQueryable<TEntity> query, TKey key);

        protected abstract DbSet<TEntity> Set { get; }

        public async Task<TEntity> CreateAsync(TEntity e) {
            var c = Proxy?.PreCreate(Context, e) ?? e;
            Set.Add(c);
            await Context.SaveChangesAsync();
            return Proxy?.PostCreate(Context, c) ?? c;
        }

        public async Task<bool> UpdateAsync(TKey key, TEntity e) {
            var c = await FindAsync(GetKeyFromEntity(e));
            if (c != null) {
                c = Proxy?.PreUpdate(Context, c, e) ?? c;
                await Context.SaveChangesAsync();
                Proxy?.PostUpdate(Context, c);
            }
            return c != null;
        }

        public async Task<bool> DeleteAsync(TKey key) {
            var c = await FindAsync(key);
            if (c != null) {
                c = Proxy?.PreDelete(Context, c) ?? c;
                Set.Remove(c);
                await Context.SaveChangesAsync();
                Proxy?.PostDelete(Context, c);
            }
            return c != null;
        }
    }
}
