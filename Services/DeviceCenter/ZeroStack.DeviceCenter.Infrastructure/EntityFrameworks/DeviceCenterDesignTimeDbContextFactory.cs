using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ZeroStack.DeviceCenter.Infrastructure.EntityFrameworks
{
    public class DeviceCenterDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DeviceCenterDbContext>
    {
        public DeviceCenterDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DeviceCenterDbContext>();

            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=DeviceCenter;Trusted_Connection=True");

            return new DeviceCenterDbContext(optionsBuilder.Options);
        }
    }
}
