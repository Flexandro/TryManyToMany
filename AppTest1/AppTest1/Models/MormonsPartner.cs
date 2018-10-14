using System.Collections.Generic;

namespace AppTest1.Models
{
    public class MormonsPartner
    {
        public int Id { get; set; }

        public int ManId { get; set; }
        public Men Man { get; set; }

        public int WomanId { get; set; }
        public Women Woman { get; set; }
    }
}