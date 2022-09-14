using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeTemperature.Infrastructure.Migrations
{
    public partial class EmployeeTemperatureDataSeed : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			string sql = @"
							SET IDENTITY_INSERT Employees ON 
							INSERT [dbo].[Employees] ([Id],[EmployeeNumber] , [FirstName], [LastName] ) VALUES (1, '001', 'Walter', 'White' )
							INSERT [dbo].[Employees] ([Id],[EmployeeNumber], [FirstName], [LastName] ) VALUES (2, '002', 'Jessie', 'Pinkman' )
							INSERT [dbo].[Employees] ([Id], [EmployeeNumber], [FirstName], [LastName] ) VALUES (3, '003', 'Gregory', 'House' )
							INSERT [dbo].[Employees] ([Id],[EmployeeNumber], [FirstName], [LastName] ) VALUES (4, '004', 'James', 'Wilson')
							INSERT [dbo].[Employees] ([Id],[EmployeeNumber], [FirstName], [LastName] ) VALUES (5, '005', 'Lisa', 'Cuddy')
							INSERT [dbo].[Employees] ([Id],[EmployeeNumber], [FirstName], [LastName] ) VALUES (6, '006', 'Robert', 'Chase')
							SET IDENTITY_INSERT Employees OFF
							GO
							
							SET IDENTITY_INSERT Temperatures ON 
							INSERT [dbo].[Temperatures] ([Id],[Value], [RecordDate], [EmployeeId] ) VALUES (1, 36.4, '2022-09-10', 1)
							INSERT [dbo].[Temperatures] ([Id],[Value], [RecordDate], [EmployeeId] ) VALUES (2, 36.4, '2022-09-11', 1)
							INSERT [dbo].[Temperatures] ([Id],[Value], [RecordDate], [EmployeeId] ) VALUES (3, 36.4, '2022-09-12', 1)
							INSERT [dbo].[Temperatures] ([Id],[Value], [RecordDate], [EmployeeId] ) VALUES (4, 36.4, '2022-09-13', 1)
							INSERT [dbo].[Temperatures] ([Id],[Value], [RecordDate], [EmployeeId] ) VALUES (5, 36.4, '2022-09-10', 2)
							INSERT [dbo].[Temperatures] ([Id],[Value], [RecordDate], [EmployeeId] ) VALUES (6, 36.4, '2022-09-12', 2)
							INSERT [dbo].[Temperatures] ([Id],[Value], [RecordDate], [EmployeeId] ) VALUES (7, 36.4, '2022-09-13', 2)
							INSERT [dbo].[Temperatures] ([Id],[Value], [RecordDate], [EmployeeId] ) VALUES (8, 36.4, '2022-09-11', 3)
							INSERT [dbo].[Temperatures] ([Id],[Value], [RecordDate], [EmployeeId] ) VALUES (9, 36.4, '2022-09-12', 4)
							INSERT [dbo].[Temperatures] ([Id],[Value], [RecordDate], [EmployeeId] ) VALUES (10, 36.4, '2022-09-11', 5)
							INSERT [dbo].[Temperatures] ([Id],[Value], [RecordDate], [EmployeeId] ) VALUES (11, 36.4, '2022-09-12', 6)
							SET IDENTITY_INSERT Temperatures OFF							
							GO";
			migrationBuilder.Sql(sql);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			string sql = @"TRUNCATE TABLE Temperatures
							GO
							TRUNCATE TABLE Employees
							GO
							";
			migrationBuilder.Sql(sql);
		}
	}
}
