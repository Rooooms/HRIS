using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class hristable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    CCNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PromoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DesigDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SepDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SalesDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsEvaluation = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlateNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OffIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OffOut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseFlag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Adjustment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckDGT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfDays = table.Column<int>(type: "int", nullable: false),
                    PayType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserLevel = table.Column<int>(type: "int", nullable: false),
                    POB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CivilStat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Citizenship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpouseAge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpouseOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChildName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChildAge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherAge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherAge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medical = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalPurpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MajorIllness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmerPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmerPersonNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAcc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAcc2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sssNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exemption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tinNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pagibiNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payper = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    philhealth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPayroll = table.Column<bool>(type: "bit", nullable: false),
                    IsNoTax = table.Column<bool>(type: "bit", nullable: false),
                    IsNoSSS = table.Column<bool>(type: "bit", nullable: false),
                    IsNoPremium = table.Column<bool>(type: "bit", nullable: false),
                    IsExcludeSmanped = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Details_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApexMerches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRAM = table.Column<bool>(type: "bit", nullable: false),
                    IsMitra = table.Column<bool>(type: "bit", nullable: false),
                    IsSevilla = table.Column<bool>(type: "bit", nullable: false),
                    IsVar = table.Column<bool>(type: "bit", nullable: false),
                    IsInfini = table.Column<bool>(type: "bit", nullable: false),
                    RamPercent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOutlet = table.Column<int>(type: "int", nullable: false),
                    SevPercent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    varAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    infiniAmount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApexMerches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApexMerches_Employee_Details_EmployeeDetailsId",
                        column: x => x.EmployeeDetailsId,
                        principalTable: "Employee_Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BenefitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BenefitAmount = table.Column<double>(type: "float", nullable: false),
                    DateGiven = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Benefits_Employee_Details_EmployeeDetailsId",
                        column: x => x.EmployeeDetailsId,
                        principalTable: "Employee_Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationalBackground",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradSchool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    License = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElemInstitute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElemLoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElemDateInc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    elemAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HsInstitute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HsLoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HsDateInc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HsAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerInstitute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerLoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerDateInc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerAchievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalBackground", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalBackground_Employee_Details_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee_Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentBackgrounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrevCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatOfBusiness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrevPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrevSalary = table.Column<double>(type: "float", nullable: false),
                    IncDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasOfLeave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contribution = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentBackgrounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploymentBackgrounds_Employee_Details_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee_Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paymasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fixTaxRate = table.Column<double>(type: "float", nullable: false),
                    baseMonthly = table.Column<double>(type: "float", nullable: false),
                    base15th = table.Column<double>(type: "float", nullable: false),
                    baseMonthEnd = table.Column<double>(type: "float", nullable: false),
                    colaMonthly = table.Column<double>(type: "float", nullable: false),
                    cola15th = table.Column<double>(type: "float", nullable: false),
                    colaMonthEnd = table.Column<double>(type: "float", nullable: false),
                    empShare = table.Column<double>(type: "float", nullable: false),
                    medAllowance = table.Column<double>(type: "float", nullable: false),
                    dailyShare = table.Column<double>(type: "float", nullable: false),
                    depName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    depBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ctcNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rateType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    placeIssue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payslipPinNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    excPayrollProcess = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paymasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paymasts_Employee_Details_EmployeeDetailsId",
                        column: x => x.EmployeeDetailsId,
                        principalTable: "Employee_Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    polygraph = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhyExam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sssNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidentCert = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrvLicense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpCert = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ITR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhilhealthNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagibigNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nbi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarriageCert = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clearance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPolygraph = table.Column<bool>(type: "bit", nullable: false),
                    IsPhyExam = table.Column<bool>(type: "bit", nullable: false),
                    IsSSSNo = table.Column<bool>(type: "bit", nullable: false),
                    IsResidentCert = table.Column<bool>(type: "bit", nullable: false),
                    IsTOR = table.Column<bool>(type: "bit", nullable: false),
                    IsDrvLicense = table.Column<bool>(type: "bit", nullable: false),
                    IsEmpCert = table.Column<bool>(type: "bit", nullable: false),
                    IsITR = table.Column<bool>(type: "bit", nullable: false),
                    IsTinNo = table.Column<bool>(type: "bit", nullable: false),
                    IsPhilhealthNo = table.Column<bool>(type: "bit", nullable: false),
                    IsPic = table.Column<bool>(type: "bit", nullable: false),
                    IsPagibig = table.Column<bool>(type: "bit", nullable: false),
                    IsNbi = table.Column<bool>(type: "bit", nullable: false),
                    IsMarriageCert = table.Column<bool>(type: "bit", nullable: false),
                    IsClearance = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requirements_Employee_Details_EmployeeDetailsId",
                        column: x => x.EmployeeDetailsId,
                        principalTable: "Employee_Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fixrate = table.Column<double>(type: "float", nullable: false),
                    PayType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monthly = table.Column<double>(type: "float", nullable: false),
                    MidMonth = table.Column<double>(type: "float", nullable: false),
                    EndMonth = table.Column<double>(type: "float", nullable: false),
                    OTRate = table.Column<double>(type: "float", nullable: false),
                    DailyRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salaries_Employee_Details_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee_Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Employee_Details_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee_Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    UserLevel = table.Column<int>(type: "int", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastSubmissionMonth = table.Column<int>(type: "int", nullable: false),
                    LastSubmissionYear = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Credit = table.Column<double>(type: "float", nullable: false),
                    ResOfCancel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApexMerches_EmployeeDetailsId",
                table: "ApexMerches",
                column: "EmployeeDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_EmployeeDetailsId",
                table: "Benefits",
                column: "EmployeeDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CompanyId",
                table: "Branches",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalBackground_EmployeeId",
                table: "EducationalBackground",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Details_CompanyId",
                table: "Employee_Details",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentBackgrounds_EmployeeId",
                table: "EmploymentBackgrounds",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_UserId",
                table: "Leaves",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Paymasts_EmployeeDetailsId",
                table: "Paymasts",
                column: "EmployeeDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_EmployeeDetailsId",
                table: "Requirements",
                column: "EmployeeDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeId",
                table: "Salaries",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_EmployeeId",
                table: "User",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApexMerches");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "EducationalBackground");

            migrationBuilder.DropTable(
                name: "EmploymentBackgrounds");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "Paymasts");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Employee_Details");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
