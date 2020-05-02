using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IPA_test.Models
{
    public class Rent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public User User { get; set; }

    }
}
