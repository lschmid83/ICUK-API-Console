using API.Controllers;
using API.Core.XmlComments;
using API.SDK;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Utils.Date;

namespace API.Core {

    /// <summary>
    /// Interactive console for testing API functions.
    /// </summary>
    public class ApiConsole : ConsoleRequest {

        /// <summary>
        /// List of API methods.
        /// </summary>
        public List<XmlMethodComment> ApiMethods { get; set; }
        /// <summary>
        /// Max length of a URL in menu before truncating.
        /// </summary>
        private const int MaxUrlLength = 38;

        /// <summary>
        /// PageActions.
        /// </summary>
        private Dictionary<string, Action> PageActions() {
            Dictionary<string, Action> actions = new Dictionary<string, Action> 
			{
				// Templated HTML producing functions.
				{ "",               Main                   },

				// AJAX functions.
				{ "search",         SearchMethods          },
                { "request",        ApiRequest             },
                { "method",         GetControllerMethod    }
            };

            return actions;
        }

        /// <summary>
        /// Sets page content depending on the page action.
        /// </summary>
        /// <returns>API Console page content.</returns>
        public string Index() {

            // Execute the requested page.
            ExecuteAction(PageActions());

            return PageContent;
        }
        
        /// <summary>
        /// Sends API request using the C# SDK.
        /// </summary>
        public void ApiRequest() {

            String result = String.Empty;

            string url = Request.Form.GetValues("url").FirstOrDefault<string>();
            string method = Request.Form.GetValues("method").FirstOrDefault<string>();
            string message = Request.Form.GetValues("message").FirstOrDefault<string>();
            
            IcukApiClient api = new IcukApiClient {
                Username = "admin",
                Key = "admin",
                Encryption = "SHA-512"
            };

            IcukApiRequest req = new IcukApiRequest {
                Method = method,
                Url = HostHandler.GetHostAddress() + url
            };

            if (message != "")
                req.Body = message;

            IcukApiResponse res = api.Send(req);
            if (res.Success) {
                result = res.Response;         
            }
            else {
                result = res.ErrorMessage;
            }
            
            if(res.Location != null)
                HttpContext.Current.Response.Headers.Add("Location", res.Location);
            HttpContext.Current.Response.StatusCode = res.StatusCode;

            PageContent = result;

        }  

        /// <summary>
        /// Searches for API methods and returns results as a HTML div element for the bootstrap accordion.
        /// </summary>
        private void SearchMethods() {

            if (String.IsNullOrEmpty(HttpContext.Current.Request["search_text"])) {
                return;
            }

            string searchText = HttpContext.Current.Request["search_text"];
           
            List<ApiMethod> methods = ApiMethod.SearchModuleMethods(0, searchText);

            if (methods.Count > 0) {
                PageContent = GetMethodMenuItems(methods, MaxUrlLength);
            }
            else {
                PageContent = String.Empty;
            }
        }

