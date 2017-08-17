using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Fixit.Models
{
    public class FixitContext:DbContext
    {
        public FixitContext (DbContextOptions<FixitContext> context):base
        (context){}
          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeService>()
        .HasKey(bc => new { bc.employeeId, bc.serviceId });

    modelBuilder.Entity<EmployeeService>()
        .HasOne(bc => bc.employee)
        .WithMany(b => b.service)
        .HasForeignKey(bc => bc.employeeId);

    modelBuilder.Entity<EmployeeService>()
        .HasOne(bc => bc.service)
        .WithMany(c => c.employees)
        .HasForeignKey(bc => bc.serviceId);






 modelBuilder.Entity<EmployeeShift>()
        .HasKey(bc => new { bc.employeeId, bc.shiftsId });

    modelBuilder.Entity<EmployeeShift>()
        .HasOne(bc => bc.employee)
        .WithMany(b => b.employee_shift)
        .HasForeignKey(bc => bc.employeeId);

    modelBuilder.Entity<EmployeeShift>()
        .HasOne(bc => bc.shifts)
        .WithMany(c => c.employee)
        .HasForeignKey(bc => bc.shiftsId);




            modelBuilder.Entity<TaskHasEmployee>().HasKey(entity => entity.id);
            modelBuilder.Entity<TaskHasEmployee>()
       .HasOne(bc => bc.employee)
       .WithMany(b => b.task)
       .HasForeignKey(bc => bc.employeeid);

            modelBuilder.Entity<TaskHasEmployee>()
                .HasOne(bc => bc.task)
                .WithMany(c => c.services_employee)
                .HasForeignKey(bc => bc.taskid);
                 modelBuilder.Entity<TaskHasEmployee>()
                .HasOne(bc => bc.selectedservice)
                .WithMany(c => c.services_employee)
                .HasForeignKey(bc => bc.selectedserviceid);


            

        }
       
        public DbSet<CmsPages> cms_pages {get;set;}
        public DbSet<Employee> employee {get;set;}
              
        public DbSet<Features> Features {get;set;}
        public DbSet<PageHeading> page_heading {get;set;}
        public DbSet<Services> services {get;set;}
        public DbSet<Shifts> shifts {get;set;}
        public DbSet<Task> tasks {get;set;}
        public DbSet<EmployeeService> employeeService {get;set;}
        public DbSet<TaskHasEmployee> task_has_employee {get;set;}
        public DbSet<SelectedFeatures> selected_features{get;set;}
        public DbSet<EmployeeType> employeeType {get;set;}
         public DbSet<ContactUs> contactUs {get;set;}
         public DbSet<EmployeeShift> employeeShift{get;set;}
    }
}