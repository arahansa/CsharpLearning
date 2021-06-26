using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysqlConnect1.models
{
    class User
    {
        [Key]
        [Required]
        [MaxLength(30)]
        public string userid { get; set; }


        [Required]
        [MaxLength(30)]
        public string username { get; set; }

        [Required]
        [MaxLength(30)]
        public string useraddress { get; set; }

        [Required]
        [MaxLength(30)]
        public string tes { get; set; }



    }
}
