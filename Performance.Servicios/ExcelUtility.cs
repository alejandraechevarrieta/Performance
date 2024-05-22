using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using Performance.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Performance.Servicios
{
    public class ExcelUtility
    {
        public ReporteExcelVM GenerarReportePerformance(List<DatosPerformanceVM> master)
        {
            using (var _db = new PerformanceEntities())
            {
                IWorkbook workbook = new XSSFWorkbook();

                //Formato fuentes
                XSSFFont myFontEncabezado = (XSSFFont)workbook.CreateFont();
                myFontEncabezado.FontHeightInPoints = 12;
                myFontEncabezado.FontName = "Calibri";
                myFontEncabezado.Boldweight = (short)FontBoldWeight.Bold;

                XSSFFont myFontCeldaInfo = (XSSFFont)workbook.CreateFont();
                myFontCeldaInfo.FontHeightInPoints = 11;
                myFontCeldaInfo.FontName = "Calibri";
                myFontCeldaInfo.Color = HSSFColor.Black.Index;

                XSSFFont myFontCeldaFechaD = (XSSFFont)workbook.CreateFont();
                myFontCeldaFechaD.FontHeightInPoints = 12;
                myFontCeldaFechaD.FontName = "Calibri";
                myFontCeldaFechaD.Color = HSSFColor.Black.Index;
                myFontCeldaFechaD.Boldweight = (short)FontBoldWeight.Bold;

                XSSFFont myFontCeldaFecha = (XSSFFont)workbook.CreateFont();
                myFontCeldaFecha.FontHeightInPoints = 12;
                myFontCeldaFecha.FontName = "Calibri";
                myFontCeldaFecha.Color = HSSFColor.Black.Index;

                XSSFFont myFontCeldasData = (XSSFFont)workbook.CreateFont();
                myFontCeldasData.FontHeightInPoints = 11;
                myFontCeldasData.FontName = "Calibri";
                myFontCeldasData.Color = HSSFColor.Black.Index;
                myFontCeldasData.Boldweight = (short)FontBoldWeight.Bold;

                //Formato celdas
                XSSFCellStyle celdasInfo = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFCellStyle celdasFechaD = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFCellStyle celdasFecha = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFCellStyle celdasEncabezado = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFCellStyle celdasData = (XSSFCellStyle)workbook.CreateCellStyle();

                celdasInfo.SetFont(myFontCeldaInfo);
                celdasFechaD.SetFont(myFontCeldaFechaD);
                celdasEncabezado.SetFont(myFontEncabezado);
                celdasData.SetFont(myFontCeldasData);

                //Bordes-Ajustes
                celdasEncabezado.BorderLeft = BorderStyle.Medium;
                celdasEncabezado.BorderTop = BorderStyle.Medium;
                celdasEncabezado.BorderRight = BorderStyle.Medium;
                celdasEncabezado.BorderBottom = BorderStyle.Medium;
                celdasEncabezado.VerticalAlignment = VerticalAlignment.Center;
                celdasEncabezado.Alignment = HorizontalAlignment.Left;

                celdasInfo.BorderRight = BorderStyle.Thin;
                celdasInfo.BorderLeft = BorderStyle.Thin;
                celdasInfo.BorderBottom = BorderStyle.Thin;
                celdasInfo.VerticalAlignment = VerticalAlignment.Center;
                celdasInfo.Alignment = HorizontalAlignment.Center;
                celdasInfo.WrapText = true;

                celdasFechaD.BorderRight = BorderStyle.Thin;
                celdasFechaD.BorderLeft = BorderStyle.Thin;
                celdasFechaD.BorderBottom = BorderStyle.Thin;
                celdasFechaD.VerticalAlignment = VerticalAlignment.Center;
                celdasFechaD.Alignment = HorizontalAlignment.Right;
                celdasFechaD.WrapText = true;

                celdasFecha.BorderRight = BorderStyle.Thin;
                celdasFecha.BorderLeft = BorderStyle.Thin;
                celdasFecha.BorderBottom = BorderStyle.Thin;
                celdasFecha.VerticalAlignment = VerticalAlignment.Center;
                celdasFecha.Alignment = HorizontalAlignment.Left;
                celdasFecha.WrapText = true;

                celdasData.BorderLeft = BorderStyle.Thin;
                celdasData.BorderTop = BorderStyle.Thin;
                celdasData.BorderRight = BorderStyle.Thin;
                celdasData.BorderBottom = BorderStyle.Thin;
                celdasData.VerticalAlignment = VerticalAlignment.Center;
                celdasData.Alignment = HorizontalAlignment.Center;
                celdasData.FillForegroundColor = HSSFColor.Grey40Percent.Index;
                celdasData.FillPattern = FillPattern.SolidForeground;

                ISheet Sheet = workbook.CreateSheet("Master_List");
                Sheet.CreateFreezePane(0, 0, 0, 0);



                IRow HeaderRow = Sheet.CreateRow(1);
                IRow Row2 = Sheet.CreateRow(2);
                IRow Row3 = Sheet.CreateRow(3);
                IRow Row4 = Sheet.CreateRow(4);
                IRow Row5 = Sheet.CreateRow(5);
                IRow Row6 = Sheet.CreateRow(6);
                IRow Row7 = Sheet.CreateRow(7);
                IRow Row8 = Sheet.CreateRow(8);
                IRow Row9 = Sheet.CreateRow(9);

                //CreateCell(HeaderRow, 0, "", celdasEncabezado);
                CreateCell(HeaderRow, 1, "                                                                                                                        ", celdasEncabezado);
                CreateCell(HeaderRow, 2, "                    ", celdasEncabezado);
                CreateCell(HeaderRow, 3, "                    ", celdasEncabezado);
                CreateCell(HeaderRow, 4, "                    ", celdasEncabezado);
                CreateCell(HeaderRow, 5, "                    ", celdasEncabezado);
                CreateCell(HeaderRow, 6, "                    ", celdasEncabezado);

                //CreateCell(Row2, 0, "", celdasEncabezado);
                CreateCell(Row2, 1, "", celdasEncabezado);
                CreateCell(Row2, 2, "", celdasEncabezado);
                CreateCell(Row2, 3, "", celdasEncabezado);
                CreateCell(Row2, 4, "", celdasEncabezado);
                CreateCell(Row2, 5, "", celdasEncabezado);
                CreateCell(Row2, 6, "", celdasEncabezado);

                //CreateCell(Row2, 0, "", celdasEncabezado);
                CreateCell(Row3, 1, "", celdasEncabezado);
                CreateCell(Row3, 2, "", celdasEncabezado);
                CreateCell(Row3, 3, "", celdasEncabezado);
                CreateCell(Row3, 4, "", celdasEncabezado);
                CreateCell(Row3, 5, "", celdasEncabezado);
                CreateCell(Row3, 6, "", celdasEncabezado);

                //CreateCell(Row3, 0, "", celdasEncabezado);
                CreateCell(Row4, 1, "      MASTER LIST      ", celdasEncabezado);
                CreateCell(Row4, 2, "", celdasEncabezado);
                CreateCell(Row4, 3, "", celdasEncabezado);
                CreateCell(Row4, 4, "", celdasEncabezado);
                CreateCell(Row4, 5, "", celdasEncabezado);
                CreateCell(Row4, 6, "", celdasEncabezado);

                //CreateCell(Row3, 0, "", celdasEncabezado);
                CreateCell(Row5, 1, "", celdasEncabezado);
                CreateCell(Row5, 2, "", celdasEncabezado);
                CreateCell(Row5, 3, "", celdasEncabezado);
                CreateCell(Row5, 4, "", celdasEncabezado);
                CreateCell(Row5, 5, "", celdasEncabezado);
                CreateCell(Row5, 6, "", celdasEncabezado);

                //CreateCell(Row4, 0, "", celdasEncabezado);
                CreateCell(Row6, 1, "                    ", celdasEncabezado);
                CreateCell(Row6, 2, "                    ", celdasEncabezado);
                CreateCell(Row6, 3, "                    ", celdasEncabezado);
                CreateCell(Row6, 4, "                    ", celdasEncabezado);
                CreateCell(Row6, 5, "                    ", celdasEncabezado);
                CreateCell(Row6, 6, "                    ", celdasEncabezado);

                //CreateCell(Row5, 0, "", celdasEncabezado);
                CreateCell(Row7, 1, "                    ", celdasEncabezado);
                CreateCell(Row7, 2, "                    ", celdasEncabezado);
                CreateCell(Row7, 3, "                    ", celdasEncabezado);
                CreateCell(Row7, 4, "                    ", celdasEncabezado);
                CreateCell(Row7, 5, "                    ", celdasEncabezado);
                CreateCell(Row7, 6, "                    ", celdasEncabezado);

                //CreateCell(Row6, 0, "", celdasInfo);
                CreateCell(Row8, 1, "Fecha Descarga   ", celdasFechaD);
                CreateCell(Row8, 2, Convert.ToDateTime(DateTime.Today).ToString("dd-MM-yyyy"), celdasFecha);
                CreateCell(Row8, 3, "", celdasInfo);
                CreateCell(Row8, 4, "", celdasInfo);
                CreateCell(Row8, 5, "", celdasInfo);
                CreateCell(Row8, 6, "", celdasInfo);

                //CreateCell(Row7, 0, "", celdasData);
                CreateCell(Row9, 1, "      Titulo      ", celdasData);
                CreateCell(Row9, 2, "      Unidad de negocio      ", celdasData);
                CreateCell(Row9, 3, "      Tipo de documento      ", celdasData);
                CreateCell(Row9, 4, "      Aprueba      ", celdasData);
                CreateCell(Row9, 5, "      Rev.      ", celdasData);
                CreateCell(Row9, 6, "      Fecha de Aprobación      ", celdasData);

                setBordersToMergedCells(Sheet);
                int lastColumNum = Sheet.GetRow(1).LastCellNum;
                for (int i = 0; i <= lastColumNum; i++)
                {
                    Sheet.AutoSizeColumn(i, true);
                    GC.Collect();
                }

                var contador = 9;
                foreach (var item in master)
                {
                    contador++;
                    IRow RowForeach = Sheet.CreateRow(contador);

                    //CreateCell(RowForeach, 0, "", celdasInfo);
                    CreateCell(RowForeach, 1, "", celdasInfo);
                    CreateCell(RowForeach, 2, "", celdasInfo);
                    CreateCell(RowForeach, 3, "", celdasInfo);
                    CreateCell(RowForeach, 4, "", celdasInfo);
                    CreateCell(RowForeach, 5, "", celdasInfo);
                    CreateCell(RowForeach, 6, item.fechaCalificacionAutoevaluacion?.ToString("dd-MM-yyyy") ?? "", celdasInfo);

                }
                byte[] data = File.ReadAllBytes("~/assets/img/performanceIdentidad2024.png");               
                int pictureIndex = workbook.AddPicture(data, PictureType.PNG);

                ICreationHelper helper = workbook.GetCreationHelper();
                IDrawing drawing = Sheet.CreateDrawingPatriarch();
                IClientAnchor anchor = helper.CreateClientAnchor();
                anchor.Col1 = 1;//0 index based column
                anchor.Row1 = 1;//0 index based row

                IPicture picture = drawing.CreatePicture(anchor, pictureIndex);
                picture.Resize();

                //Uniones
                CellRangeAddress union1 = new CellRangeAddress(1, 3, 1, 6);

                //Completa union
                Sheet.AddMergedRegion(union1);

                //Desactivo linea cuadriculada
                Sheet.DisplayGridlines = false;

                // Cantidad de columnas para mas de un tipo de licencia
                var g = 10;
                var cantidad = 0;
                ReporteExcelVM reporteExcelVM = new ReporteExcelVM();
                List<DetalleExcelVM> list = new List<DetalleExcelVM>();
                list.Capacity = 30;
                foreach (var fila in list)
                {
                    int nroLic2 = fila.motivoLic.Count;
                    if (nroLic2 > (cantidad + 1))
                    {
                        cantidad = nroLic2 + 1;
                    }
                }
                var col = cantidad + g;

                //if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/TempFiles/")))
                //    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/TempFiles/"));
                //var pathInic = "~/TempFiles/";
                //var nombreArchivo = "Documental-Master-" + Convert.ToDateTime(DateTime.Today).ToString("dd-MM-yyyy") + Convert.ToDateTime(DateTime.Now).ToString("HH-mm") + ".xlsx";
                //var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(pathInic), nombreArchivo);
                //using (var fileData = new FileStream(path, FileMode.Create))
                //{
                //    workbook.Write(fileData);
                //    fileData.Close();
                //}

                //reporteExcelVM.filePath = path;
                //reporteExcelVM.fileName = nombreArchivo;
                return reporteExcelVM;
            }
        }
        public ReporteExcelVM GenerarReporteColaboradores(List<DatosPerformanceVM> lista)
        {
            using (var _db = new PerformanceEntities())
            {
                IWorkbook workbook = new XSSFWorkbook();

                //Formato fuentes
                XSSFFont myFontEncabezado = (XSSFFont)workbook.CreateFont();
                myFontEncabezado.FontHeightInPoints = 12;
                myFontEncabezado.FontName = "Calibri";
                myFontEncabezado.Boldweight = (short)FontBoldWeight.Bold;

                XSSFFont myFontCeldaInfo = (XSSFFont)workbook.CreateFont();
                myFontCeldaInfo.FontHeightInPoints = 11;
                myFontCeldaInfo.FontName = "Calibri";
                myFontCeldaInfo.Color = HSSFColor.Black.Index;

                XSSFFont myFontCeldaFechaD = (XSSFFont)workbook.CreateFont();
                myFontCeldaFechaD.FontHeightInPoints = 12;
                myFontCeldaFechaD.FontName = "Calibri";
                myFontCeldaFechaD.Color = HSSFColor.Black.Index;
                myFontCeldaFechaD.Boldweight = (short)FontBoldWeight.Bold;

                XSSFFont myFontCeldaFecha = (XSSFFont)workbook.CreateFont();
                myFontCeldaFecha.FontHeightInPoints = 12;
                myFontCeldaFecha.FontName = "Calibri";
                myFontCeldaFecha.Color = HSSFColor.Black.Index;

                XSSFFont myFontCeldasData = (XSSFFont)workbook.CreateFont();
                myFontCeldasData.FontHeightInPoints = 11;
                myFontCeldasData.FontName = "Calibri";
                myFontCeldasData.Color = HSSFColor.Black.Index;
                myFontCeldasData.Boldweight = (short)FontBoldWeight.Bold;

                //Formato celdas
                XSSFCellStyle celdasInfo = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFCellStyle celdasFechaD = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFCellStyle celdasFecha = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFCellStyle celdasEncabezado = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFCellStyle celdasData = (XSSFCellStyle)workbook.CreateCellStyle();

                celdasInfo.SetFont(myFontCeldaInfo);
                celdasFechaD.SetFont(myFontCeldaFechaD);
                celdasEncabezado.SetFont(myFontEncabezado);
                celdasData.SetFont(myFontCeldasData);

                //Bordes-Ajustes
                celdasEncabezado.BorderLeft = BorderStyle.Medium;
                celdasEncabezado.BorderTop = BorderStyle.Medium;
                celdasEncabezado.BorderRight = BorderStyle.Medium;
                celdasEncabezado.BorderBottom = BorderStyle.Medium;
                celdasEncabezado.VerticalAlignment = VerticalAlignment.Center;
                celdasEncabezado.Alignment = HorizontalAlignment.Left;

                celdasInfo.BorderRight = BorderStyle.Thin;
                celdasInfo.BorderLeft = BorderStyle.Thin;
                celdasInfo.BorderBottom = BorderStyle.Thin;
                celdasInfo.VerticalAlignment = VerticalAlignment.Center;
                celdasInfo.Alignment = HorizontalAlignment.Center;
                celdasInfo.WrapText = true;

                celdasFechaD.BorderRight = BorderStyle.Thin;
                celdasFechaD.BorderLeft = BorderStyle.Thin;
                celdasFechaD.BorderBottom = BorderStyle.Thin;
                celdasFechaD.VerticalAlignment = VerticalAlignment.Center;
                celdasFechaD.Alignment = HorizontalAlignment.Right;
                celdasFechaD.WrapText = true;

                celdasFecha.BorderRight = BorderStyle.Thin;
                celdasFecha.BorderLeft = BorderStyle.Thin;
                celdasFecha.BorderBottom = BorderStyle.Thin;
                celdasFecha.VerticalAlignment = VerticalAlignment.Center;
                celdasFecha.Alignment = HorizontalAlignment.Left;
                celdasFecha.WrapText = true;

                celdasData.BorderLeft = BorderStyle.Thin;
                celdasData.BorderTop = BorderStyle.Thin;
                celdasData.BorderRight = BorderStyle.Thin;
                celdasData.BorderBottom = BorderStyle.Thin;
                celdasData.VerticalAlignment = VerticalAlignment.Center;
                celdasData.Alignment = HorizontalAlignment.Center;                
                celdasData.FillPattern = FillPattern.SolidForeground;              
                XSSFColor customColor = new XSSFColor(new byte[] { 22, 181, 188 });
                ((XSSFCellStyle)celdasData).SetFillForegroundColor(customColor);               

                ISheet Sheet = workbook.CreateSheet("Performance");
                Sheet.CreateFreezePane(0, 0, 0, 0);

                IRow HeaderRow = Sheet.CreateRow(0);
                IRow Row1 = Sheet.CreateRow(1);
                IRow Row2 = Sheet.CreateRow(2);
                IRow Row3 = Sheet.CreateRow(3);
                IRow Row4 = Sheet.CreateRow(4);
                IRow Row5 = Sheet.CreateRow(5);
                IRow Row6 = Sheet.CreateRow(6);
                IRow Row7 = Sheet.CreateRow(7);
                IRow Row8 = Sheet.CreateRow(8);
                IRow Row9 = Sheet.CreateRow(9);
                IRow Row10 = Sheet.CreateRow(10);
                IRow Row11 = Sheet.CreateRow(11);
                IRow Row12 = Sheet.CreateRow(12);
                IRow Row13 = Sheet.CreateRow(13);
                IRow Row14 = Sheet.CreateRow(14);
                IRow Row15 = Sheet.CreateRow(15);
                IRow Row16 = Sheet.CreateRow(16);
                IRow Row17 = Sheet.CreateRow(17);
                IRow Row18 = Sheet.CreateRow(18);
                IRow Row19 = Sheet.CreateRow(19);
                IRow Row20 = Sheet.CreateRow(20);
                IRow Row21 = Sheet.CreateRow(21);
                IRow Row22 = Sheet.CreateRow(22);
                IRow Row23 = Sheet.CreateRow(23);
                IRow Row24 = Sheet.CreateRow(24);
                IRow Row25 = Sheet.CreateRow(25);
                IRow Row26 = Sheet.CreateRow(26);
                IRow Row27 = Sheet.CreateRow(27);
                IRow Row28 = Sheet.CreateRow(28);
                IRow Row29 = Sheet.CreateRow(29);


                CreateCell(HeaderRow, 0, "", celdasEncabezado);
                CreateCell(HeaderRow, 1, "", celdasEncabezado);
                CreateCell(HeaderRow, 2, "", celdasEncabezado);
                CreateCell(HeaderRow, 3, "", celdasEncabezado);
                CreateCell(HeaderRow, 4, "", celdasEncabezado);
                CreateCell(HeaderRow, 5, "", celdasEncabezado);
                CreateCell(HeaderRow, 6, "", celdasEncabezado);
                CreateCell(HeaderRow, 7, "", celdasEncabezado);
                CreateCell(HeaderRow, 8, "", celdasEncabezado);
                CreateCell(HeaderRow, 9, "", celdasEncabezado);
                CreateCell(HeaderRow, 10, "", celdasEncabezado);
                CreateCell(HeaderRow, 11, "", celdasEncabezado);
                CreateCell(HeaderRow, 12, "", celdasEncabezado);
                CreateCell(HeaderRow, 13, "", celdasEncabezado);
                CreateCell(HeaderRow, 14, "", celdasEncabezado);
                CreateCell(HeaderRow, 15, "", celdasEncabezado);
                CreateCell(HeaderRow, 16, "", celdasEncabezado);
                CreateCell(HeaderRow, 17, "", celdasEncabezado);
                CreateCell(HeaderRow, 18, "", celdasEncabezado);
                CreateCell(HeaderRow, 19, "", celdasEncabezado);
                CreateCell(HeaderRow, 20, "", celdasEncabezado);
                CreateCell(HeaderRow, 21, "", celdasEncabezado);
                CreateCell(HeaderRow, 22, "", celdasEncabezado);
                CreateCell(HeaderRow, 23, "", celdasEncabezado);
                CreateCell(HeaderRow, 24, "", celdasEncabezado);
                CreateCell(HeaderRow, 25, "", celdasEncabezado);
                CreateCell(HeaderRow, 26, "", celdasEncabezado);
                CreateCell(HeaderRow, 27, "", celdasEncabezado);
                CreateCell(HeaderRow, 28, "", celdasEncabezado);
                CreateCell(HeaderRow, 29, "", celdasEncabezado);

                CreateCell(Row1, 0, "", celdasEncabezado);
                CreateCell(Row1, 1, "", celdasEncabezado);
                CreateCell(Row1, 2, "", celdasEncabezado);
                CreateCell(Row1, 3, "", celdasEncabezado);
                CreateCell(Row1, 4, "", celdasEncabezado);
                CreateCell(Row1, 5, "", celdasEncabezado);
                CreateCell(Row1, 6, "", celdasEncabezado);
                CreateCell(Row1, 7, "", celdasEncabezado);
                CreateCell(Row1, 8, "", celdasEncabezado);
                CreateCell(Row1, 9, "", celdasEncabezado);
                CreateCell(Row1, 10, "", celdasEncabezado);
                CreateCell(Row1, 11, "", celdasEncabezado);
                CreateCell(Row1, 12, "", celdasEncabezado);
                CreateCell(Row1, 13, "", celdasEncabezado);
                CreateCell(Row1, 14, "", celdasEncabezado);
                CreateCell(Row1, 15, "", celdasEncabezado);
                CreateCell(Row1, 16, "", celdasEncabezado);
                CreateCell(Row1, 17, "", celdasEncabezado);
                CreateCell(Row1, 18, "", celdasEncabezado);
                CreateCell(Row1, 19, "", celdasEncabezado);
                CreateCell(Row1, 20, "", celdasEncabezado);
                CreateCell(Row1, 21, "", celdasEncabezado);
                CreateCell(Row1, 22, "", celdasEncabezado);
                CreateCell(Row1, 23, "", celdasEncabezado);
                CreateCell(Row1, 24, "", celdasEncabezado);
                CreateCell(Row1, 25, "", celdasEncabezado);
                CreateCell(Row1, 26, "", celdasEncabezado);
                CreateCell(Row1, 27, "", celdasEncabezado);
                CreateCell(Row1, 28, "", celdasEncabezado);
                CreateCell(Row1, 29, "", celdasEncabezado);

                CreateCell(Row2, 0, "", celdasEncabezado);
                CreateCell(Row2, 1, "", celdasEncabezado);
                CreateCell(Row2, 2, "", celdasEncabezado);
                CreateCell(Row2, 3, "", celdasEncabezado);
                CreateCell(Row2, 4, "", celdasEncabezado);
                CreateCell(Row2, 5, "", celdasEncabezado);
                CreateCell(Row2, 6, "", celdasEncabezado);
                CreateCell(Row2, 7, "", celdasEncabezado);
                CreateCell(Row2, 8, "", celdasEncabezado);
                CreateCell(Row2, 9, "", celdasEncabezado);
                CreateCell(Row2, 10, "", celdasEncabezado);
                CreateCell(Row2, 11, "", celdasEncabezado);
                CreateCell(Row2, 12, "", celdasEncabezado);
                CreateCell(Row2, 13, "", celdasEncabezado);
                CreateCell(Row2, 14, "", celdasEncabezado);
                CreateCell(Row2, 15, "", celdasEncabezado);
                CreateCell(Row2, 16, "", celdasEncabezado);
                CreateCell(Row2, 17, "", celdasEncabezado);
                CreateCell(Row2, 18, "", celdasEncabezado);
                CreateCell(Row2, 19, "", celdasEncabezado);
                CreateCell(Row2, 20, "", celdasEncabezado);
                CreateCell(Row2, 21, "", celdasEncabezado);
                CreateCell(Row2, 22, "", celdasEncabezado);
                CreateCell(Row2, 23, "", celdasEncabezado);
                CreateCell(Row2, 24, "", celdasEncabezado);
                CreateCell(Row2, 25, "", celdasEncabezado);
                CreateCell(Row2, 26, "", celdasEncabezado);
                CreateCell(Row2, 27, "", celdasEncabezado);
                CreateCell(Row2, 28, "", celdasEncabezado);
                CreateCell(Row2, 29, "", celdasEncabezado);

                CreateCell(Row3, 0, "Legajo", celdasData);
                CreateCell(Row3, 1, "idUsuario", celdasData);
                CreateCell(Row3, 2, "Nombre Colaborador", celdasData);
                CreateCell(Row3, 3, "Líder", celdasData);
                CreateCell(Row3, 4, "Convenio", celdasData);
                CreateCell(Row3, 5, "País", celdasData);
                CreateCell(Row3, 6, "Dominio", celdasData);
                CreateCell(Row3, 7, "Categoría", celdasData);
                CreateCell(Row3, 8, "Sexo", celdasData);
                CreateCell(Row3, 9, "Antigüedad", celdasData);
                CreateCell(Row3, 10, "Auto Aprendizaje Continuo", celdasData);
                CreateCell(Row3, 11, "Auto Autonomía", celdasData);
                CreateCell(Row3, 12, "Auto Colaboración", celdasData);
                CreateCell(Row3, 13, "Auto Comunicación Efectiva", celdasData);
                CreateCell(Row3, 14, "Auto Gestión del Cambio", celdasData);
                CreateCell(Row3, 15, "Auto Visión Sistémica", celdasData);
                CreateCell(Row3, 16, "Líder Aprendizaje Continuo", celdasData);
                CreateCell(Row3, 17, "Líder Autonomía", celdasData);
                CreateCell(Row3, 18, "Líder Colaboración", celdasData);
                CreateCell(Row3, 19, "Líder Comunicación Efectiva", celdasData);
                CreateCell(Row3, 20, "Líder Gestión del Cambio", celdasData);
                CreateCell(Row3, 21, "Líder Visión Sistémica", celdasData);
                CreateCell(Row3, 22, "Performance", celdasData);
                CreateCell(Row3, 23, "Calib. Aprendizaje Continuo", celdasData);
                CreateCell(Row3, 24, "Calib. Autonomía", celdasData);
                CreateCell(Row3, 25, "Calib. Colaboración", celdasData);
                CreateCell(Row3, 26, "Calib. Comunicación Efectiva", celdasData);
                CreateCell(Row3, 27, "Calib. Gestión del Cambio", celdasData);
                CreateCell(Row3, 28, "Calib. Visión Sistemica", celdasData);
                CreateCell(Row3, 29, "Calib. Performance", celdasData);

                setBordersToMergedCells(Sheet);
                int lastColumNum = Sheet.GetRow(1).LastCellNum;
                for (int i = 0; i <= lastColumNum; i++)
                {
                    Sheet.AutoSizeColumn(i, true);
                    GC.Collect();
                }

                var contador = 3;
                foreach (var item in lista)
                {
                    contador++;
                    IRow RowForeach = Sheet.CreateRow(contador);

                    CreateCell(RowForeach, 0, "", celdasInfo);
                    CreateCell(RowForeach, 1, "", celdasInfo);
                    CreateCell(RowForeach, 2, "", celdasInfo);
                    CreateCell(RowForeach, 3, "", celdasInfo);
                    CreateCell(RowForeach, 4, "", celdasInfo);
                    CreateCell(RowForeach, 5, "", celdasInfo);
                    CreateCell(RowForeach, 6, "", celdasInfo);
                    CreateCell(RowForeach, 7, "", celdasInfo);
                    CreateCell(RowForeach, 8, "", celdasInfo);
                    CreateCell(RowForeach, 9, "", celdasInfo);
                    CreateCell(RowForeach, 10, "", celdasInfo);
                    CreateCell(RowForeach, 11, "", celdasInfo);
                    CreateCell(RowForeach, 12, "", celdasInfo);
                    CreateCell(RowForeach, 13, "", celdasInfo);
                    CreateCell(RowForeach, 14, "", celdasInfo);
                    CreateCell(RowForeach, 15, "", celdasInfo);
                    CreateCell(RowForeach, 16, "", celdasInfo);
                    CreateCell(RowForeach, 17, "", celdasInfo);
                    CreateCell(RowForeach, 18, "", celdasInfo);
                    CreateCell(RowForeach, 19, "", celdasInfo);
                    CreateCell(RowForeach, 20, "", celdasInfo);
                    CreateCell(RowForeach, 21, "", celdasInfo);
                    CreateCell(RowForeach, 22, "", celdasInfo);
                    CreateCell(RowForeach, 23, "", celdasInfo);
                    CreateCell(RowForeach, 24, "", celdasInfo);
                    CreateCell(RowForeach, 25, "", celdasInfo);
                    CreateCell(RowForeach, 26, "", celdasInfo);
                    CreateCell(RowForeach, 27, "", celdasInfo);
                    CreateCell(RowForeach, 28, "", celdasInfo);
                    CreateCell(RowForeach, 29, "", celdasInfo);

                }
                string filePath = HttpContext.Current.Server.MapPath("~/assets/img/performanceIdentidad2024.png");                
                byte[] data = File.ReadAllBytes(filePath);                
                int pictureIndex = workbook.AddPicture(data, PictureType.PNG);
                ICreationHelper helper = workbook.GetCreationHelper();
                IDrawing drawing = Sheet.CreateDrawingPatriarch();
                IClientAnchor anchor = helper.CreateClientAnchor();
                anchor.Col1 = 0; // Columna inicial
                anchor.Row1 = 0; // Fila inicial
                anchor.Col2 = 2; // Columna final (ajusta según sea necesario)
                anchor.Row2 = 2; // Fila final (ajusta según sea necesario)

                IPicture picture = drawing.CreatePicture(anchor, pictureIndex);
                // Aumentar el tamaño de la imagen al 150% de su tamaño original
                picture.Resize(1.5);

                //Uniones
                CellRangeAddress union1 = new CellRangeAddress(0, 2, 0, 29);

                //Completa union
                Sheet.AddMergedRegion(union1);

                //Desactivo linea cuadriculada
                Sheet.DisplayGridlines = false;

                // Cantidad de columnas para mas de un tipo de licencia
                var g = 10;
                var cantidad = 0;
                ReporteExcelVM reporteExcelVM = new ReporteExcelVM();
                List<DetalleExcelVM> list = new List<DetalleExcelVM>();
                list.Capacity = 30;
                //foreach (var fila in list)
                //{
                //    int nroLic2 = fila.motivoLic.Count;
                //    if (nroLic2 > (cantidad + 1))
                //    {
                //        cantidad = nroLic2 + 1;
                //    }
                //}
                //var col = cantidad + g;

                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/TempFiles/")))
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/TempFiles/"));
                var pathInic = "~/TempFiles/";
                var nombreArchivo = "Performance_Colaboradores_" + Convert.ToDateTime(DateTime.Today).ToString("dd-MM-yyyy") + Convert.ToDateTime(DateTime.Now).ToString("HH-mm") + ".xlsx";
                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(pathInic), nombreArchivo);
                using (var fileData = new FileStream(path, FileMode.Create))
                {
                    workbook.Write(fileData);
                    fileData.Close();
                }

                reporteExcelVM.filePath = path;
                reporteExcelVM.fileName = nombreArchivo;
                return reporteExcelVM;
            }
        }

        private void setBordersToMergedCells(ISheet sheet)
        {
            int numMerged = sheet.NumMergedRegions;
            for (int i = 0; i < numMerged; i++)
            {
                CellRangeAddress mergedRegions = sheet.GetMergedRegion(i);
                RegionUtil.SetBorderLeft(1, mergedRegions, sheet);
                RegionUtil.SetBorderRight(1, mergedRegions, sheet);
                RegionUtil.SetBorderTop(1, mergedRegions, sheet);
                RegionUtil.SetBorderBottom(1, mergedRegions, sheet);

            }
        }
        private void CreateCell(IRow CurrentRow, int CellIndex, string Value, XSSFCellStyle Style)
        {
            ICell Cell = CurrentRow.CreateCell(CellIndex);
            Cell.SetCellValue(Value);
            Cell.CellStyle = Style;
        }
        public class CeldaColor
        {
            public string Color { get; set; }
        }
    }
}
