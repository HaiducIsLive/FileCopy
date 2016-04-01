namespace FileCopy
{
    using System.Configuration;
    using System.Data.Entity;

    public class DbModel : DbContext
    {
        public static string ConnectionString { get; set; }

        static DbModel()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DbModel"].ConnectionString;
        }

        public DbModel()
            : base(ConnectionString)
        {
        }

        public virtual DbSet<tFiles> tFiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
