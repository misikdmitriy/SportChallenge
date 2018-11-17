//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//namespace SportChallenge.Core.DbContexts
//{
//    public class DesignTimeSportContextFactory : IDesignTimeDbContextFactory<SportContext>
//    {
//        private readonly string _connectionString;

//        public DesignTimeSportContextFactory(string connectionString)
//        {
//            _connectionString = connectionString;
//        }

//        public SportContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<SportContext>();
//            optionsBuilder.UseSqlServer(_connectionString);

//            return new SportContext(optionsBuilder.Options);
//        }
//    }
//}
