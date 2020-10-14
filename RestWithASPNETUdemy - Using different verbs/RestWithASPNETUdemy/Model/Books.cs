using RestWithASPNETUdemy.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Model
{
    public class Books : BaseEntity
    {
        
        public string AUTHOR { get; set; }
        public string TITLE { get; set; }
    }
}
