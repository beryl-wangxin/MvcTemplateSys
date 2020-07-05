using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Models
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role:BaseEntity
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string NameDesc { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
