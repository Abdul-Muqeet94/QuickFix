using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickFix.Migrations
{
    public partial class muqeet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cms_pages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    enable = table.Column<bool>(nullable: false),
                    page_content = table.Column<string>(nullable: true),
                    page_heading = table.Column<string>(nullable: true),
                    page_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_pages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contactUs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    address = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    message = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    service = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactUs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    address = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    contactNo = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    emiratesId = table.Column<string>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    nationality = table.Column<string>(nullable: true),
                    skill = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employeeType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    enable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "page_heading",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    description = table.Column<string>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    heading = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_page_heading", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    description = table.Column<string>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shifts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    day1 = table.Column<bool>(nullable: false),
                    day2 = table.Column<bool>(nullable: false),
                    day3 = table.Column<bool>(nullable: false),
                    day4 = table.Column<bool>(nullable: false),
                    day5 = table.Column<bool>(nullable: false),
                    day6 = table.Column<bool>(nullable: false),
                    day7 = table.Column<bool>(nullable: false),
                    eTime = table.Column<DateTime>(nullable: false),
                    enable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    sTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shifts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    callUpCharges = table.Column<double>(nullable: false),
                    comments = table.Column<string>(nullable: true),
                    complete = table.Column<int>(nullable: false),
                    customer_contact = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    endTime = table.Column<DateTime>(nullable: false),
                    house_no = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    landmark = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    paymentStatus = table.Column<int>(nullable: false),
                    shift = table.Column<string>(nullable: true),
                    startTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employeeService",
                columns: table => new
                {
                    employeeId = table.Column<int>(nullable: false),
                    serviceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeService", x => new { x.employeeId, x.serviceId });
                    table.ForeignKey(
                        name: "FK_employeeService_employee_employeeId",
                        column: x => x.employeeId,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employeeService_services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Servicesid = table.Column<int>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    enable = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.id);
                    table.ForeignKey(
                        name: "FK_Features_services_Servicesid",
                        column: x => x.Servicesid,
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employeeShift",
                columns: table => new
                {
                    employeeId = table.Column<int>(nullable: false),
                    shiftsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeShift", x => new { x.employeeId, x.shiftsId });
                    table.ForeignKey(
                        name: "FK_employeeShift_employee_employeeId",
                        column: x => x.employeeId,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employeeShift_shifts_shiftsId",
                        column: x => x.shiftsId,
                        principalTable: "shifts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "task_has_employee",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    employeeid = table.Column<int>(nullable: false),
                    enable = table.Column<bool>(nullable: false),
                    selected_shiftid = table.Column<int>(nullable: true),
                    selectedserviceid = table.Column<int>(nullable: false),
                    taskid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task_has_employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_task_has_employee_employee_employeeid",
                        column: x => x.employeeid,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_task_has_employee_shifts_selected_shiftid",
                        column: x => x.selected_shiftid,
                        principalTable: "shifts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_task_has_employee_services_selectedserviceid",
                        column: x => x.selectedserviceid,
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_task_has_employee_tasks_taskid",
                        column: x => x.taskid,
                        principalTable: "tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "selected_features",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    enable = table.Column<bool>(nullable: false),
                    featuresid = table.Column<int>(nullable: false),
                    taskhasemployeeid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_selected_features", x => x.id);
                    table.ForeignKey(
                        name: "FK_selected_features_Features_featuresid",
                        column: x => x.featuresid,
                        principalTable: "Features",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_selected_features_task_has_employee_taskhasemployeeid",
                        column: x => x.taskhasemployeeid,
                        principalTable: "task_has_employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employeeService_serviceId",
                table: "employeeService",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_employeeShift_shiftsId",
                table: "employeeShift",
                column: "shiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_Servicesid",
                table: "Features",
                column: "Servicesid");

            migrationBuilder.CreateIndex(
                name: "IX_selected_features_featuresid",
                table: "selected_features",
                column: "featuresid");

            migrationBuilder.CreateIndex(
                name: "IX_selected_features_taskhasemployeeid",
                table: "selected_features",
                column: "taskhasemployeeid");

            migrationBuilder.CreateIndex(
                name: "IX_task_has_employee_employeeid",
                table: "task_has_employee",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_task_has_employee_selected_shiftid",
                table: "task_has_employee",
                column: "selected_shiftid");

            migrationBuilder.CreateIndex(
                name: "IX_task_has_employee_selectedserviceid",
                table: "task_has_employee",
                column: "selectedserviceid");

            migrationBuilder.CreateIndex(
                name: "IX_task_has_employee_taskid",
                table: "task_has_employee",
                column: "taskid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cms_pages");

            migrationBuilder.DropTable(
                name: "contactUs");

            migrationBuilder.DropTable(
                name: "employeeService");

            migrationBuilder.DropTable(
                name: "employeeShift");

            migrationBuilder.DropTable(
                name: "employeeType");

            migrationBuilder.DropTable(
                name: "page_heading");

            migrationBuilder.DropTable(
                name: "selected_features");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "task_has_employee");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "shifts");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "tasks");
        }
    }
}
