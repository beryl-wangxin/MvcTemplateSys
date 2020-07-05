namespace MyMvc.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsEffictive = c.Boolean(nullable: false),
                        MenuCode = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Icon = c.String(unicode: false),
                        Url = c.String(unicode: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        NameDesc = c.String(unicode: false),
                        IsEffective = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUser = c.String(unicode: false),
                        UpdateTime = c.DateTime(),
                        UpdateUser = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        RealName = c.String(unicode: false),
                        Sex = c.Int(nullable: false),
                        Phone = c.String(unicode: false),
                        BronTime = c.DateTime(),
                        IsEffective = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUser = c.String(unicode: false),
                        UpdateTime = c.DateTime(),
                        UpdateUser = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.role_module",
                c => new
                    {
                        RoleID = c.Guid(nullable: false),
                        ModuleID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleID, t.ModuleID })
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .ForeignKey("dbo.Menus", t => t.ModuleID)
                .Index(t => t.RoleID)
                .Index(t => t.ModuleID);
            
            CreateTable(
                "dbo.user_role",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        RoleID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.RoleID })
                .ForeignKey("dbo.Users", t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.UserID)
                .Index(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.user_role", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.user_role", "UserID", "dbo.Users");
            DropForeignKey("dbo.role_module", "ModuleID", "dbo.Menus");
            DropForeignKey("dbo.role_module", "RoleID", "dbo.Roles");
            DropIndex("dbo.user_role", new[] { "RoleID" });
            DropIndex("dbo.user_role", new[] { "UserID" });
            DropIndex("dbo.role_module", new[] { "ModuleID" });
            DropIndex("dbo.role_module", new[] { "RoleID" });
            DropTable("dbo.user_role");
            DropTable("dbo.role_module");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Menus");
        }
    }
}
