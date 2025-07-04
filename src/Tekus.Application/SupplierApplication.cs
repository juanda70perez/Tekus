using Tekus.Domain;
using Tekus.Entities;

namespace Tekus.Application
{
    public class SupplierApplication(IDomainBase<Supplier> domain): ApplicationBase<Supplier>(domain)
    {
    }
}