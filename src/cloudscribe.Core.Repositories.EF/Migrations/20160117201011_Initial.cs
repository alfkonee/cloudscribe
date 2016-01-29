using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace cloudscribe.Core.Repositories.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mp_Currency",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Code = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()"),
                    DecimalPlaces = table.Column<string>(nullable: true),
                    DecimalPointChar = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()"),
                    SymbolLeft = table.Column<string>(nullable: true),
                    SymbolRight = table.Column<string>(nullable: true),
                    ThousandsPointChar = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Guid);
                });
            migrationBuilder.CreateTable(
                name: "mp_GeoCountry",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ISOCode2 = table.Column<string>(nullable: false),
                    ISOCode3 = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoCountry", x => x.Guid);
                });
            migrationBuilder.CreateTable(
                name: "mp_GeoZone",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Code = table.Column<string>(nullable: false),
                    CountryGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoZone", x => x.Guid);
                });
            migrationBuilder.CreateTable(
                name: "mp_Language",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Guid);
                });
            migrationBuilder.CreateTable(
                name: "mp_SiteFolders",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    FolderName = table.Column<string>(nullable: false),
                    SiteGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteFolder", x => x.Guid);
                });
            migrationBuilder.CreateTable(
                name: "mp_SiteHosts",
                columns: table => new
                {
                    HostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HostName = table.Column<string>(nullable: false),
                    SiteGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteHost", x => x.HostID);
                });
            migrationBuilder.CreateTable(
                name: "mp_Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(nullable: false),
                    RoleGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    RoleName = table.Column<string>(nullable: false),
                    SiteGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteRole", x => x.RoleID);
                });
            migrationBuilder.CreateTable(
                name: "mp_Sites",
                columns: table => new
                {
                    SiteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddThisDotComUsername = table.Column<string>(nullable: true),
                    AllowDbFallbackWithLdap = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    AllowNewRegistration = table.Column<bool>(type: "bit", nullable: false, defaultValue: 1),
                    AllowPersistentLogin = table.Column<bool>(type: "bit", nullable: false, defaultValue: 1),
                    AllowUserFullNameChange = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    ApiKeyExtra1 = table.Column<string>(nullable: true),
                    ApiKeyExtra2 = table.Column<string>(nullable: true),
                    ApiKeyExtra3 = table.Column<string>(nullable: true),
                    ApiKeyExtra4 = table.Column<string>(nullable: true),
                    ApiKeyExtra5 = table.Column<string>(nullable: true),
                    AutoCreateLdapUserOnFirstLogin = table.Column<bool>(type: "bit", nullable: false, defaultValue: 1),
                    CaptchaOnLogin = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    CaptchaOnRegistration = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    CompanyCountry = table.Column<string>(nullable: true),
                    CompanyFax = table.Column<string>(nullable: true),
                    CompanyLocality = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyPhone = table.Column<string>(nullable: true),
                    CompanyPostalCode = table.Column<string>(nullable: true),
                    CompanyPublicEmail = table.Column<string>(nullable: true),
                    CompanyRegion = table.Column<string>(nullable: true),
                    CompanyStreetAddress = table.Column<string>(nullable: true),
                    CompanyStreetAddress2 = table.Column<string>(nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()"),
                    DefaultEmailFromAddress = table.Column<string>(nullable: true),
                    DisableDbAuth = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    EmailLdapDbFallback = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    FacebookAppId = table.Column<string>(nullable: true),
                    FacebookAppSecret = table.Column<string>(nullable: true),
                    GoogleAnalyticsProfileId = table.Column<string>(nullable: true),
                    GoogleClientId = table.Column<string>(nullable: true),
                    GoogleClientSecret = table.Column<string>(nullable: true),
                    IsDataProtected = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    IsServerAdminSite = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    Skin = table.Column<string>(nullable: true),
                    LdapDomain = table.Column<string>(nullable: true),
                    LdapPort = table.Column<int>(type: "int", nullable: false, defaultValue: 389),
                    LdapRootDN = table.Column<string>(nullable: true),
                    LdapServer = table.Column<string>(nullable: true),
                    LdapUserDNKey = table.Column<string>(nullable: true),
                    LoginInfoBottom = table.Column<string>(nullable: true),
                    LoginInfoTop = table.Column<string>(nullable: true),
                    MaxInvalidPasswordAttempts = table.Column<int>(type: "int", nullable: false, defaultValue: 5),
                    MicrosoftClientId = table.Column<string>(nullable: true),
                    MicrosoftClientSecret = table.Column<string>(nullable: true),
                    MinReqNonAlphaChars = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MinRequiredPasswordLength = table.Column<int>(type: "int", nullable: false, defaultValue: 5),
                    PasswordAttemptWindowMinutes = table.Column<int>(type: "int", nullable: false, defaultValue: 5),
                    PreferredHostName = table.Column<string>(nullable: true),
                    PrivacyPolicy = table.Column<string>(nullable: true),
                    ReallyDeleteUsers = table.Column<bool>(type: "bit", nullable: false, defaultValue: 1),
                    RecaptchaPrivateKey = table.Column<string>(nullable: true),
                    RecaptchaPublicKey = table.Column<string>(nullable: true),
                    RegistrationAgreement = table.Column<string>(nullable: true),
                    RegistrationPreamble = table.Column<string>(nullable: true),
                    RequireApprovalBeforeLogin = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    RequiresQuestionAndAnswer = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    SiteFolderName = table.Column<string>(nullable: true, defaultValue: ""),
                    SiteGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    SiteIsClosed = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    SiteIsClosedMessage = table.Column<string>(nullable: true),
                    SiteName = table.Column<string>(nullable: false),
                    SmtpPassword = table.Column<string>(nullable: true),
                    SmtpPort = table.Column<int>(type: "int", nullable: false, defaultValue: 25),
                    SmtpPreferredEncoding = table.Column<string>(nullable: true),
                    SmtpRequiresAuth = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    SmtpServer = table.Column<string>(nullable: true),
                    SmtpUseSsl = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    SmtpUser = table.Column<string>(nullable: true),
                    TimeZoneId = table.Column<string>(nullable: true),
                    TwitterConsumerKey = table.Column<string>(nullable: true),
                    TwitterConsumerSecret = table.Column<string>(nullable: true),
                    UseEmailForLogin = table.Column<bool>(type: "bit", nullable: false, defaultValue: 1),
                    UseLdapAuth = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    UseSecureRegistration = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0),
                    UseSSLOnAllPages = table.Column<bool>(type: "bit", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.SiteID);
                });
            migrationBuilder.CreateTable(
                name: "mp_Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountApproved = table.Column<bool>(nullable: false),
                    AuthorBio = table.Column<string>(nullable: true),
                    AvatarUrl = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DisplayInMemberList = table.Column<bool>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailChangeGuid = table.Column<Guid>(nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FailedPasswordAnswerAttemptCount = table.Column<int>(nullable: false),
                    FailedPasswordAnswerAttemptWindowStart = table.Column<DateTime>(nullable: false),
                    FailedPasswordAttemptCount = table.Column<int>(nullable: false),
                    FailedPasswordAttemptWindowStart = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsLockedOut = table.Column<bool>(nullable: false),
                    LastActivityDate = table.Column<DateTime>(nullable: false),
                    LastLockoutDate = table.Column<DateTime>(nullable: false),
                    LastLoginDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    LastPasswordChangedDate = table.Column<DateTime>(nullable: false),
                    LockoutEndDateUtc = table.Column<DateTime>(nullable: true),
                    LoweredEmail = table.Column<string>(nullable: true),
                    MustChangePwd = table.Column<bool>(nullable: false),
                    NewEmail = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordResetGuid = table.Column<Guid>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    RegisterConfirmGuid = table.Column<Guid>(nullable: false),
                    RolesChanged = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    Signature = table.Column<string>(nullable: true),
                    SiteGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteID = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(nullable: true),
                    TimeZoneId = table.Column<string>(nullable: true),
                    Trusted = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    UserName = table.Column<string>(nullable: true),
                    WebSiteUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteUser", x => x.UserID);
                });
            migrationBuilder.CreateTable(
                name: "mp_UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    SiteId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "mp_UserLocation",
                columns: table => new
                {
                    RowID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    CaptureCount = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Continent = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    FirstCaptureUTC = table.Column<DateTime>(nullable: false),
                    HostName = table.Column<string>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    IPAddressLong = table.Column<long>(nullable: false),
                    ISP = table.Column<string>(nullable: true),
                    LastCaptureUTC = table.Column<DateTime>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Region = table.Column<string>(nullable: true),
                    SiteGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeZone = table.Column<string>(nullable: true),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLocation", x => x.RowID);
                });
            migrationBuilder.CreateTable(
                name: "mp_UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    SiteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey, x.UserId });
                });
            migrationBuilder.CreateTable(
                name: "mp_UserRoles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.ID);
                });
            migrationBuilder.CreateIndex(
                name: "IX_GeoCountry_ISOCode2",
                table: "mp_GeoCountry",
                column: "ISOCode2");
            migrationBuilder.CreateIndex(
                name: "IX_GeoZone_CountryGuid",
                table: "mp_GeoZone",
                column: "CountryGuid");
            migrationBuilder.CreateIndex(
                name: "IX_SiteRole_RoleGuid",
                table: "mp_Roles",
                column: "RoleGuid",
                unique: true);
            migrationBuilder.CreateIndex(
                name: "IX_SiteRole_RoleName",
                table: "mp_Roles",
                column: "RoleName");
            migrationBuilder.CreateIndex(
                name: "IX_SiteRole_SiteGuid",
                table: "mp_Roles",
                column: "SiteGuid");
            migrationBuilder.CreateIndex(
                name: "IX_SiteRole_SiteId",
                table: "mp_Roles",
                column: "SiteID");
            migrationBuilder.CreateIndex(
                name: "IX_SiteSettings_SiteGuid",
                table: "mp_Sites",
                column: "SiteGuid",
                unique: true);
            migrationBuilder.CreateIndex(
                name: "IX_SiteUser_SiteGuid",
                table: "mp_Users",
                column: "SiteGuid");
            migrationBuilder.CreateIndex(
                name: "IX_SiteUser_SiteId",
                table: "mp_Users",
                column: "SiteID");
            migrationBuilder.CreateIndex(
                name: "IX_SiteUser_UserGuid",
                table: "mp_Users",
                column: "UserGuid",
                unique: true);
            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_SiteId",
                table: "mp_UserClaims",
                column: "SiteId");
            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_SiteId",
                table: "mp_UserLogins",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("mp_Currency");
            migrationBuilder.DropTable("mp_GeoCountry");
            migrationBuilder.DropTable("mp_GeoZone");
            migrationBuilder.DropTable("mp_Language");
            migrationBuilder.DropTable("mp_SiteFolders");
            migrationBuilder.DropTable("mp_SiteHosts");
            migrationBuilder.DropTable("mp_Roles");
            migrationBuilder.DropTable("mp_Sites");
            migrationBuilder.DropTable("mp_Users");
            migrationBuilder.DropTable("mp_UserClaims");
            migrationBuilder.DropTable("mp_UserLocation");
            migrationBuilder.DropTable("mp_UserLogins");
            migrationBuilder.DropTable("mp_UserRoles");
        }
    }
}
