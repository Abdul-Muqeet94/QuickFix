using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Fixit.Models;

namespace Fixit.Migrations
{
    [DbContext(typeof(FixitContext))]
    [Migration("20170721134659_muqeet")]
    partial class muqeet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Fixit.Models.CmsPages", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("enable");

                    b.Property<string>("page_content");

                    b.Property<string>("page_heading");

                    b.Property<string>("page_name");

                    b.HasKey("id");

                    b.ToTable("cms_pages");
                });

            modelBuilder.Entity("Fixit.Models.ContactUs", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<string>("email");

                    b.Property<bool>("enable");

                    b.Property<string>("message");

                    b.Property<string>("name");

                    b.Property<string>("phone");

                    b.Property<string>("service");

                    b.HasKey("id");

                    b.ToTable("contactUs");
                });

            modelBuilder.Entity("Fixit.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<string>("code");

                    b.Property<string>("contactNo");

                    b.Property<string>("email");

                    b.Property<string>("emiratesId");

                    b.Property<bool>("enable");

                    b.Property<string>("name");

                    b.Property<string>("nationality");

                    b.Property<bool>("status");

                    b.HasKey("id");

                    b.ToTable("employee");
                });

            modelBuilder.Entity("Fixit.Models.EmployeeService", b =>
                {
                    b.Property<int>("employeeId");

                    b.Property<int>("serviceId");

                    b.HasKey("employeeId", "serviceId");

                    b.HasIndex("serviceId");

                    b.ToTable("employeeService");
                });

            modelBuilder.Entity("Fixit.Models.EmployeeShift", b =>
                {
                    b.Property<int>("employeeId");

                    b.Property<int>("shiftsId");

                    b.HasKey("employeeId", "shiftsId");

                    b.HasIndex("shiftsId");

                    b.ToTable("employeeShift");
                });

            modelBuilder.Entity("Fixit.Models.EmployeeType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("enable");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("employeeType");
                });

            modelBuilder.Entity("Fixit.Models.Features", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Servicesid");

                    b.Property<string>("description");

                    b.Property<bool>("enable");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.HasIndex("Servicesid");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("Fixit.Models.PageHeading", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<bool>("enable");

                    b.Property<string>("heading");

                    b.HasKey("id");

                    b.ToTable("page_heading");
                });

            modelBuilder.Entity("Fixit.Models.SelectedFeatures", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("enable");

                    b.Property<int>("featuresid");

                    b.Property<int>("taskhasemployeeid");

                    b.HasKey("id");

                    b.HasIndex("featuresid");

                    b.HasIndex("taskhasemployeeid");

                    b.ToTable("selected_features");
                });

            modelBuilder.Entity("Fixit.Models.Services", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<bool>("enable");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("services");
                });

            modelBuilder.Entity("Fixit.Models.Shifts", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("day1");

                    b.Property<bool>("day2");

                    b.Property<bool>("day3");

                    b.Property<bool>("day4");

                    b.Property<bool>("day5");

                    b.Property<bool>("day6");

                    b.Property<bool>("day7");

                    b.Property<DateTime>("eTime");

                    b.Property<bool>("enable");

                    b.Property<string>("name");

                    b.Property<DateTime>("sTime");

                    b.HasKey("id");

                    b.ToTable("shifts");
                });

            modelBuilder.Entity("Fixit.Models.Task", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("callUpCharges");

                    b.Property<string>("comments");

                    b.Property<int>("complete");

                    b.Property<string>("customer_contact");

                    b.Property<DateTime>("date");

                    b.Property<string>("email");

                    b.Property<bool>("enable");

                    b.Property<DateTime>("endTime");

                    b.Property<string>("house_no");

                    b.Property<string>("landmark");

                    b.Property<string>("location");

                    b.Property<string>("name");

                    b.Property<int>("paymentStatus");

                    b.Property<string>("shift");

                    b.Property<DateTime>("startTime");

                    b.HasKey("id");

                    b.ToTable("tasks");
                });

            modelBuilder.Entity("Fixit.Models.TaskHasEmployee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("employeeid");

                    b.Property<bool>("enable");

                    b.Property<int?>("selected_shiftid");

                    b.Property<int>("selectedserviceid");

                    b.Property<int>("taskid");

                    b.HasKey("id");

                    b.HasIndex("employeeid");

                    b.HasIndex("selected_shiftid");

                    b.HasIndex("selectedserviceid");

                    b.HasIndex("taskid");

                    b.ToTable("task_has_employee");
                });

            modelBuilder.Entity("Fixit.Models.EmployeeService", b =>
                {
                    b.HasOne("Fixit.Models.Employee", "employee")
                        .WithMany("service")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fixit.Models.Services", "service")
                        .WithMany("employees")
                        .HasForeignKey("serviceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fixit.Models.EmployeeShift", b =>
                {
                    b.HasOne("Fixit.Models.Employee", "employee")
                        .WithMany("employee_shift")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fixit.Models.Shifts", "shifts")
                        .WithMany("employee")
                        .HasForeignKey("shiftsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fixit.Models.Features", b =>
                {
                    b.HasOne("Fixit.Models.Services")
                        .WithMany("features")
                        .HasForeignKey("Servicesid");
                });

            modelBuilder.Entity("Fixit.Models.SelectedFeatures", b =>
                {
                    b.HasOne("Fixit.Models.Features", "features")
                        .WithMany("selected_features")
                        .HasForeignKey("featuresid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fixit.Models.TaskHasEmployee", "taskhasemployee")
                        .WithMany("selected_features")
                        .HasForeignKey("taskhasemployeeid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fixit.Models.TaskHasEmployee", b =>
                {
                    b.HasOne("Fixit.Models.Employee", "employee")
                        .WithMany("task")
                        .HasForeignKey("employeeid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fixit.Models.Shifts", "selected_shift")
                        .WithMany()
                        .HasForeignKey("selected_shiftid");

                    b.HasOne("Fixit.Models.Services", "selectedservice")
                        .WithMany("services_employee")
                        .HasForeignKey("selectedserviceid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fixit.Models.Task", "task")
                        .WithMany("services_employee")
                        .HasForeignKey("taskid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
