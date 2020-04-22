using System.Net;

namespace MM.Application.Core
{
    public class JsonReturn
    {
        public object Result { get; set; }
        public int Status { get; set; }

        public JsonReturn(object Result, int Status)
        {
            this.Result = Result;
            this.Status = Status;
        }
    }
}
