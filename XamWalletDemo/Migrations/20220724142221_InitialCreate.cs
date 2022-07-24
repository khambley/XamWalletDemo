using Microsoft.EntityFrameworkCore.Migrations;

namespace XamWalletDemo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemberName = table.Column<string>(nullable: true),
                    MemberID = table.Column<string>(nullable: true),
                    GroupNo = table.Column<string>(nullable: true),
                    PlanName = table.Column<string>(nullable: true),
                    NetworkType = table.Column<string>(nullable: true),
                    RxBinNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberInfo");
        }
    }
}
