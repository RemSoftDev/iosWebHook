using System;

namespace iosWebHook.models
{
    public class messages
    {
        public Guid Id { get; set; }
        public string message { get; set; }
        public DateTime created { get; set; }
    }
}
