using Tekus.Domain;
using Tekus.Entities;

namespace Tekus.Application
{
    public class ServiceApplication(IDomainBase<Service> domain) : ApplicationBase<Service>(domain)
    {
    }
}
