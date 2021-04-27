#pragma checksum "C:\Users\jose.merino\source\repos\merino92\horas_univo\Views\Movimiento\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "106edbf1188150023b2fa190f1eb38708b75abe8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movimiento_Index), @"mvc.1.0.view", @"/Views/Movimiento/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\jose.merino\source\repos\merino92\horas_univo\Views\_ViewImports.cshtml"
using univo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jose.merino\source\repos\merino92\horas_univo\Views\_ViewImports.cshtml"
using univo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"106edbf1188150023b2fa190f1eb38708b75abe8", @"/Views/Movimiento/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3a2505cf01dd439490d870609700295e9356090", @"/Views/_ViewImports.cshtml")]
    public class Views_Movimiento_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/moment/moment.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/datatables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/axios/axios.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/custom/movimiento.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("titulo", async() => {
                WriteLiteral("\r\n    <h1>Entradas Salidas</h1>\r\n");
            }
            );
            WriteLiteral(@"
<div class=""col-12"">
    <div class=""card "">
        <div class=""card-header"">
            <h5 class=""card-title"">Listado de Movimientos</h5>
        </div>

        <div class=""card-body"">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""card bg-light"">
                        <div class=""card-body "">
                            <div class=""row"">
                                <div class=""col-3"">
                                    <div class=""form-group"">
                                        <label>Codigo</label>
                                        <input type=""text"" class=""form-control form-control-sm"" id=""cbuscar"" />
                                    </div>
                                </div>
                                <div class=""col-sm-12 col-md-4 col-lg-4"">
                                    <div class=""form-group"">
                                        <label>Inicio</label>
                                   ");
            WriteLiteral(@"     <input type=""date"" class=""form-control form-control-sm"" id=""finicio"" />
                                    </div>
                                </div>
                                <div class=""col-sm-12 col-md-4 col-lg-4"">
                                   <div class=""form-group"">
                                       <label>Final</label>
                                        <input type=""date"" class=""form-control form-control-sm"" id=""ffin"" />
                                   </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <table class=""table table-bordered"">
                <thead>
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">Codigo</th>
                        <th scope=""col"">Fecha</th>
                        <th scope=""col"">Usuario</th>
                        ");
            WriteLiteral(@"<th scope=""col"">Opciones</th>
                    </tr>
                </thead>
                <tbody id=""tabla"">
                </tbody>
            </table>
        </div>
    </div>
</div> 
<div class=""modal fade"" id=""modal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
  <div class=""modal-dialog modal-lg"">
    <div class=""modal-content"">
       <div class=""modal-header"">
        <h5 class=""modal-title"">Historial de movimientos</h5>
        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
          <span aria-hidden=""true"">&times;</span>
        </button>
      </div>
      <div class=""modal-body"">
          <div class=""row"">
              <div class=""col-12"">
                 <div class=""form-group"">
                     <label id=""codigo""></label>
                     <input type=""text"" class=""form-control form-control-sm""  id=""nombre""  disabled/>
                 </div>
              </div>
          </div>
 ");
            WriteLiteral(@"         <div class=""row"">
              <div class=""col-lg-4 col-md-4 col-sm-12"">
                  <div class=""form-group"">
                      <label>Desde</label>
                      <input type=""date"" class=""form-control"" id=""fi"" />
                  </div>
              </div>
              <div class=""col-lg-4 col-md-4 col-sm-12"">
                    <div class=""form-group"">
                        <label>Hasta</label>
                       
                            <input type=""date"" class=""form-control"" id=""ff"" />
                            <div class=""input-group-append"">
                                <button  id=""btnfiltrar""  class=""btn btn-info"">Buscar</button>
                            </div>
                       
                  </div>
              </div>
          </div>
          <div class=""row"">
              <div class=""col-12"">
                  <div class=""form-group"">
                      <label>Concepto</label>
                      <input type=");
            WriteLiteral(@"""text"" class=""form-control form-control-sm"" id=""concepto"" disabled/>
                  </div>
              </div>
          </div>
          <div class=""row"">
              <div class=""col-12"">
                  <div class=""table-responsive"">
                      <table class=""table table-bordered"" id=""tinforme"" style=""max-height: 150px;overflow: auto;"">
                          <thead>
                              <tr>
                                  <th class=""text-center"">Fecha</th>
                                  <th class=""text-center"">Documento</th>
                                  <th class=""text-center"">Usuario</th>
                                  <th class=""text-center"">Entradas</th>
                                  <th class=""text-center"">Salidas</th>
                                  <th class=""text-center"">Saldo</th>
                              </tr>
                          </thead>
                          <tbody id=""thistorial""  ></tbody>
                     ");
            WriteLiteral(@" </table>
                  </div>
              </div>
          </div>
      </div>
      <div class=""modal-footer"">
          <button id=""btnimprimir"" class=""btn btn-danger""><i class=""fa fa-file"" aria-hidden=""true""></i> Imprimir</button>
      </div>
    </div>
  </div>
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "106edbf1188150023b2fa190f1eb38708b75abe810559", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "106edbf1188150023b2fa190f1eb38708b75abe811659", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "106edbf1188150023b2fa190f1eb38708b75abe812759", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n     <script src=\"https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.min.js\"></script>\r\n    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/jspdf-autotable/3.5.6/jspdf.plugin.autotable.min.js\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "106edbf1188150023b2fa190f1eb38708b75abe814081", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
