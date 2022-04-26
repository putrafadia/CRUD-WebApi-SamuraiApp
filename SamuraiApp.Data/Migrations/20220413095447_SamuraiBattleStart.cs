﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class SamuraiBattleStart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE FUNCTION[dbo].[EarliestBattleFoughtBySamurai](@samuraiId int)
                RETURNS char(30) AS
                BEGIN
                  DECLARE @ret char(30)
                  SELECT TOP 1 @ret = Name
                  FROM Battles
                  WHERE Battles.BattleId IN(SELECT BattleId
                                     FROM BattleSamurai
                                    WHERE SamuraiId = @samuraiId)
                  ORDER BY StarDate
                  RETURN @ret
                END
            ");
            migrationBuilder.Sql(@"
            CREATE VIEW dbo.SamuraiBattleStats
              AS
              SELECT dbo.Samurais.Name,
              COUNT(dbo.BattleSamurai.BattleId) AS NumberOfBattles,
                      dbo.EarliestBattleFoughtBySamurai(MIN(dbo.Samurais.Id)) 
		  	     AS EarliestBattle
              FROM dbo.BattleSamurai INNER JOIN
                   dbo.Samurais ON dbo.BattleSamurai.SamuraiId = dbo.Samurais.Id
              GROUP BY dbo.Samurais.Name, dbo.BattleSamurai.SamuraiId

            ");
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.SamuraisWhoSaidAWord
               @text VARCHAR(20)
               AS
               SELECT      Samurais.Id, Samurais.Name
               FROM        Samurais INNER JOIN
                           Quotes ON Samurais.Id = Quotes.SamuraiId
               WHERE      (Quotes.Text LIKE '%'+@text+'%')
            ");
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.DeleteQuotesForSamurai
             @samuraiId int
             AS
             DELETE FROM Quotes
             WHERE Quotes.SamuraiId=@samuraiId"
            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"");
            migrationBuilder.Sql(@"");
        }
    }
}
