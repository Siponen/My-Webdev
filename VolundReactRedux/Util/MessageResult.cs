using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.Util
{
    public enum MessageLevel {Success = 1, Info, Warning, Error}

    public class MessageResult
    {
        //success,error,info,warning
        public MessageLevel MessageLevel { get; set; }
        public string Message { get; set; }

        public static MessageResult ErrorMessage(string msg)
        {
            MessageResult result = new MessageResult()
            {
                MessageLevel = MessageLevel.Error,
                Message = msg
            };
            return result;
        }

        public static MessageResult SuccessMessage(string msg)
        {
            MessageResult result = new MessageResult()
            {
                MessageLevel = MessageLevel.Success,
                Message = msg
            };
            return result;
        }

        public static MessageResult InfoMessage(string msg)
        {
            MessageResult result = new MessageResult()
            {
                MessageLevel = MessageLevel.Info,
                Message = msg
            };
            return result;
        }

        public static MessageResult WarningMessage(string msg)
        {
            MessageResult result = new MessageResult()
            {
                MessageLevel = MessageLevel.Warning,
                Message = msg
            };
            return result;
        }
    }
}
