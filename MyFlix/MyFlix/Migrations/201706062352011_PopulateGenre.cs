namespace MyFlix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Genres (Name) Values ('Action') ");
            Sql("Insert Genres (Name) Values ('Romance') ");
            Sql("Insert Genres (Name) Values ('History') ");
            Sql("Insert Genres (Name) Values ('Horror') ");
            Sql("Insert Genres (Name) Values ('Drama') ");
        }
        
        public override void Down()
        {

        }
    }
}
