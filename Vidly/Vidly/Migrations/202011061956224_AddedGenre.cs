namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Customers", "Birthday", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Birthday", c => c.DateTime());
            DropColumn("dbo.Movies", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
