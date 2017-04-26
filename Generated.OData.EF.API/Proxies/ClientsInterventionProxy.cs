using API.Generation.Support.Proxies;
using EF.Example;

namespace Generated.OData.EF.API.Proxies
{
    public class ClientsInterventionProxy : IInterventionProxy<ICompanyContext, Customer> {
        public Customer PreCreate(ICompanyContext ctx, Customer entity) {
            return entity;
        }
        public Customer PostCreate(ICompanyContext ctx, Customer entity) { return entity; }
        public Customer PreUpdate(ICompanyContext ctx, Customer existing, Customer updated) { return updated; }
        public Customer PostUpdate(ICompanyContext ctx, Customer entity) { return entity; }
        public Customer PreDelete(ICompanyContext ctx, Customer entity) { return entity; }
        public Customer PostDelete(ICompanyContext ctx, Customer entity) { return entity; }
    }
    
}
