using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_Trigger_Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TRIGGER AddBlogInRatingTable
ON Blogs
AFTER INSERT
AS
DECLARE @ID INT
SELECT @ID=BlogID FROM inserted
INSERT INTO BlogRatings (BlogID, BlogTotalScore, BlogRatingCount)
VALUES (@ID, 0, 0)
GO

CREATE TRIGGER AddScoreInComment
ON Comments
AFTER INSERT
AS
DECLARE @ID INT
DECLARE @SCORE INT
DECLARE @RATING_COUNT INT
SELECT @ID = BlogID, @SCORE = BlogScore FROM inserted
UPDATE BlogRatings SET BlogTotalScore = BlogTotalScore + @SCORE, BlogRatingCount+=1 
WHERE BlogID = @ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
