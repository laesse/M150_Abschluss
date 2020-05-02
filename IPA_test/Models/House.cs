using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IPA_test.Models
{
    public class House
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Image> Images { get; set; }
        public string Street { get; set; }
        public string DetailText { get; set; }
        public string Ortschaft { get; set; }
        public ICollection<Rent> Rents { get; set; }
    }
}
