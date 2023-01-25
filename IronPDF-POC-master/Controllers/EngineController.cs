using IronPdf;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using resultado_pdf.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace resultado_pdf.Controllers {
    /// <summary>
    /// https://ironpdf.com/docs/license/license-keys/#trial-license
    /// </summary>
    public class EngineController : Controller {
        [HttpGet("v1/documentos/{fichaId:long}")]
        public ObterPDFResponse Run(long fichaId, [FromQuery(Name = "listaItemId")] string listaItemId = "", [FromQuery(Name = "listaProfissionalSaudeId")] string listaProfissionalSaudeId = "", [FromQuery(Name = "verificaPapelTimbrado ")] bool verificaPapelTimbrado = false, [FromQuery(Name = "idiomaId")] int idiomaId = 1) {
            IronPdf.HtmlToPdf renderer = new();
            IronPdf.ChromePdfRenderer rendererChrome = new();
            try {
                ObterPDFResponse obterPDFResponse;
                string html = "<!DOCTYPE html><html lang='en'><head><title>Basic HTML5 document</title><meta charset='utf-8'><style></style><script></script></head><body>";
                for(int i = 1; i < 11; i++) {
                    html += "<p style=\"color:red;\">PÁGINA: " + i.ToString() + "</p>";
                    html += "<div style='page-break-after: always;'> </div>";
                }
                html += "</body></html>";
                renderer.PrintOptions.PaperSize = IronPdf.Rendering.PdfPaperSize.A4;
                renderer.RenderingOptions.PaperOrientation = IronPdf.Rendering.PdfPaperOrientation.Portrait;
                renderer.PrintOptions.MarginLeft = 5;
                renderer.PrintOptions.MarginRight = 5;
                renderer.RenderingOptions.CreatePdfFormsFromHtml = true;
                renderer.RenderingOptions.InputEncoding = Encoding.UTF8;
                renderer.RenderingOptions.CssMediaType = IronPdf.Rendering.PdfCssMediaType.Print;
               

                renderer.RenderingOptions.HtmlHeader = new HtmlHeaderFooter() {
                    MaxHeight = 20, //millimeters
                    HtmlFragment = "<!DOCTYPE html><html><head><style>table{font-family: arial, sans-serif;border-collapse: collapse;width: 100%;}td, th {border: 1px solid #dddddd;text-align: left;padding: 8px;}tr:nth-child(even){background-color: #dddddd;}</style></head><body><h2>HTML Table</h2><table><tr><th>Company</th><th>Contact</th><th>Country</th></tr><tr><td>Alfreds Futterkiste</td><td>Maria Anders</td><td>Germany</td></tr><tr><td>Centro comercial Moctezuma</td><td>Francisco Chang</td><td>Mexico</td></tr><tr><td>Ernst Handel</td><td>Roland Mendel</td><td>Austria</td></tr><tr><td>Island Trading</td><td>Helen Bennett</td><td>UK</td></tr><tr><td>Laughing Bacchus Winecellars</td><td>Yoshi Tannamuri</td><td>Canada</td></tr><tr><td>Magazzini Alimentari Riuniti</td><td>Giovanni Rovelli</td><td>Italy</td></tr></table></body></html>",
                    DrawDividerLine = false
                };
                renderer.PrintOptions.MarginTop = 25;
                renderer.RenderingOptions.HtmlFooter = new HtmlHeaderFooter() {
                    MaxHeight = 20, //millimeters
                    HtmlFragment = "<left>Página: {page}/{total-pages}</left>",
                    DrawDividerLine = false
                };
                renderer.PrintOptions.MarginBottom = 5;
                var Base64Result = Convert.ToBase64String(renderer.RenderHtmlAsPdf(html).Stream.ToArray());


                //renderer.RenderHtmlAsPdf(html).SaveAs("Renderer.pdf");
                //rendererChrome.RenderingOptions.PaperSize = IronPdf.Rendering.PdfPaperSize.A4;
                //rendererChrome.RenderingOptions.PaperOrientation = IronPdf.Rendering.PdfPaperOrientation.Portrait;
                //rendererChrome.RenderingOptions.CreatePdfFormsFromHtml = true;
                //rendererChrome.RenderingOptions.MarginLeft = 5;
                //rendererChrome.RenderingOptions.MarginRight = 5;
                //rendererChrome.RenderingOptions.FirstPageNumber = 1;
                //rendererChrome.RenderingOptions.InputEncoding = Encoding.UTF8;
                //rendererChrome.RenderingOptions.FitToPaperMode = IronPdf.Engines.Chrome.FitToPaperModes.Automatic;
                //rendererChrome.RenderingOptions.HtmlHeader = new HtmlHeaderFooter() {
                //    MaxHeight = 600,
                //    DrawDividerLine = true
                //};
                //var pdf = rendererChrome.RenderHtmlAsPdf(html).SaveAs("RendererChrome.pdf");

                obterPDFResponse = new() {
                    base64PDF = Base64Result
                };
                return obterPDFResponse;
            } catch {
                throw;
            } finally {
                renderer.Dispose();
            }
        }
    }
}
