namespace API.Generation.Support.Proxies {
    public interface IProxy<TContext, TEntity> : IBaseProxy<TContext, TEntity> where TEntity : class {
    }
}
