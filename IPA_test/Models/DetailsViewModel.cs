using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPA_test.Models
{
    public class DetailsViewModel
    {
        public string Id { get; set; }
        public List<string> Images { get; set; }
        public string PrimaryImage { get; set; }
        public string Street { get; set; }
        public string DetailText { get; set; }
        public string Ortschaft { get; set; }
    }
}
