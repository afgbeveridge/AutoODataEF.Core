namespace API.Generation.Support.Proxies {
    public class Proxy<TContext, TEntity> : IProxy<TContext, TEntity> where TEntity : class {
        private IInterventionProxy<TContext, TEntity> Intervener { get; set; }
        public Proxy(IInterventionProxy<TContext, TEntity> proxy = null) {
            Intervener = proxy;
        }
        public virtual TEntity PreCreate(TContext ctx, TEntity entity) { return Intervener?.PreCreate(ctx, entity) ?? entity; }
        public virtual TEntity PostCreate(TContext ctx, TEntity entity) { return Intervener?.PostCreate(ctx, entity) ?? entity; }
        public virtual TEntity PreUpdate(TContext ctx, TEntity existing, TEntity updated) { return Intervener?.PreUpdate(ctx, existing, updated) ?? updated; }
        public virtual TEntity PostUpdate(TContext ctx, TEntity entity) { return Intervener?.PostUpdate(ctx, entity) ?? entity; }
        public virtual TEntity PreDelete(TContext ctx, TEntity entity) { return Intervener?.PreDelete(ctx, entity) ?? entity; }
        public virtual TEntity PostDelete(TContext ctx, TEntity entity) { return Intervener?.PostDelete(ctx, entity) ?? entity; }
    }
}
