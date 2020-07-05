using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvc.Models
{
    /// <summary>
    /// 页面元素
    /// </summary>
    public class PageElem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }
        [ForeignKey("MenuId")]
        public Menu Menu { get; set; }
    }
}
