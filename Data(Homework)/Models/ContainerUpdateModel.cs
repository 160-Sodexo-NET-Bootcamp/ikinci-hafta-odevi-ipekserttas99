using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.Models
{
    public class ContainerUpdateModel
    {
        //public int Id { get; set; }
        public string ContainerName { get; set; }
        [Column(TypeName = "decimal(10, 6)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(10, 6)")]
        public decimal Longitude { get; set; }
    }
}
