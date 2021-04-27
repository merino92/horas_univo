#pragma checksum "C:\Users\jose.merino\source\repos\merino92\horas_univo\Views\Boleta\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "772a06b46b5aa0b4f7d7a6c770acfa99c313856f"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"772a06b46b5aa0b4f7d7a6c770acfa99c313856f", @"/Views/Boleta/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3a2505cf01dd439490d870609700295e9356090", @"/Views/_ViewImports.cshtml")]
    public class Views_Boleta_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/tablaslide.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/datatables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/axios/axios.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/custom/boleta.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            DefineSection("css", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "772a06b46b5aa0b4f7d7a6c770acfa99c313856f4968", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("titulo", async() => {
                WriteLiteral("\r\n    <h1>Administracion de Boletas</h1>\r\n");
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
                                    <div");
            WriteLiteral(@" class=""form-group"">
                                        <label>fecha</label>
                                        <input type=""date"" class=""form-control form-control-sm"" id=""fbuscar"" />
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
                        ");
            WriteLiteral(@"<th scope=""col"">Fecha</th>
                        <th scope=""col"">Estado</th>
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
                    <div class=""col-lg-2 col-md-2 col-sm-12 col-xs-12"">
                        <di");
            WriteLiteral(@"v class=""form-group"">
                            <label>N° de Boleta</label>
                            <h5 class=""text-dark"" id=""nboleta""></h5>
                        </div>
                    </div>
                    <div class=""col-lg-4 col-md-4 col-sm-12 col-xs-12"">
                        <div class=""form-group"">
                            <label>Fecha</label>
                            <input type=""date"" class=""form-control form-control-sm"" id=""fecha"" />
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-lg-6 col-md-6 col-sm-12 col-xs-12"">
                        <div class=""form-group"">
                            <label>Encargado</label>
                            <input type=""text"" class=""form-control form-control-sm"" placeholder=""encargado"" id=""encargado"" />
                        </div>
                    </div>
                    <div class=""col-lg-4 col-md-4 col-sm-12");
            WriteLiteral(@" col-xs-12"">
                        <div class=""table-responsive mt-2"">
                            <table class=""table table-sm table-bordered table-hover fixed_header"">
                                <thead>
                                    <tr>
                                        <th>Facultades</th>
                                        <th><i class=""nav-icon fas fa-wrench""></i></th>
                                    </tr>
                                </thead>
                                <tbody id=""tfacultad""></tbody>
                            </table>
                        </div>
                    </div>
                    <div class=""col-lg-2 col-md-2 col-sm-12"">
                        <button type=""button"" class=""btn btn-success"" id=""btnfacultadadd"">Agregar</button>
                    </div>
                </div>
                <div class=""row"">

                    <div class=""col-lg-4 col-md-4 col-sm-12 col-xs-12"">
                        <div class=""");
            WriteLiteral(@"table-responsive"">
                            <table class=""table table-sm table-bordered table-hover fixed_header"">
                                <thead>
                                    <tr>
                                        <th>Carreras</th>
                                        <th><i class=""nav-icon fas fa-wrench""></i></th>
                                    </tr>
                                </thead>
                                <tbody id=""tcarreras""></tbody>
                            </table>
                        </div>
                    </div>
                    <div class=""col-lg-2 col-md-2 col-sm-12"">
                        <button type=""button"" class=""btn btn-success"" id=""btncarreradd"">Agregar</button>
                    </div>
                    <div class=""col-lg-4 col-md-4 col-sm-12 col-xs-12"">
                        <div class=""table-responsive"">
                            <table class=""table table-sm table-bordered table-hover fixed_header"">
");
            WriteLiteral(@"                                <thead>
                                    <tr>
                                        <th>Materias</th>
                                        <th><i class=""nav-icon fas fa-wrench""></i></th>
                                    </tr>
                                </thead>
                                <tbody id=""tmateria""></tbody>
                            </table>
                        </div>
                    </div>
                    <div class=""col-lg-2 col-md-2 col-sm-12"">
                        <button type=""button"" class=""btn btn-success"" id=""btnmateriadd"">Agregar</button>
                    </div>
                </div>

               

                <div class=""row"">
                    <div class=""col-lg-12 col-md-12 col-sm-12"">
                        <label>Detalle de boleta</label>
                        <div class=""table-responsive"">
                            <table class=""table table-bordered table-sm"">
                ");
            WriteLiteral(@"                <thead>
                                    <tr>
                                        <th>Cantidad</th>
                                        <th>Codigo</th>
                                        <th>Nombre del Material</th>
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
                <button type=""button"" class=""btn btn-sm btn-warning"" id=""btnupdate""><i class=""fa fa-retweet"" aria-hidden=""true""></i> Actualizar</button>
            </div>
        </div>
    </div>
</div>

<div class=""modal f");
            WriteLiteral(@"ade"" id=""modaldata"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Materias</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-12"">
                        <div class=""form-group"">
                            <label>Facultades</label>
                            <table class=""table table-sm table-bordered"">
                                <thead id=""mencabezado"">
                                <th>Nombre de Facultad</th>
                                </thead>
                                <tbody id=""detalletbl""></t");
            WriteLiteral(@"body>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>

<div class=""modal fade"" id=""modalinventario"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Listado de Materiales</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-12"">
                       
                            
                            <table class=""table table-sm table-bordered"">
                                <thead>
 ");
            WriteLiteral(@"                                   <tr>
                                        <th>Codigo</th>
                                       <th>Nombre</th>
                                        <th>Existencia</th>
                                    </tr>
                                </thead>
                                <tbody id=""inventariotbl""></tbody>
                            </table>
                       
                    </div>
                </div>
            </div>

        </div>
    </div>
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "772a06b46b5aa0b4f7d7a6c770acfa99c313856f17922", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "772a06b46b5aa0b4f7d7a6c770acfa99c313856f19022", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "772a06b46b5aa0b4f7d7a6c770acfa99c313856f20122", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\r\n");
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
