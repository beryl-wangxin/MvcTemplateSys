using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Models
{
    public class MyContext:DbContext
    {
        public MyContext() : base("accessCon")
        {
            Database.SetInitializer<MyContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //用户和角色是 多对多 的关系
            modelBuilder.Entity<User>()
                .HasMany(t => t.Roles)
                .WithMany(t => t.Users)
                .Map(m =>
                {
                    m.ToTable("user_role");
                    m.MapLeftKey("UserID");
                    m.MapRightKey("RoleID");
                });


            modelBuilder.Entity<Role>()
                .HasMany(t => t.Menus)
                .WithMany(t => t.Roles)
                .Map(m =>
                {
                    m.ToTable("role_module");
                    m.MapLeftKey("RoleID");
                    m.MapRightKey("ModuleID");

                });
            /*
             Code First模式级联删除是默认打开的，
             在同一个实体多次引用另一个实体时，
             需要单独设置关闭某个外键关系下的级联删除，
             需要写Fluent API代码，
             而且级联删除有时会造成麻烦。
             */
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


        }
        public DbSet<Menu> Modules { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
