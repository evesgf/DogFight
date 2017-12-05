using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestMySql.Entity
{
    public class UserList:BaseEntity<long>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(20)]
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(20)]
        [Required]
        public string PassWord { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(100)]
        public string ReMark { get; set; }
    }
}
