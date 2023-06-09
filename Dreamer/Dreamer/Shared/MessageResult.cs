using System.Collections.Generic;

namespace Dreamer.Shared
{
    public class MessageResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Fail { get; set; }
    }
}
