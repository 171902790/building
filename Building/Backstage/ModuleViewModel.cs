using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Building.Backstage
{
    public class ModuleViewModel
    {
        public int SuperiorId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "名字长度不能大于25个字且不能小于3个字.", MinimumLength = 6)]
        [Display(Name = "模块名称")]
        public string Name { get; set; }
    }
}