using API.Generation.Support.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Generation.Support.Mvc {

    public class BaseController<TContext, TEntity, TKey, TRepo> : Controller where TRepo : IBaseRepository<TContext, TEntity, TKey> {

        protected IBaseRepository<TContext, TEntity, TKey> Repository { get; private set; }

        public BaseController(IBaseRepository<TContext, TEntity, TKey> repo) {
            Repository = repo;
        }

        [HttpGet]
        public IEnumerable<TEntity> Get() {
            return Repository.All;
        }

        [ODataRoute("({key})")]
        public async Task<IActionResult> GetEntity(TKey key) {
            var entity = await Repository.FindAsync(key);
            return entity == null ? (IActionResult)NotFound() : new ObjectResult(entity);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TEntity value) {
            var entity = await Repository.CreateAsync(value);
            var locationUri = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.Path}({this.Repository.GetKeyFromEntity(entity)})";
            return Created(locationUri, entity);
        }

        [HttpPut("{key}")]
        public async Task<IActionResult> Put(TKey key, [FromBody] TEntity value) {
            return !await Repository.UpdateAsync(key, value) ? (IActionResult)NotFound() : new NoContentResult();
        }

        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete(TKey key) {
            return !await Repository.DeleteAsync(key) ? (IActionResult)NotFound() : new NoContentResult();
        }
    }
}
