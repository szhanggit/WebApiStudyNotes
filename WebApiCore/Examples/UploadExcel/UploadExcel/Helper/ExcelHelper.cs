using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data;

namespace UploadExcel.Helper
{
    public class ExcelHelper
    {
        public static void ConvertToDataSet(HSSFWorkbook workbook, DataSet ds, bool needTrim = false)
        {
            if (workbook == null)
            {
                throw new ArgumentNullException("workbook is null");
            }
            if (ds == null)
            {
                throw new ArgumentNullException("dt is null");
            }
            if (workbook == null || ds == null)
            {
                throw new ArgumentNullException("workbook or dt is null");
            }

            for (int k = 0; k < 5; k++)
            {
                if (workbook.NumberOfSheets <= k)
                {
                    return;
                }

                HSSFSheet sheet = (HSSFSheet)workbook.GetSheetAt(k);
                HSSFRow firstrow = (HSSFRow)sheet.GetRow(sheet.FirstRowNum);
                DataTable dt = new DataTable();
                dt.TableName = sheet.SheetName;
                for (int i = 0; i < firstrow.Cells.Count; i++)
                {
                    dt.Columns.Add(firstrow.GetCell(i).ToString().Trim());
                }

                if (sheet.LastRowNum > sheet.FirstRowNum)
                {
                    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                    {
                        DataRow dr = dt.NewRow();
                        HSSFRow row = (HSSFRow)sheet.GetRow(i);
                        bool hasValue = false;
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            HSSFCell cell = (HSSFCell)row.GetCell(j);
                            if (cell == null)
                            {
                                dr[j] = null;
                            }
                            else
                            {
                                if (cell.CellType == CellType.Numeric && cell.CellStyle.DataFormat == 14) // m/d/yy
                                {
                                    dr[j] = cell.DateCellValue.ToString("yyyy/MM/dd");
                                }
                                else if (cell.CellType == CellType.Numeric && cell.CellStyle.DataFormat == 22)
                                {
                                    dr[j] = cell.DateCellValue.ToString();
                                }
                                else
                                {
                                    dr[j] = needTrim ? cell.ToString().Trim() : cell.ToString();
                                }

                                hasValue |= !string.IsNullOrWhiteSpace(dr[j].ToString());
                            }
                        }

                        if (hasValue)
                        {
                            dt.Rows.Add(dr);
                        }
                    }
                }

                ds.Tables.Add(dt);
            }

        }

        public static DataSet ConvertFiletoDataSet(Stream stream, bool needTrim = true)
        {
            DataSet ds = new DataSet();

            if (stream != null)
            {
                ConvertToDataSet(new HSSFWorkbook(stream), ds, needTrim);
            }

            return ds;
        }
    }
}
