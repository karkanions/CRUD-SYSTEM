using Bussiness.Parameters;

namespace Bussinesss.Excel
{
    public class ExcelParameters
    {

        public ExcelParameters(ExcelEnu ValidateMethod, object Parameter)
        {
            this.Parameter = Parameter;
            this.ValidateMethod = ValidateMethod;
        }

        public ExcelEnu ValidateMethod { get; set; }
        public object Parameter { get; set; }
    }
}
