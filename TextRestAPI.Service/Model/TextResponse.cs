using System;

namespace TextRestAPI.Model
{
    public class TextResponse
    {
        public String Content { get; set; }
        public Int32 WordsCount { get; set; }
        public String Error { get; set; }
    }
}
