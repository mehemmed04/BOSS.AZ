using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptionsNamespace
{
    public class CustomException:ApplicationException
    {
        public CustomException(DateTime date, string errorMessage, int errorLine, string errorFilePath)
        {
            Date = date;
            ErrorMessage = errorMessage;
            ErrorLine = errorLine;
            ErrorFilePath = errorFilePath;
        }

        public DateTime Date { get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorLine { get; set; }
        public string ErrorFilePath { get; set; }

        public override string ToString()
        {
            return $@"Error File Path : {ErrorFilePath}
LINE : {ErrorLine}
DATE : {Date.ToString()}
Message : {ErrorMessage}

";
        }

    }

}
