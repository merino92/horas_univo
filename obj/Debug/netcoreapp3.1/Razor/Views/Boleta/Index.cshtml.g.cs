#pragma checksum "/Users/merino/Desktop/univo/Views/Boleta/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1414c3cacf779a8a53227f220c1e91b877bd3817"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Boleta_Index), @"mvc.1.0.view", @"/Views/Boleta/Index.cshtml")]
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
#line 1 "/Users/merino/Desktop/univo/Views/_ViewImports.cshtml"
using univo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/merino/Desktop/univo/Views/_ViewImports.cshtml"
using univo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1414c3cacf779a8a53227f220c1e91b877bd3817", @"/Views/Boleta/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3a2505cf01dd439490d870609700295e9356090", @"/Views/_ViewImports.cshtml")]
    public class Views_Boleta_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/datatables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/axios/axios.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/custom/boleta.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n\n\n");
            DefineSection("titulo", async() => {
                WriteLiteral("\n    <h1>Administracion de Boletas</h1>\n");
            }
            );
            WriteLiteral(@"
<div class=""col-12"">
    <div class=""card "">
        <div class=""card-header"">
            <h5 class=""card-title"">Boletas de Movimiento</h5>
            <button type=""button"" id=""btnew"" class=""btn btn-success float-right""><i class=""fa fa-plus"" aria-hidden=""true""></i> Nuevo</button>
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
                                <div class=""col-5"">
                                    <div class=""form-group"">
");
            WriteLiteral(@"                                        <label>fecha</label>
                                        <input type=""date"" class=""form-control form-control-sm"" id=""fecha"" />
                                    </div>
                                </div>
                                <div class=""col-2"">
                                    <div class=""form-group"">
                                        <label> </label>
                                        <button type=""button"" id=""btnbuscar"" class=""btn btn-info mt-3"">Buscar</button>
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
                 ");
            WriteLiteral(@"       <th scope=""col"">Estado</th>
                        <th scope=""col"">Opciones</th>
                    </tr>
                </thead>
                <tbody id=""tabla"">
                </tbody>
            </table>
        </div>
    </div>
</div>


<div class=""modal fade bd-example-modal-lg"" id=""modal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""mySmallModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg "">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""titulo"">Nuevo Nueva Boleta</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-lg-6 col-md-6 col-sm-12 col-xs-12"">
                        <div class=""form-group"">
                            <label>Fecha</label");
            WriteLiteral(@">
                            <input type=""date"" class=""form-control form-control-sm""  id=""fecha"" />
                        </div>
                    </div>
                    <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                        <div class=""form-group"">
                            <label>Encargado</label>
                            <input type=""text"" class=""form-control form-control-sm"" placeholder=""encargado"" id=""encargado"" />
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-sm-12 col-md-6 col-lg-2"">
                        <div class=""form-group"">
                            <label>Cantidad</label>
                            <input type=""numeric"" class=""form-control form-control-sm"" id=""cantidad"" />
                        </div>
                    </div>
                    <div class=""col-sm-12 col-md-6 col-lg-2"">
                        <div class=""form-group"">
            ");
            WriteLiteral(@"                <label>Codigo</label>
                            <input type=""text"" class=""form-control form-control-sm"" id=""descripcion"">
                        </div>
                    </div>
                    <div class=""col-sm-12 col-md-12 col-lg-6"">
                        <div class=""form-inline"">
                            <div class=""form-group"">
                                <label>Detalle de Producto</label>
                                <div class=""input-group"">
                                    <div class=""input-group-append"">
                                    <div class=""input-group-text"" id=""btnGroupAddon2"">Buscar</div>
                                    </div>
                                    <input type=""text"" class=""form-control"" placeholder=""Input group example"" aria-label=""Input group example"" aria-describedby=""btnGroupAddon2"">
                                </div>
                            </div>
                        </div>
                    </div>
              ");
            WriteLiteral(@"  </div>
                <div class=""row"">
                    <div class=""col-lg-12 col-md-12 col-sm-12"">
                        <label>Detalle de boleta</label>
                        <div class=""table-responsive"">
                            <table class=""table table-bordered table-sm"">
                                <thead>
                                <tr>
                                    <th>Cantidad</th>
                                    <th>Detalle</th>
                                    <th>Opciones</th>
                                </tr>
                                </thead>
                                <tbody id=""cuerpo""></tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-sm btn-success"" id=""btnsave""><i class=""fa fa-plus-circle"" aria-hidden=""true""></i> Guardar</button>
                <button ty");
            WriteLiteral("pe=\"button\" class=\"btn btn-sm btn-warning\" id=\"btnupdate\"><i class=\"fa fa-retweet\" aria-hidden=\"true\"></i> Actualizar</button>\n            </div>\n        </div>\n    </div>\n</div>\n\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1414c3cacf779a8a53227f220c1e91b877bd381711032", async() => {
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
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1414c3cacf779a8a53227f220c1e91b877bd381712116", async() => {
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
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1414c3cacf779a8a53227f220c1e91b877bd381713200", async() => {
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
                WriteLiteral("\n  \n\n");
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