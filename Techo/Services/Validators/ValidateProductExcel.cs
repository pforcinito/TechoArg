using System;
using OfficeOpenXml;

namespace Techo.Services.Validators
{
    internal static class ProductConstants
    {
        internal static int CodigoBarraPosition = 1;
        internal static int NombrePosition = 2;
        internal static int DescripcionPosition = 3;
        internal static int ProveedorIdPosition = 4;
        internal static int PrecioCostoPosition = 5;
        internal static int MedidaPosition = 6;
        internal static int MaterialPosition = 7;
        internal static int MarcaPosition = 8;
    }

    public class ValidateProductExcel : IValidateProductExcel
    {
        public ExcelWorksheet Excel { get; set; }

        public ValidateProductExcel()
        {
        }

        public ResultValidateProductExcel Validate()
        {
            var result = new ResultValidateProductExcel();

            if (Excel == null)
                throw new ArgumentException("Excel must be needed");

            for(var i = 2; i < Excel.Dimension.Rows; i++)
            {
                if (!IsFieldValid(i, ProductConstants.CodigoBarraPosition, typeof(string), false))
                    result.AddCellError("CodigoBarra", i);

                if (!IsFieldValid(i, ProductConstants.NombrePosition, typeof(string), true))
                    result.AddCellError("Nombre", i);

                if (!IsFieldValid(i, ProductConstants.DescripcionPosition, typeof(string), false))
                    result.AddCellError("Descripcion", i);

                if (!IsFieldValid(i, ProductConstants.ProveedorIdPosition, typeof(int), true))
                    result.AddCellError("ProveedorId", i);

                if (!IsFieldValid(i, ProductConstants.PrecioCostoPosition, typeof(decimal), true))
                    result.AddCellError("PrecioCosto", i);

                if (!IsFieldValid(i, ProductConstants.MedidaPosition, typeof(string), false))
                    result.AddCellError("Medida", i);

                if (!IsFieldValid(i, ProductConstants.MaterialPosition, typeof(string), false))
                    result.AddCellError("Material", i);

                if (!IsFieldValid(i, ProductConstants.MarcaPosition, typeof(string), false))
                    result.AddCellError("Marca", i);
            }

            return result;
        }

        private bool IsFieldValid(int row, int position, Type typeToValidate, bool required)
        {
            var value = Excel.Cells[row, position].Value?.ToString();
            bool result;

            if (!required && string.IsNullOrWhiteSpace(value))
                return true;
            
            switch (Type.GetTypeCode(typeToValidate))
            {
                case TypeCode.Int32:
                    result = int.TryParse(value, out _);
                    break;
                case TypeCode.Double:
                case TypeCode.Decimal:
                    result = decimal.TryParse(value, out _);
                    break;
                case TypeCode.String:
                    result = !string.IsNullOrWhiteSpace(value);
                    break;
                default:
                    throw new ArgumentException("Type not supported");
            }

            return result;
        }
    }

    public class ResultValidateProductExcel
    {
        public bool IsValid { get => InvalidCells == 0; }
        public string ResultMessage { get; private set; }
        public int InvalidCells { get; private set; }

        public void AddCellError(string fieldName, int rowPosition)
        {
            ResultMessage += $"Error en formato en celda {fieldName} fila {rowPosition}" + Environment.NewLine;
            InvalidCells++;
        }
    }
}