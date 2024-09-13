using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PassportAPK.API.Migrations
{
    /// <inheritdoc />
    public partial class InItDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantDetails",
                columns: table => new
                {
                    ApplicantDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsAliasName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AliasName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsChangedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PanCardNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    VoterId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AdharCardNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    MaritialStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EducationQualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Citizenship = table.Column<int>(type: "int", nullable: false),
                    IsNonECR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistinguishMark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parentOrSpouseGovServant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfIssue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantDetails", x => x.ApplicantDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContactDetails",
                columns: table => new
                {
                    EmergencyContactDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContactDetails", x => x.EmergencyContactDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "FamilyDetails",
                columns: table => new
                {
                    FamilyDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FatherFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FatherLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotherFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotherLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LegalGuardianFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LegalGuardianLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpouceFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpouceLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDetails", x => x.FamilyDetailId);
                });

            migrationBuilder.CreateTable(
                name: "OtherDetails",
                columns: table => new
                {
                    OtherDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCriminalProceedings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsWarrantSummons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsArrestWarrant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDepartureOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConviction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPassportRefusal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPassportImpounded = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPassportRevoked = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsForeignCitizenship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOtherPassport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSurrenderedPassport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRenunciation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmergencyCertificate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeported = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRepatriated = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherDetails", x => x.OtherDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "ResidentailDetails",
                columns: table => new
                {
                    ResidentialDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseNoAndName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressLane1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentailDetails", x => x.ResidentialDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "SelfDeclarations",
                columns: table => new
                {
                    SelfDeclarationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAcceptTermsAndCondition = table.Column<bool>(type: "bit", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfApplied = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelfDeclarations", x => x.SelfDeclarationId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequireds",
                columns: table => new
                {
                    ServiceRequiredId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagesRequired = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidityRequired = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForReNewal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangeInAppreance = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequireds", x => x.ServiceRequiredId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FeedbackDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FeedbackStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterDetailsTables",
                columns: table => new
                {
                    MasterDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PassportApplicationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceRequiredId = table.Column<int>(type: "int", nullable: false),
                    ApplicantDetailsId = table.Column<int>(type: "int", nullable: false),
                    FamilyDetailId = table.Column<int>(type: "int", nullable: false),
                    FamilyDetailsFamilyDetailId = table.Column<int>(type: "int", nullable: true),
                    EmergencyContactDetailsId = table.Column<int>(type: "int", nullable: false),
                    OtherDetailsId = table.Column<int>(type: "int", nullable: false),
                    ResidentialDetailsId = table.Column<int>(type: "int", nullable: false),
                    ResidentailDetailsResidentialDetailsId = table.Column<int>(type: "int", nullable: true),
                    SelfDeclarationId = table.Column<int>(type: "int", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterDetailsTables", x => x.MasterDetailsId);
                    table.ForeignKey(
                        name: "FK_MasterDetailsTables_ApplicantDetails_ApplicantDetailsId",
                        column: x => x.ApplicantDetailsId,
                        principalTable: "ApplicantDetails",
                        principalColumn: "ApplicantDetailsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterDetailsTables_EmergencyContactDetails_EmergencyContactDetailsId",
                        column: x => x.EmergencyContactDetailsId,
                        principalTable: "EmergencyContactDetails",
                        principalColumn: "EmergencyContactDetailsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterDetailsTables_FamilyDetails_FamilyDetailsFamilyDetailId",
                        column: x => x.FamilyDetailsFamilyDetailId,
                        principalTable: "FamilyDetails",
                        principalColumn: "FamilyDetailId");
                    table.ForeignKey(
                        name: "FK_MasterDetailsTables_OtherDetails_OtherDetailsId",
                        column: x => x.OtherDetailsId,
                        principalTable: "OtherDetails",
                        principalColumn: "OtherDetailsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterDetailsTables_ResidentailDetails_ResidentailDetailsResidentialDetailsId",
                        column: x => x.ResidentailDetailsResidentialDetailsId,
                        principalTable: "ResidentailDetails",
                        principalColumn: "ResidentialDetailsId");
                    table.ForeignKey(
                        name: "FK_MasterDetailsTables_SelfDeclarations_SelfDeclarationId",
                        column: x => x.SelfDeclarationId,
                        principalTable: "SelfDeclarations",
                        principalColumn: "SelfDeclarationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterDetailsTables_ServiceRequireds_ServiceRequiredId",
                        column: x => x.ServiceRequiredId,
                        principalTable: "ServiceRequireds",
                        principalColumn: "ServiceRequiredId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterDetailsTables_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9360f098-91cf-43fd-96f1-c2dacab82cac", null, "User", "USER" },
                    { "fd27d043-528d-4b89-b954-a4bead9acc78", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetailsTables_ApplicantDetailsId",
                table: "MasterDetailsTables",
                column: "ApplicantDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetailsTables_EmergencyContactDetailsId",
                table: "MasterDetailsTables",
                column: "EmergencyContactDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetailsTables_FamilyDetailsFamilyDetailId",
                table: "MasterDetailsTables",
                column: "FamilyDetailsFamilyDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetailsTables_OtherDetailsId",
                table: "MasterDetailsTables",
                column: "OtherDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetailsTables_ResidentailDetailsResidentialDetailsId",
                table: "MasterDetailsTables",
                column: "ResidentailDetailsResidentialDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetailsTables_SelfDeclarationId",
                table: "MasterDetailsTables",
                column: "SelfDeclarationId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetailsTables_ServiceRequiredId",
                table: "MasterDetailsTables",
                column: "ServiceRequiredId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetailsTables_UserId",
                table: "MasterDetailsTables",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApplicationUserId",
                table: "Users",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "MasterDetailsTables");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ApplicantDetails");

            migrationBuilder.DropTable(
                name: "EmergencyContactDetails");

            migrationBuilder.DropTable(
                name: "FamilyDetails");

            migrationBuilder.DropTable(
                name: "OtherDetails");

            migrationBuilder.DropTable(
                name: "ResidentailDetails");

            migrationBuilder.DropTable(
                name: "SelfDeclarations");

            migrationBuilder.DropTable(
                name: "ServiceRequireds");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