        /// <summary>
        /// Gets a API console method parameter table form.
        /// </summary>
        /// <param name="formClass">The css class of the form either "url-param" or "message-param".</param>
        /// <param name="type">Name of a predefined struct or "frombody" for message body parameters not defined in predefined struct. Suffixed with [] for array.</param>
        /// <param name="field">Name of the success field.</param>
        /// <returns>Parameter table structure.</returns>
        public string GetParameterForm(string formClass, string type, string field) {

            StringBuilder table = new StringBuilder();

            table.Append(@"
                    <table class='method-example parameter-table " + formClass + "' data-type='" + type + @"' data-field='" + field + "'>");
            
            table.Append(@"
                    <thead>
                        <tr>
                            <th>Parameter</th>
                            <th>Value</th>
                            <th>Type</th>
                            <th>Description</th>
                        </tr>
                    </thead>");

            table.Append(@"<tbody>");

            return table.ToString();
        }

        /// <summary>
        /// Gets the controller method input form.
        /// </summary>
        /// <returns>HTML form.</returns>
        public void GetControllerMethod() {

            StringBuilder html = new StringBuilder();

            // Get method and type comments from application state initialized in global.asax.
            HttpRequest request = HttpContext.Current.Request;
            Dictionary<string, XmlModuleComment> modules = (Dictionary<string, XmlModuleComment>)HttpContext.Current.Application["API_Modules"];
            List<XmlMethodComment> methods = modules[request["module"].ToString()].Methods;
            List<XmlTypeComment> types = modules[request["module"].ToString()].Types;
            List<XmlEnumComment> enums = modules[request["module"].ToString()].Enums;

            // Get selected method.
            XmlMethodComment method = (from m in methods
                                       where EscapeConsoleLink(m.Name) == request["method"]
                                       select m).FirstOrDefault();

            StringBuilder urlParam = new StringBuilder();
            StringBuilder bodyParam = new StringBuilder();
            StringBuilder nestedBodyParam = new StringBuilder();
            StringBuilder fromBodyParam = new StringBuilder();
            
            string methodUrl = method.Url;
            if (method.Parameters != null) {

                // Get a count of URL parameters.
                int urlParamCount = 0;
                foreach (XmlParameterComment parameter in method.Parameters) {

                    string parameterType = Regex.Replace(parameter.Type, @"<[^>]*>", String.Empty);

                    // Check if the parameter is a predefined struct.
                    XmlTypeComment type = (from t in types
                                           where t.Name == parameterType.Replace("[]", String.Empty)
                                           select t).FirstOrDefault();

                    if (type == null)
                        urlParamCount++;
                }

                // Method includes parameters in the URL.           
                if (method.UrlParam) {

                    // Remove parameters from path.
                    string[] segments = method.Url.Split('/');
                    string url = String.Empty;

                    for (int i = 0; i < segments.Length - urlParamCount; i++) {
                        url += segments[i] + '/';
                    }
                    methodUrl = url;
                }
            }

            html.Append(@"
                <div style='float:left;'>
                    <h2 class='method-name' data-param-in-url='" + method.UrlParam.ToLower() + "' data-type='" + method.Type + "'" + " data-url='" + methodUrl + "'>" + method.Name + @"</h2>
                    <p class='form-method-description'>" + method.Description + @"</p>
                </div>
                <div style='float:right;'>
                    <button type='button' class='btn btn-success btn-send-request'>Send Request</button>
                </div>
                <div style='float:right; padding-top:5px;'>
                    <input type='checkbox' class='chk-real-request' style='vertical-align: -2px;'>
                    <label class='chk-real-request-label'>Send real request</label>  
                </div>");

            html.Append(@"
                <div class='method-param' style='clear:both'>");
        
            // Method accepts parameters.
            if (method.Parameters != null) {

                // Create URL and Message body parameter tables.
                foreach (XmlParameterComment parameter in method.Parameters) {

                    // Remove documentation link from parameter type.
                    string typeLink = parameter.Type;
                    string parameterType = Regex.Replace(parameter.Type, @"<[^>]*>", String.Empty);

                    // Message body parameters which are not predefined structs are placed in a separate table. 
                    if (parameter.FromBody)
                        continue;

                    // Check if the parameter is a predefined struct.
                    XmlTypeComment type = (from t in types
                                           where t.Name == parameterType.Replace("[]", String.Empty)
                                           select t).FirstOrDefault();

                    // URL parameter.
                    if (type == null) {

                        if (urlParam.Length == 0) {
                            urlParam.Append(GetParameterForm("url-param", null, null));
                        }

                        bool customType = false;
                        bool customEnum = false;

                        urlParam.Append("<tr>");
                        urlParam.Append(GetParameterField(parameter.Type, parameter.Field, parameter.Optional, parameter.Description, parameter.Day, parameter.Date, parameter.Time, enums, ref customType, ref customEnum));
                        urlParam.Append("</tr>");

                    }
                    // Message body predefined struct. 
                    else {

                        string apiDocLink = "/docs/" + EscapeApiDocLink(request["module"]) + "#api-Type-" + EscapeApiDocLink(type.Name);

                        if (!parameter.FromBody) {
                            bodyParam.Append("<div class='form-type-name' style='font-size:14px; margin-bottom:4px;'>" + parameterType +
                                             "<a href='" + apiDocLink + "' " +
                                             "title='Open docs in a new window' target='_blank'><span class='glyphicon glyphicon-book open-type-doc'></span></a></div>");

                            // Add / remove array items.
                            if (parameterType.Contains("[]")) {
                                bodyParam.Append(@"
                                <div class='" + parameter.Field + @"'>
                                <div class='table-button-container'>
                                    <button id='add-array-item' type='button' class='btn btn-default table-button btn-add-table'>Add item</button>  
                                    <button id='remove-array-item' type='button' class='btn btn-default table-button btn-remove-table'>Remove item</button>  
                                </div>");
                            }
                        }

                        bodyParam.Append(GetParameterForm("message-param", parameterType, parameter.Field));
                        
                        foreach (XmlPropertyComment property in type.Properties) {

                            if (!property.ReadOnly) {
                                bodyParam.Append(@"
                    <tr>");

                                string propertyType = Regex.Replace(property.Type, @"<[^>]*>", String.Empty);
                                bool customType = false;
                                bool customEnum = false;
                                bodyParam.Append(GetParameterField(property.Type, property.Field, property.Optional, property.Description, property.Day, property.Date, property.Time, enums, ref customType, ref customEnum));

                                // Add new item (nested struct).
                                if(customType && !customEnum) {
                                    bodyParam.Append(@"
                        <td class='value'>
                            <button type='button' title='Add new item' data-type='" + propertyType + "' data-field='" + property.Field + @"' class='btn btn-success btn-add-struct'>+</button>
                            <button type='button' title='Remove item' data-type='" + propertyType + "' data-field='" + property.Field + @"' class='btn btn-success btn-remove-struct' disabled>-</button>
                        </td>    
                        <td class='type'>" + property.Type.Replace("<a href='", "<a href='/docs/" + request["module"].ToString()) + @"</td>");
                        bodyParam.Append("<td class='description'>" + property.Description + "</td>");
                                    nestedBodyParam = new StringBuilder();

                                    nestedBodyParam.Append("<div class='" + property.Field + @"' style='display:none'>");

                                    // Check if the parameter is a predefined struct.
                                    XmlTypeComment nestedType = (from t in types
                                                                    where t.Name == propertyType.Replace("[]", String.Empty)
                                                                    select t).FirstOrDefault();

                                    nestedBodyParam.Append(GetParameterForm("nested-message-param", propertyType, property.Field));

                                    foreach (XmlPropertyComment nestedProperty in nestedType.Properties) {

                                        string nestedPropertyType = Regex.Replace(nestedProperty.Type, @"<[^>]*>", String.Empty);

                                        if (!nestedProperty.ReadOnly) {
                                            nestedBodyParam.Append(@"
                                    <tr>");

                                            bool customNestedType = false;
                                            bool customNestedEnum = false;
                                            nestedBodyParam.Append(GetParameterField(nestedProperty.Type, nestedProperty.Field, nestedProperty.Optional, nestedProperty.Description, nestedProperty.Day, nestedProperty.Date, nestedProperty.Time, enums, ref customNestedType, ref customNestedEnum));
                                            
                                            nestedBodyParam.Append(@"      
                                    </tr>");

                                        }
                                    }

                                    nestedBodyParam.Append(@"</tbody>
					                                </table>
                                                    </div>");

                                }

                                bodyParam.Append(@"
                    </tr>");

                                if (customType && !customEnum) {
                                    bodyParam.Append(@"
                    <tr>
                        <td colspan='4' class='nested-param-row' style='display:none'>");

                                    bodyParam.Append(nestedBodyParam);

                                    bodyParam.Append(@" 
                        </td>           
                    </tr>");
                                }
                            }
                        }
  

                        bodyParam.Append(@"
                        </table>
                    </table>");

                    }

                    if (parameterType.Contains("[]")) {
                        bodyParam.Append("</div>");
                    }
                }

                // Create message body table for additional parameters which are not predefined structs.
                bool createdTableHeader = false;
                foreach (XmlParameterComment parameter in method.Parameters) {

                    if (parameter.FromBody) {

                        if (!createdTableHeader)
                            fromBodyParam.Append(GetParameterForm("message-param", "frombody", parameter.Field));

                        fromBodyParam.Append(@"
                        <tr>
                            <td class='parameter'>" + parameter.Field + @"</td>    
                            <td class='value'><input type='text' data-optional='" + parameter.Optional.ToLower() + "'  class='form-control' name='" + parameter.Field + @"'></td>     
                            <td class='type'>" + parameter.Type + @"</td>
                            <td class='description'>" + parameter.Description + @"
                        </tr>");

                        createdTableHeader = true;
                    }
                }

                if (createdTableHeader) {
                    fromBodyParam.Append(@"
                        </table>
                    </table>");
                }
            }

            if (urlParam.Length > 0) {

                urlParam.Append(@"
                        </table>
                    </table>");
                html.Append("<h3>URL Parameters</h3>");
                html.Append(urlParam);
                html.Append("</div>");
            }

            if (bodyParam.Length > 0 || fromBodyParam.Length > 0) {

                html.Append("<h3>Message Body</h3>");
                html.Append(fromBodyParam);
                html.Append(bodyParam);
                html.Append("</div>");
            }
          
            html.Append(@"
                    <div class='request-content'>
                        <h3>Request</h3>
                        <pre class='prettyprint language-json' style='height:250px; max-height:250px; overflow-y:auto' data-type='json'><code class='code-example example-request'></code></pre>
                    </div>
                    <div class='response-content'>
                        <h3>Response</h3>                        
                        <pre class='prettyprint language-json' style='height:250px; max-height:300px; overflow-y:auto' data-type='json'><code class='code-example example-response' ");
 
            // Get response example.
            XmlExampleComment example = (from e in method.Example 
                                         where e.Title == "Response"
                                         select e).First();

            html.Append("data-example='" + example.Content + "'>");

            html.Append(@"</code>
                        </pre>
                    </div>
                </div>");

            PageContent = html.ToString();
        }

        /// <summary>
        /// Gets message body parameter field table data.
        /// </summary>
        /// <param name="parameterType">Type of parameter.</param>
        /// <param name="parameterFieldName">Field name.</param> 
        /// <param name="parameterOptional">Optional field.</param>
        /// <param name="parameterDescription">Parameter description.</param>
        /// <param name="parameterDay">Number of working days to add to the date field.</param>
        /// <param name="displayDate">Enable date picker for datetime fields.</param>
        /// <param name="displayTime">Enable time picker for datetime fields.</param>
        /// <param name="enums">List of XmlEnumComment</param>
        /// <param name="customType">Is the property a custom type.</param>
        /// <param name="customEnum">Is the property an enum.</param>
        /// <returns>Table data for API request parameters.</returns>
        public StringBuilder GetParameterField(string parameterType, string parameterFieldName, bool parameterOptional, string parameterDescription, int parameterDay, bool displayDate, bool displayTime, List<XmlEnumComment> enums, ref bool customType, ref bool customEnum) {

            StringBuilder parameterField = new StringBuilder();
            HttpRequest request = HttpContext.Current.Request;

            string propertyType = Regex.Replace(parameterType, @"<[^>]*>", String.Empty);
            XmlEnumComment enumType = (from t in enums
                                       where t.Name == propertyType
                                       select t).FirstOrDefault();

            if (parameterType.Contains("<a href='")) {
                customType = true;
            }

            if (parameterType.Contains("'#api-Enum-") || parameterType == "Bool" || parameterType == "DateTime") {
                customEnum = true;
            }

            parameterField.Append(@"
                        <td class='parameter'>" + parameterFieldName + @"</td>");

            if (!customType && !customEnum) {
                parameterField.Append(@"
                        <td class='value'>
                            <input type='text' data-optional='" + parameterOptional.ToLower() + "' class='form-control' data-type='" + propertyType + "' name='" + parameterFieldName + @"'>"
     + "<label class='optional-field'>" + (parameterOptional ? "*" : "") + @"</label>
                        </td>    
                        <td class='type'>" + parameterType + @"</td>");
                parameterField.Append("<td class='description'>" + parameterDescription + "</td>");
            }
            else if (customEnum) {

                if (parameterType == "Bool") {

                    parameterField.Append(@"
                        <td class='value'>
                            <select name='" + parameterFieldName + @"' data-type='" + parameterType + @"' class='form-control combobox'>
                                <option value='true'>True</option>
                                <option value='false' selected='selected'>False</option>
                            </select>
                            <label class='optional-field'>" + (parameterOptional ? "*" : "") + @"</label>
                        </td>");
                }
                else if (parameterType == "DateTime") {

                    // Set datetime format
                    string dateTimePickerFormat = "YYYY-MM-DD";
                    string dateTimeFormat = "yyyy-MM-dd";

                    if (!displayDate && displayTime) {
                        dateTimePickerFormat = "HH:mm:ss";
                        dateTimeFormat = "HH:mm:ss";
                    }
                    else if (displayDate && displayTime) {
                        dateTimePickerFormat = "YYYY-MM-DDTHH:mm:ss";
                        dateTimeFormat = "yyyy-MM-ddTHH:mm:ss";   
                    }

                    parameterField.Append(@"
                        <td class='value'>
                            <div class='input-group date' data-date-format='" + dateTimePickerFormat + "' id='" + parameterFieldName + @"'>
                                <input type='text' class='form-control datetime' name='" + parameterFieldName + @"' value='" + WorkingDay.AddWorkingDays(DateTime.Now, parameterDay).ToString(dateTimeFormat) + @"' readonly/>
                                <span class='input-group-addon'><span class='glyphicon glyphicon-calendar'></span>
                                </span>
                            </div>
                            <script type='text/javascript'>
                                $(function () {
                                    $('#" + parameterFieldName + @"').datetimepicker({
                                        pickDate: " + displayDate.ToLower() + @",
                                        pickTime: " + displayTime.ToLower() + @"
                                    });
                                });
                                $('#" + parameterFieldName + @"').on('dp.change',function (e) {
                                    updateRequest();
                                });
                            </script>
                        </td>");
                }
                else {

                    parameterField.Append(@"
                        <td class='value'>
                            <select name='" + parameterFieldName + @"' class='form-control combobox'>");
                    foreach (XmlMemberComment member in enumType.Members) {
                        parameterField.Append(@"
                                <option value='" + member.Field + "'>" + member.Description + "</option>");
                    }
                    parameterField.Append(@"
                            </select>
                            <label class='optional-field'>" + (parameterOptional ? "*" : "") + @"</label>
                        </td>");

                }

                parameterField.Append("<td class='type'>" + parameterType.Replace("<a href='", "<a href='/docs/" + request["module"].ToString()) + @"</td>"); ;
                parameterField.Append("<td class='description'>" + parameterDescription + "</td>");

            }

            return parameterField;

        }
   

        /// <summary>
        /// Gets an unordered list of API methods separated by controller name.
        /// </summary>
        /// <param name="methods">List of ApiMethod objects.</param>
        /// <param name="maxUrlLength">Max length of URL's before truncating.</param>
        /// <returns>HTML unordered list.</returns>
        public string GetMethodMenuItems(List<ApiMethod> methods, int maxUrlLength) {

            StringBuilder html = new StringBuilder();

            html.Append("<ul class='module-menu'>");

            string currentGroup = null;
            foreach (ApiMethod method in methods) {

                /*
                if (user.UserId == 4 && method.Url == "/broadband/order/cease/{user@realm}")
                    continue;

                if (user.UserId == 4 && method.Url == "/broadband/order/migrate")
                    continue;

                if (user.UserId == 4 && method.Url == "/broadband/order/provide")
                    continue;*/

                string module = EscapeConsoleLink(method.Module);
                string controller = EscapeConsoleLink(method.Controller);
                string controllerMethod = EscapeConsoleLink(method.Name);

                string apiDocLink = "/docs/" + EscapeApiDocLink(method.Module) + "#api-" + EscapeApiDocLink(method.Controller) + "-" + EscapeApiDocLink(method.Name);

                // Add controller headings.
                if (currentGroup == null || currentGroup != method.Controller) {
                    html.Append("<li class='console-menu-controller'>");
                    html.Append(method.Controller);
                    html.Append("</li>");
                }
                    
                // Controller method.
                html.Append(@"
                        <li class='console-menu-method' id='" + module + "-" + controller + "-" + controllerMethod + @"'>
                        <a href='" + apiDocLink + "' " +
                            "title='Open docs in a new window' target='_blank'><span class='glyphicon glyphicon-book open-doc'></span></a>" +
                            "<span class='http-method " + method.HttpMethod.ToLower() + "'>" + method.HttpMethod.ToUpper() + @"</span>
                        <a class='method-url' title='" + (method.Url.Length > maxUrlLength ? method.Url + Environment.NewLine + method.Description : method.Description) + "' " +
                            (method.HttpMethod.Equals("Delete") ? "style='padding-left:8px'" : "style='padding-left:7px'") + ">" +
                            (method.Url.Length > maxUrlLength ? method.Url.Substring(0, maxUrlLength) + "..." : method.Url) + "</a></li>");

                currentGroup = method.Controller;

            }

            html.Append("</ul>");

            return html.ToString();
        }


        /// <summary>
        /// Escapes ApiDoc controller method documentation links.
        /// </summary>
        /// <param name="link">Link</param>
        /// <returns>Escaped link.</returns>
        private string EscapeApiDocLink(string link) {
            link = Regex.Replace(link, " ", "-");
            return Regex.Replace(link, @"[&\/\\#,+()$~%.'"":*?<>{}]+", "");
        }

        /// <summary>
        /// Escapes console API controller method links.
        /// </summary>
        /// <param name="link">Link</param>
        /// <returns>Escaped link.</returns>
        private string EscapeConsoleLink(string link) {
            link = Regex.Replace(link, " ", "");
            return Regex.Replace(link, @"[&\/\\#,+\-()$~%.'"":*?<>{}]+", "");
        }
        
        /// <summary>
        /// Produces HTML template for API console.
        /// </summary>
        /// <returns>API Console HTML.</returns>
        public void Main() {

            string template = HttpContext.Current.Application["ICUK_Template"].ToString();
            string title = "<title>ICUK API Console</title>";
            string css = @"<link href='/css/prettify.css' rel='stylesheet' media='screen'>
<link href='/css/console/style.css' rel='stylesheet' media='screen'>
<link href='/css/bootstrap-datetimepicker.css' rel='stylesheet' media='screen'>";

            string js = @"<script src='/javascript/jquery-2.0.3.js' type='text/javascript'></script>
<script src='/javascript/bootstrap.js'></script>
<script src='/javascript/api_console_core.js'></script>
<script src='/javascript/prettify.js'></script>
<script src='/javascript/moment.js'></script>
<script src='/javascript/bootstrap-datetimepicker.js'></script>";

            StringBuilder html = new StringBuilder();

            html.Append(@"
<div class='console-container'>");

            html.Append(@"
    <div class='body-wrapper'>");

            // Side navigation menu.
            html.Append(@"
        <div class='left-column'>");

            // Search field.
            html.Append(@"
            <div class='panel-group' id='accordion-search'>");

            html.Append(@"
                <div class='panel panel-default' style='margin-bottom:5px;'>");

            html.Append(@"
                    <div class='panel-heading'>
                        <h4 class='panel-title'>
                            <a class='accordion-toggle' data-toggle='collapse' data-parent='#accordion-search' href='#collapseSearch'>
                            Search
                            </a>
                        </h4>
                    </div>");

            html.Append(@"
                    <div id='collapseSearch' class='panel-collapse collapse'>
                        <div class='panel-body' style='overflow-y: hidden;' >
                            <form>
                                <div class='search-field'>
                                    <input id='search-field' type='text' class='form-control search-field-input'> 
                                </div>
                                <div class='search-field-button'>
                                    <button id='close-search' type='button' class='btn btn-default search-field-button'>Close</button>  
                                </div> 
                            </form>");

            html.Append(@"
                            <div class='search-results'></div>");

            html.Append(@"
                        </div>
                    </div>");

            html.Append(@"
                </div>"); // panel

            html.Append(@"
            </div>"); // panel-group

            // API Modules.
            html.Append(@"
            <div class='panel-group' id='accordion'>");

            // Module methods.
            List<ApiModule> modules = ApiModule.GetApiModules();
            foreach (ApiModule module in modules) {
                    html.Append(@"		    
                <div class='panel panel-default'>");

                    html.Append(@"
                    <div class='panel-heading'>
                        <h4 class='panel-title'>
                        <a class='accordion-toggle' data-toggle='collapse' data-parent='#accordion' href='#collapse" + module.Name + "'>");

                    html.Append(module.Name);

                    html.Append(@"
                        </a>
                        </h4>
                    </div>");

                    html.Append(@"
                    <div id='collapse" + module.Name + @"' class='panel-collapse collapse" + (module.Name.Equals("Broadband") ? " in' >" : @"' >") + @"
                        <div class='panel-body'>");

                    html.Append(GetMethodMenuItems(ApiMethod.GetModuleMethods(0, module), MaxUrlLength));

                    html.Append(@"
                        </div>
                    </div>
                </div>");
            }
            
            html.Append(@"
            </div>"); // panel-group  

            html.Append(@"
        </div>"); // left-column

            // Main content - API method test form
            html.Append(@"
        <div class='console-content'>
        </div>");


            html.Append(@"
    </div>"); // body-wrapper

            // Validation dialog.
            html.Append(@"
<div class='modal fade' id='console-dialog' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='overflow-y:auto'>
  <div class='modal-dialog'>
    <div class='modal-content'>
      <div class='modal-header'>
        <button type='button' class='close' data-dismiss='modal' aria-hidden='true'>&times;</button>
        <h4 class='modal-title'></h4>
      </div>
      <div class='modal-body'></div>
      <div class='modal-footer'>
        <button type='button' class='btn btn-default' data-dismiss='modal'>Close</button>
      </div>
    </div>
  </div>
</div>");      


            html.Append(@"
</div>"); // container

            template = template.Replace("<- title ->", title);
            template = template.Replace("<- css ->", css);
            template = template.Replace("<- js ->", js);
            template = template.Replace("<- content ->", html.ToString());
            template = template.Replace("<- module dropdown ->", ApiModule.GetModuleDropDown());

            PageContent = template;
        }
    }
}