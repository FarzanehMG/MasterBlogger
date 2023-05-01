﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnAuthorNameToTableArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Articles");
        }
    }
}
