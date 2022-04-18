using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace Techo.Services.Validators
{
    public interface IValidateProductExcel
    {
        public ExcelWorksheet Excel { get; set; }
        ResultValidateProductExcel Validate();
    }
}
