using System;

namespace WebApplication1.Models
{
    public class Note
    {
        public int ID { get; set; }
        public string Expression { get; set; }
        public string Result { get; set; }
        public string Host { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
