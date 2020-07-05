using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Models
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menu
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsEffictive { get; set; } = true;
        public string MenuCode { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
