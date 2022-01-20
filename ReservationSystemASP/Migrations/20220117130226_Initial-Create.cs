using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationSystemASP.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                    table.UniqueConstraint("Un_Registrations_UserName",x=>x.UserName);
                    table.UniqueConstraint("Un_Registrations_PhoneNumber", x => x.PhoneNumber);
                    table.UniqueConstraint("Un_Registrations_Email", x => x.Email);
                });
            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "FirstName", "Surname", "UserName", "PhoneNumber", "Email", "Password" },
                values: new object[] { "Danylo", "Sydorchuk", "dsyd", "+48352231123", "dsyd@gmail.com", "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");
        }
    }
}
