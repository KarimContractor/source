namespace Blood_Donation_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bloodmg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodCollecteds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MRNo = c.Int(nullable: false),
                        takentime = c.DateTime(nullable: false),
                        expires = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BloodCollected_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BloodCollecteds", t => t.BloodCollected_Id)
                .Index(t => t.BloodCollected_Id);
            
            CreateTable(
                "dbo.DonorInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MRNo = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        CNICNo = c.String(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(),
                        Country = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        addon = c.DateTime(nullable: false),
                        updatedon = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Previlage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MRNo = c.Int(nullable: false),
                        Inthelast3monthshaveyouhadavaccination = c.Boolean(nullable: false),
                        Inthelast6monthshaveyouconsultedadoctorforahealthproblemhadsurgeryormedicaltreatment = c.Boolean(nullable: false),
                        Doyouhavediabetes = c.Boolean(nullable: false),
                        Haveyoueverhadmalaria = c.Boolean(nullable: false),
                        Haveyoueverhadkidneyorbloodproblems = c.Boolean(nullable: false),
                        Haveyoueverhadproblemswithyourheartorlungs = c.Boolean(nullable: false),
                        Inthelast12monthshaveyouhadclosecontactwithapersonwhohashadhepatitisoryellowjaundice = c.Boolean(nullable: false),
                        Haveyoueverhadepilepsyorfainting = c.Boolean(nullable: false),
                        Haveyoueverhadacomaorstroke = c.Boolean(nullable: false),
                        Haveyoueverhadcancer = c.Boolean(nullable: false),
                        Inthelast12monthshaveyouhadagraft = c.Boolean(nullable: false),
                        HaveyoueverhadCrohnsdisease = c.Boolean(nullable: false),
                        Haveyoueverreceivedaduramaterbraincoveringgraft = c.Boolean(nullable: false),
                        HaveyoueverhadapositivetestfortheHIVAIDSvirus = c.Boolean(nullable: false),
                        Inthelast6monthshaveyoureceivedbloodorbloodproducts = c.Boolean(nullable: false),
                        Inthelast6monthshaveyouhadhepatitis = c.Boolean(nullable: false),
                        Inthelast3monthshaveyouhadskinorearpiercing = c.Boolean(nullable: false),
                        Inthelast3monthshaveyouhadatattoo = c.Boolean(nullable: false),
                        Inthelast6monthshaveyouhadelectrolysis = c.Boolean(nullable: false),
                        Inthelast12monthshaveyoubeeninjailorprison = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "BloodCollected_Id", "dbo.BloodCollecteds");
            DropIndex("dbo.Tests", new[] { "BloodCollected_Id" });
            DropTable("dbo.Questions");
            DropTable("dbo.Logs");
            DropTable("dbo.DonorInfoes");
            DropTable("dbo.Tests");
            DropTable("dbo.BloodCollecteds");
        }
    }
}
