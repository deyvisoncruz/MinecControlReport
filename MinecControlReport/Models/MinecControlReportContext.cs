using MinecControlReport.Models;
using System.Data.Entity;

namespace MinecControlReport.Models
{
    public class MineControlReportContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<kpismonitor.Models.kpismonitorContext>());

        public MineControlReportContext()
            : base("name=MineControlReportContext")
        {
        }

        public static MineControlReportContext Create()
        {
            return new MineControlReportContext();
        }

        public DbSet<kpis> kpis { get; set; }
        public DbSet<menu> menu { get; set; }
        public DbSet<menuReport> menuReport { get; set; }
        public DbSet<Parameter> parameter { get; set; }
        public DbSet<menuRole> menuRole { get; set; }
        public DbSet<PeriodTime> periodTime { get; set; }
        public DbSet<goal> goal { get; set; }
    }
}
