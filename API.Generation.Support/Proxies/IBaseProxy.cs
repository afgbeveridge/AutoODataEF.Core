namespace API.Generation.Support.Proxies {
    public interface IBaseProxy<TContext, TEntity> where TEntity : class {
        TEntity PreCreate(TContext ctx, TEntity entity);
        TEntity PostCreate(TContext ctx, TEntity entity);
        TEntity PreUpdate(TContext ctx, TEntity existing, TEntity updated);
        TEntity PostUpdate(TContext ctx, TEntity entity);
        TEntity PreDelete(TContext ctx, TEntity entity);
        TEntity PostDelete(TContext ctx, TEntity entity);
    }
}
