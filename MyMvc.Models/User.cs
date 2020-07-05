using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User:BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        public Gender Sex { get; set; }
        public string Phone { get; set; }
        public DateTime? BronTime { get; set; }

        public ICollection<Role> Roles { get; set; }

    }
    public enum Gender
    {
        Man,
        Woman
    }
}
