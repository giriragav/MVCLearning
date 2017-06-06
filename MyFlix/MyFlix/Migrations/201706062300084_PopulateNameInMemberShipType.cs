namespace MyFlix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameInMemberShipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MemberShipTypes " +
                "set Name = case " +
                "when Id = 1 then 'Pay as You Go' " +
                "when Id = 2 then 'Monthly' " +
                "when Id = 3 then 'Quaterly' " +
                "when Id = 4 then 'Annually' " +
                "Else '' " +
                "END");
        }
        
        public override void Down()
        {
        }
    }
}
