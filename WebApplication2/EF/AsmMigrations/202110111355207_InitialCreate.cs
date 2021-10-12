namespace WebApplication2.EF.AsmMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO dbo.Admin (Name) VALUES " +
        "('Duc Duy') ");
            CreateTable(
                "dbo.CategoryofCourse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Descrpitipon = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO dbo.CategoryofCourse (Name, Descrpitipon) VALUES " +
        "('IT', 'CNTT') ");
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Descrpitipon = c.String(nullable: false),
                        CatId = c.Int(nullable: false),
                        CategoryofCourse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryofCourse", t => t.CategoryofCourse_Id)
                .Index(t => t.CategoryofCourse_Id);
            Sql("INSERT INTO dbo.Course (Name, Descrpitipon,CatId) VALUES " +
        "('IT', 'CNTT',1) ");
            CreateTable(
                "dbo.Trainees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Education = c.String(nullable: false),
                        DOB = c.String(nullable: false),
                        Age = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        TOEIC = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .Index(t => t.Course_Id);
            Sql("INSERT INTO dbo.Trainees (Name, Education,DOB,Age,Department,TOEIC,Location,Course_Id) VALUES " +
        "('Duc Duy', '12','09/09/1999','22','depart','7.5','Tay Coc','1') ");
            CreateTable(
                "dbo.Trainner",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Telephone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        WorkingPlace = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO dbo.Trainner ( Name,Telephone,Email,Type,WorkingPlace) VALUES " +
        "('Duc Duy', '09123456789','hello@gmail.com','hello','FPT') ");
            CreateTable(
                "dbo.StaffTrainner",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO dbo.StaffTrainner (Name, Contact) VALUES " +
       "('Duc Duy', '0972921123') ");
            CreateTable(
                "dbo.TrainnerCourses",
                c => new
                    {
                        Trainner_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trainner_Id, t.Course_Id })
                .ForeignKey("dbo.Trainner", t => t.Trainner_Id, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Trainner_Id)
                .Index(t => t.Course_Id);
            Sql("INSERT INTO dbo.TrainnerCourses (Trainner_Id, Course_Id) VALUES " +
       "(1, 1) ");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "CategoryofCourse_Id", "dbo.CategoryofCourse");
            DropForeignKey("dbo.TrainnerCourses", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.TrainnerCourses", "Trainner_Id", "dbo.Trainner");
            DropForeignKey("dbo.Trainees", "Course_Id", "dbo.Course");
            DropIndex("dbo.TrainnerCourses", new[] { "Course_Id" });
            DropIndex("dbo.TrainnerCourses", new[] { "Trainner_Id" });
            DropIndex("dbo.Trainees", new[] { "Course_Id" });
            DropIndex("dbo.Course", new[] { "CategoryofCourse_Id" });
            DropTable("dbo.TrainnerCourses");
            DropTable("dbo.StaffTrainner");
            DropTable("dbo.Trainner");
            DropTable("dbo.Trainees");
            DropTable("dbo.Course");
            DropTable("dbo.CategoryofCourse");
            DropTable("dbo.Admin");
        }
    }
}
