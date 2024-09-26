using EFCoreRelationshipsPractice.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreRelationshipsPracticeTest
{
    public class TestBase : IClassFixture<CustomWebApplicationFactory<Program>>, IDisposable
    {
        public TestBase(CustomWebApplicationFactory<Program> factory)
        {
            this.Factory = factory;
        }

        protected CustomWebApplicationFactory<Program> Factory { get; }

        public void Dispose()
        {
            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<CompanyDbContext>();
            context.EmployeeEntities.RemoveRange(context.EmployeeEntities);
            context.CompanyEntities.RemoveRange(context.CompanyEntities);
            context.ProfileEntities.RemoveRange(context.ProfileEntities);
            context.SaveChanges();

        }

        protected HttpClient GetClient()
        {
            return Factory.CreateClient();
        }
    }
}