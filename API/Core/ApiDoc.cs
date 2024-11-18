using API.Controllers;
using API.Core.Enum;
using API.Core.XmlComments;
using DocsByReflection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using Utils.Enumeration;

namespace API.Core {
    
    /// <summary>
    /// Creates API documentation using reflection.
    /// </summary>
    public class ApiDoc {

        /// <summary>
        /// Reads XML comments from methods using reflection.
        /// </summary>
        /// <param name="type">The type to create documentation for.</param>
        /// <param name="apiModule">API module information.</param>
        /// <param name="structs">List of custom structs defined in the API module.</param>
        /// <param name="enums">List of custom enums defined in the API module.</param>
        /// <returns>List of the XmlMethodComment objects.</returns>
        public List<XmlMethodComment> GetMethodDocumentation(Type type, ApiModule apiModule, List<XmlTypeComment> structs, List<XmlEnumComment> enums) {

            List<XmlMethodComment> methods = new List<XmlMethodComment>();
            
            // Get method info for public methods which are not inherited.
            MethodInfo[] methodInfo = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);

            // Read XML type comments.
            XmlElement typeElement = null;
            try {
                typeElement = DocsByReflection.DocsService.GetXmlFromType(type);
            }
            catch (Exception e) {
                throw new XmlCommentException(e.Message, type.GetTypeInfo());
            }

            // Loop through methods.
            foreach (MethodInfo method in methodInfo) {

                // Only read documentation from Web API method with attributes e.g. [HttpGet]
                if (method.GetCustomAttributes(typeof(Attribute)).Count() == 0 && type.Name == "BroadbandOrderController")
                    break;

                string controllerDescription = "";
                try {
                    controllerDescription = typeElement["description"].InnerText;
                }
                catch (Exception) { }

                // Read XML method comments.
                XmlElement xmlComment = null;
                try {
                    xmlComment = DocsByReflection.DocsService.GetXmlFromMember(method);
                }
                catch (Exception e) {
                    throw new XmlCommentException(e.Message, type.GetTypeInfo());
                }
                XmlMethodComment methodComment = new XmlMethodComment() {
                    Name = xmlComment["name"] == null ? null : xmlComment["name"].InnerText,
                    Description = xmlComment["description"] == null ? null : xmlComment["description"].InnerText,
                    ControllerName = type.Name,
                    ControllerDescription = controllerDescription,
                    Type = xmlComment["type"] == null ? null : xmlComment["type"].InnerText,
                    Url = xmlComment["url"] == null ? null : xmlComment["url"].InnerText,
                    UrlParam = xmlComment["url-param"] == null ? true : xmlComment["url-param"].InnerText.IsValidBool(),
                    UserType = ApiUserTypes.ICUK_CUSTOMER,
                    Group = xmlComment["group"] == null ? null : xmlComment["group"].InnerText,
                    MethodInfo = method,
                    ApiModule = apiModule
                };

                // Read method parameter comments.
                if (xmlComment["parameter"] != null) {

                    XmlNodeList nodes = xmlComment.GetElementsByTagName("parameter");
                    foreach (XmlNode node in nodes) {

                        XmlParameterComment parameterComment = new XmlParameterComment() {
                            Type = node["type"] == null ? null : GetTypeLink(node["type"].InnerText, structs, enums),
                            Field = node["field"] == null ? null : node["field"].InnerText,
                            Optional = node["optional"] == null ? false : node["optional"].InnerText.IsValidBool(),
                            Description = node["description"] == null ? null : node["description"].InnerText,
                            Day = node["day"] == null ? 0 : Convert.ToInt32(node["day"].InnerText),
                            Time = node["time"] == null ? false : Convert.ToBoolean(node["time"].InnerText),
                            Date = node["date"] == null ? true : Convert.ToBoolean(node["date"].InnerText),
                            FromBody = node["frombody"] == null ? false : node["frombody"].InnerText.ToString().IsValidBool(),
                            MethodInfo = method
                        };
                        methodComment.Parameters.Add(parameterComment);
                    }
                }

                // Read success response comments.
                if (xmlComment["success"] != null) {

                    XmlNodeList nodes = xmlComment.GetElementsByTagName("success");
                    methodComment.Success = new List<XmlSuccessComment>();
                    foreach (XmlNode node in nodes) {

                        XmlSuccessComment successComment = new XmlSuccessComment() {
                            Type = node["type"] == null ? null : GetTypeLink(node["type"].InnerText, structs, enums),
                            Field = node["field"] == null ? null : node["field"].InnerText,
                            Optional = node["optional"] == null ? false : node["optional"].InnerText.IsValidBool(),
                            Description = node["description"] == null ? null : node["description"].InnerText,
                            MethodInfo = method
                        };

                        methodComment.Success.Add(successComment);
                    }
                }


                // Read errror response comments.
                if (xmlComment["error"] != null) {

                    XmlNodeList nodes = xmlComment.GetElementsByTagName("error");
                    methodComment.Error = new List<XmlErrorComment>();
                    foreach (XmlNode node in nodes) {

                        XmlErrorComment errorComment = new XmlErrorComment() {
                            Type = node["type"] == null ? null : node["type"].InnerText,
                            Description = node["description"] == null ? GetErrorDescription(node["type"].InnerText) : node["description"].InnerText,
                            MethodInfo = method
                        };

                        methodComment.Error.Add(errorComment);
                    }
                }


                // Read example response comments.
                if (xmlComment["example"] != null) {

                    XmlNodeList nodes = xmlComment.GetElementsByTagName("example");
                    methodComment.Example = new List<XmlExampleComment>();
                    foreach (XmlNode node in nodes) {

                        XmlExampleComment exampleComment = new XmlExampleComment() {
                            Title = node["title"] == null ? null : node["title"].InnerText,
                            Content = node["content"] == null ? null : node["content"].InnerText,
                            MethodInfo = method
                        };

                        methodComment.Example.Add(exampleComment);
                    }
                }

                methodComment.Validate();
                methods.Add(methodComment);
            }

            return methods;
        }

        /// <summary>
        /// Gets generic description for API exception types.
        /// </summary>
        /// <param name="errorType">API exception type defined in API.Core.Exceptions</param>
        /// <returns>Description of exception.</returns>
        public string GetErrorDescription(string errorType) {
            
            string descr = "";

            switch (errorType) {
                case "DataUsageException": descr = "Unable to retrieve data usage."; break;
                case "DeleteResourceException": descr = "Unable to delete resource."; break;
                case "InternalApiException": descr = "Internal API exception occured."; break;
                case "InvalidParameterException": descr = "Parameter is not valid."; break;
                case "NonExistentUserException": descr = "User does not exist."; break;
                case "NotLiveException": descr = "Account is not live."; break;
                case "PasswordException": descr = "Invalid password supplied."; break;
                case "PaymentException": descr = "Your card details have been declined."; break;
                case "RequestTimeoutException": descr = "Request timeout."; break;
                default: break;
            };

            return descr;
           
        }
        
        /// <summary>
        /// Reads XML comments from enums using reflection.
        /// </summary>
        /// <param name="type">The enum to create documentation for.</param>
        /// <returns>List of XmlEnumComment objects.</returns>
        public XmlEnumComment GetEnumDocumentation(Type type) {

            List<XmlEnumComment> enums = new List<XmlEnumComment>();

            // Get enumerators.
            MemberInfo[] members = type.GetMembers(BindingFlags.Public | BindingFlags.Static);

            // Read XML enum comments. 
            XmlElement xmlComment = null;
            try {
                xmlComment = DocsService.GetXmlFromType(type);
            }
            catch (Exception e) {
                throw new XmlCommentException(e.Message, type.GetTypeInfo());
            }

            XmlEnumComment typeComment = new XmlEnumComment() {
                Name = type.Name,
                Description = xmlComment["description"] == null ? null : xmlComment["description"].InnerText,
                UserType = ApiUserTypes.ICUK_CUSTOMER,
                Group = xmlComment["group"] == null ? null : xmlComment["group"].InnerText,
                PropertyInfo = type.GetProperties().FirstOrDefault<PropertyInfo>()
            };

            // Loop through enumerators.
            typeComment.Members = new List<XmlMemberComment>();

            foreach (MemberInfo member in members) {

                XmlNode node = null;
                try {
                    XmlElement propertyComment = DocsService.GetXmlFromMember(member);
                    node = propertyComment.GetElementsByTagName("summary")[0];
                }
                catch (Exception) {}

                XmlMemberComment fieldComment = new XmlMemberComment() {
                    Field = member.Name,
                    Value = (int)System.Enum.Parse(Type.GetType(type.Namespace + "." + type.Name), member.Name),
                    Description = EnumTools.GetEnumDescription(member),
                    Summary = node != null ? node.InnerText.Trim() : null,
                    MemberInfo = member
                };

                typeComment.Members.Add(fieldComment);
                typeComment.Validate();
  
            }
            return typeComment;
        }
        
        /// <summary>
        /// Reads XML comments from structs using reflection.
        /// </summary>
        /// <param name="type">The type to create documentation for.</param>
        /// <returns>List of XmlTypeComment objects.</returns>
        public XmlTypeComment GetStructDocumentation(Type type) {

            List<XmlTypeComment> structs = new List<XmlTypeComment>();

            // Get members of struct.
            PropertyInfo[] properties = type.GetProperties();

            // Read XML struct comments.
            XmlElement xmlComment = null;
            try {
                xmlComment = DocsService.GetXmlFromType(type);
            }
            catch (Exception e) {
                throw new XmlCommentException(e.Message, type.GetTypeInfo());
            }

            XmlTypeComment typeComment = new XmlTypeComment() {
                Name = type.Name,
                Description = xmlComment["description"] == null ? null : xmlComment["description"].InnerText,
                UserType = ApiUserTypes.ICUK_CUSTOMER,
                Group = xmlComment["group"] == null ? null : xmlComment["group"].InnerText,
                PropertyInfo = type.GetProperties().FirstOrDefault<PropertyInfo>()
            };
                    
            // Loop through members.
            typeComment.Properties = new List<XmlPropertyComment>();
            foreach (PropertyInfo property in properties) {

                PropertyInfo p = type.GetProperty(property.Name);

                XmlNode node = null;
                XmlPropertyComment fieldComment;

                try {
                    XmlElement propertyComment = DocsService.GetXmlFromMember(p);
                    node = propertyComment.GetElementsByTagName("property")[0];

                    fieldComment = new XmlPropertyComment() {
                        Type = node["type"] == null ? null : node["type"].InnerText,
                        Field = p.Name,
                        Day = node["day"] == null ? 0 : Int32.Parse(node["day"].InnerText),
                        Time = node["time"] == null ? false : Convert.ToBoolean(node["time"].InnerText),
                        Date = node["date"] == null ? true : Convert.ToBoolean(node["date"].InnerText),
                        ReadOnly = node["readonly"] == null ? false : node["readonly"].InnerText.IsValidBool(),
                        Optional = node["optional"] == null ? false : node["optional"].InnerText.IsValidBool(),
                        Description = node["description"] == null ? null : node["description"].InnerText,
                        PropertyInfo = p
                    };

                }
                catch(Exception) {
                    fieldComment = new XmlPropertyComment() {
                        PropertyInfo = p
                    };
                }
 
                typeComment.Properties.Add(fieldComment);
                typeComment.Validate();
     
            }
            return typeComment;
        }
        
        /// <summary>
        /// Gets a documentation link if the type is a custom struture. 
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="structs">List of custom structs defined in the API module.</param>
        /// <param name="enums">List of custom enums defined in the API module.</param>
        public string GetTypeLink(string typeName, List<XmlTypeComment> structs, List<XmlEnumComment> enums) {

            string link = String.Empty;
            var customStruct = (from i in structs
                                where i.Name.Equals(typeName.Replace("[]", String.Empty))
                                select i);

            var customEnum = (from i in enums
                              where i.Name.Equals(typeName.Replace("[]", String.Empty))
                              select i);


            if (customStruct.Any())
                return "<a href='#api-Type-" + typeName.Replace("[]", String.Empty) + @"'>" + typeName + "</a>";
            else if(customEnum.Any())
                return "<a href='#api-Enum-" + typeName.Replace("[]", String.Empty) + @"'>" + typeName + "</a>";
            else
                return typeName;
        }
         
        /// <summary>
        /// Builds API documentation.
        /// </summary>
        public void BuildDocumentation() {

            // Stores all API method comments.
            List<XmlMethodComment> apiMethods = new List<XmlMethodComment>();

            // Get module names.
            List<ApiModule> modules = ApiModule.GetApiModules();
            
            // Loop through modules and create documentation.
            foreach (ApiModule module in modules) {
                string ns = "API.Controllers." + module.Name;
                string outputPath = HttpRuntime.AppDomainAppPath + "javascript\\docs\\" + module.Name.ToLower() + ".js";
                apiMethods.AddRange(BuildModuleDocumentation(ns, outputPath, module));
            }

            // Find any methods with duplicate url and type.
            var duplicateUrl = apiMethods.GroupBy(i => new { i.Type, i.Url })
                                         .Where(g => g.Count() > 1)
                                         .Select(g => g.Key);

            var count = duplicateUrl.Count();
            if (count > 0) {
                
                // Get the first duplicate method.
                var firstException = duplicateUrl.FirstOrDefault();
                
                // Get method info for duplicates.
                var apiMethodExceptions = (from i in apiMethods
                                           where i.Url == firstException.Url &&
                                           i.Type == firstException.Type
                                           select new { i.MethodInfo });

                throw new XmlCommentException("There are methods with duplicate <url> elements.", (from i in apiMethodExceptions select i.MethodInfo).FirstOrDefault<MethodInfo>());      
            }

            // Find any methods with duplicate names.
            var duplicateName = apiMethods.GroupBy(i => new { i.Name })
                                          .Where(g => g.Count() > 1)
                                          .Select(g => g.Key);

            count = duplicateName.Count();
            if (count > 0) {

                // Get the first duplicate method.
                var firstException = duplicateName.FirstOrDefault();

                // Get method info for duplicates.
                var apiMethodExceptions = (from i in apiMethods
                                           where i.Name == firstException.Name
                                           select new { i.MethodInfo });

                throw new XmlCommentException("There are methods with duplicate <name> elements.", (from i in apiMethodExceptions select i.MethodInfo).FirstOrDefault<MethodInfo>());      
            }

            // Delete existing methods from the database.
            using (SqlConnection con = Database.Open()) {

                SqlCommand cmd = new SqlCommand(@"DELETE FROM icuk_api.dbo.Tbl_Method");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }

            // Delete existing controllers from the database.
            using (SqlConnection con = Database.Open())
            {

                SqlCommand cmd = new SqlCommand(@"DELETE FROM icuk_api.dbo.Tbl_Controller");
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
                        
            // Get list of controller names.
            var controllerNames = apiMethods.GroupBy(i => new { i.Group, i.ApiModule.ModuleID })
                                            .Select(g => g.Key);

            // Add new controllers to the database.
            foreach (var controller in controllerNames) {

                using (SqlConnection con = Database.Open()) {

                    // Check if controller exists in database.
                    SqlCommand cmd = new SqlCommand(@"SELECT Count(Controller_ID)
                                                      FROM icuk_api.dbo.Tbl_Controller
                                                      WHERE Controller_Name = @Controller_Name");                 
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("Controller_Name", controller.Group));

                    int rows = Convert.ToInt32(cmd.ExecuteScalar());

                    // Controller does not exist in database.
                    if (rows == 0) {

                        // Add controller to the database.
                        cmd = new SqlCommand(@"INSERT INTO icuk_api.dbo.Tbl_Controller
                                               VALUES (@Module_ID, @Controller_Name)");
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("Module_ID", controller.ModuleID));
                        cmd.Parameters.Add(new SqlParameter("Controller_Name", controller.Group));

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // Get controller information from database.
            List<ApiController> controllers = ApiController.GetApiControllers();

            // Add new methods to the database.
            foreach(XmlMethodComment method in apiMethods)
            {
                int rows = 0;
                using (SqlConnection con = Database.Open()) {

                    // Check if method exists in database.
                    SqlCommand cmd = new SqlCommand(@"SELECT Count(Method_ID)
                                                      FROM icuk_api.dbo.Tbl_Method
                                                      WHERE Http_Method = @Http_Method AND
                                                            Url = @Url");
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("Http_Method", method.Type));
                    cmd.Parameters.Add(new SqlParameter("Url", method.Url));

                    rows = Convert.ToInt32(cmd.ExecuteScalar());
                }

                using (SqlConnection con = Database.Open())
                {
                    // Method does not exist in database.
                    if (rows == 0) {
  
                        // Add method to the database.
                        SqlCommand cmd = new SqlCommand(@"INSERT INTO icuk_api.dbo.Tbl_Method 
                                                         VALUES (@Module_ID, @Controller_ID, @Method_Name, @Method_Description, @Http_Method, @Url, @User_Type_Permissions)
                                               ");
                        cmd.Connection = con;
                        cmd.Parameters.Add(new SqlParameter("Module_ID", method.ApiModule.ModuleID));
                        var controllerID = (from i in controllers 
                                           where i.Name == method.Group
                                           select i.ControllerID).FirstOrDefault();
                        cmd.Parameters.Add(new SqlParameter("Controller_ID", Convert.ToInt32(controllerID)));
                        cmd.Parameters.Add(new SqlParameter("Method_Name", method.Name));
                        cmd.Parameters.Add(new SqlParameter("Method_Description", method.Description));
                        cmd.Parameters.Add(new SqlParameter("Http_Method", method.Type));
                        cmd.Parameters.Add(new SqlParameter("Url", method.Url));
                        cmd.Parameters.Add(new SqlParameter("User_Type_Permissions", (int)method.UserType));

                        cmd.ExecuteNonQuery();  
                    }                
                }
            }
        }

        /// <summary>
        /// Writes a JSON file to the output path containing method and type documentation for the controller namespace.
        /// </summary>
        /// <param name="controllerNamespace">Controller namespace e.g. API.Controllers.Broadband.</param>
        /// <param name="outputPath">Output path for the documentation.</param>
        /// <param name="module">API module information.</param>
        /// <returns>List of XmlMethodComment objects.</returns>
        public List<XmlMethodComment> BuildModuleDocumentation(string controllerNamespace, string outputPath, ApiModule module) {
            
            StringBuilder json = new StringBuilder();

            List<XmlMethodComment> moduleMethods = new List<XmlMethodComment>();

            // Construct controller method documentation.
            json.Append(@"[");

            // Get IcukApiController types in the namespace. 
            Assembly asm = Assembly.GetExecutingAssembly();

            // List of valid types defined in controller namespace.
            List<string> types = new List<string>();
            types.Add("String");
            types.Add("Integer");
            types.Add("Bool");
            types.Add("Long");
            types.Add("Decimal");
            types.Add("DateTime");

            Regex typeRegex = new Regex(@"<[^>]*>", RegexOptions.Compiled);
 
            // Get enums defined in the namespace.
            List<XmlEnumComment> enums = new List<XmlEnumComment>();
            foreach (Type type in asm.GetTypes()) {
                if (type.Namespace == controllerNamespace + ".Enum" && type.IsValueType && !type.IsPrimitive && type.Namespace != null && !type.Namespace.StartsWith("System.")) {
                    XmlEnumComment e = GetEnumDocumentation(type);
                    enums.Add(e);
                    types.Add(e.Name);
                }
            }

            // Get structs defined in the namespace.
            List<XmlTypeComment> structs = new List<XmlTypeComment>();
            foreach (Type type in asm.GetTypes()) {
                if (type.Namespace == controllerNamespace + ".Types" && type.IsValueType && !type.IsPrimitive && type.Namespace != null && !type.Namespace.StartsWith("System.")) {
                    XmlTypeComment s = GetStructDocumentation(type);
                    structs.Add(s);
                    types.Add(s.Name);
                }
            }

            // Get exceptions defined in the namespace.
            List<string> exceptions = new List<string>();
            foreach (Type type in asm.GetTypes()) {
                if (type.Namespace == "API.Core.Exceptions") {
                    exceptions.Add(type.Name);
                }
            }

            // Validate data types.
            foreach (XmlTypeComment s in structs) {
                foreach (XmlPropertyComment p in s.Properties) {
                    if (!types.Contains(p.Type.Replace("[]", "")))
                        throw new XmlCommentException("The <property> -> <type> is an invalid data type.", p.PropertyInfo);
                }
            }
            // Set struct property documentation links.
            for (int a = 0; a < structs.Count; a++) {
                for (int b = 0; b < structs[a].Properties.Count; b++) {
                    structs[a].Properties[b].Type = GetTypeLink(structs[a].Properties[b].Type, structs, enums);
                }
                // Write struct documentation.
                json.Append(structs[a].ToJson());
            }

            // Write enum documentation.
            for (int a = 0; a < enums.Count; a++) {
                json.Append(enums[a].ToJson());
            }
                        
            // Get controllers defined in the namespace.
            bool hasApiController = false;
            foreach (Type type in asm.GetTypes()) {

                if (type.Namespace == controllerNamespace) {
                    
                    if (type.IsSubclassOf(typeof(IcukApiController))) {
                        
                        // Get method documentation.
                        List<XmlMethodComment> controllerMethods = GetMethodDocumentation(type, module, structs, enums);
                        foreach (XmlMethodComment method in controllerMethods) {

                            // Validate data types exist in the API.
                            foreach (XmlParameterComment p in method.Parameters) {
                                if (!types.Contains(typeRegex.Replace(p.Type.Replace("[]", ""), "")))
                                    throw new XmlCommentException("The <parameter>" + p.Field + "</parameter> -> <type> is an invalid data type.", p.MethodInfo);
                            }

                            foreach (XmlSuccessComment s in method.Success) {
                                if (!types.Contains(typeRegex.Replace(s.Type.Replace("[]", ""), "")))
                                    throw new XmlCommentException("The <success>" + s.Field + "</success> -> <type> is an invalid data type.", s.MethodInfo);
                            }

                            foreach (XmlErrorComment s in method.Error) {
                                if (!exceptions.Contains(s.Type))
                                    throw new XmlCommentException("The <error>" + s.Type + "</error> -> <type> is an invalid data type.", s.MethodInfo);
                            }
                            
                            // Write method documentation.
                            json.Append(method.ToJson());
                        }
                        hasApiController = true;
                        moduleMethods.AddRange(controllerMethods);
                    }
                    else {
                        if(!type.IsNested)
                            throw new XmlCommentException("API controllers must inherit IcukApiController.", type.GetTypeInfo());
                    }

                }
            }

                        
            json.Remove(json.Length - 1, 1);
  
            json.Append(@"
]");

            if (!hasApiController)
                json.Clear();
            
            // Write documentation to file.
            if(!String.IsNullOrEmpty(outputPath))
                File.WriteAllText(outputPath, json.ToString());
            
            return moduleMethods;
        }
                
        /// <summary>
        /// Get main API documentation page.
        /// </summary>
        /// <returns>The API documentation HTML.</returns>
        public string GetApiDocumentation() {

            string template = HttpContext.Current.Application["ICUK_Template"].ToString();
            string content = HttpContext.Current.Application["ICUK_API_Doc"].ToString();
            string title = "<title>ICUK API - Main Module Documentation</title>";
            string css = @"<link href='../css/prettify.css' rel='stylesheet' media='screen'>
    <link href='../css/home/style.css' rel='stylesheet' media='screen'>";
            string js = @"<script src='../javascript/jquery-2.0.3.js'></script>
<script src='../javascript/bootstrap.js'></script>
<script>
	$('label.tree-toggler').click(function () {
		$(this).parent().children('ul.tree').toggle(300);
	});	
    $('.side-menu').find('a').not('.no-scroll').on('click', function (e) {
        e.preventDefault();   
        var id = $(this).attr('href');
        $('html,body').animate({ scrollTop: parseInt($(id).offset().top) - 80 }, 400);
        window.location.hash = $(this).attr('href');
    });
</script>";
                        
            template = template.Replace("<- title ->", title);
            template = template.Replace("<- css ->", css);
            template = template.Replace("<- js ->", js);
            template = template.Replace("<- content ->", content.ToString());
            template = template.Replace("<- module dropdown ->", ApiModule.GetModuleDropDown());
            template = template.Replace("<- module menu ->", ApiModule.GetModuleMenu());
            return template;

        }

        /// <summary>
        /// Constructs a template for documentation.
        /// </summary>
        /// <param name="moduleName">The module name.</param>
        /// <returns>The method documentation HTML.</returns>
        public string GetModuleDocumentation(string moduleName) {
            
            string template = HttpContext.Current.Application["ICUK_Template"].ToString();
            string title = "<title>ICUK API</title>";
            string css = @"<link href='//fonts.googleapis.com/css?family=Source+Code+Pro|Source+Sans+Pro:400,600,700' rel='stylesheet' type='text/css'>
    <link href='/css/prettify.css' rel='stylesheet' media='screen'>
    <link href='/css/docs/style.css' rel='stylesheet' media='screen'>
    <script>
        var userType = " + (int)ApiUserTypes.ICUK_CUSTOMER + @";
    </script>";
            string js = @"<script data-main='/javascript/api_doc.js' src='/javascript/require-jquery.js'></script>";
       
            StringBuilder html = new StringBuilder();

            // Side navigation menu.
            html.Append(@"
<script id='template-sidenav' type='text/x-handlebars-template'>
	<ul class='sidenav nav nav-list affix'>
	{{#each nav}}
		{{#if isHeader}}
			{{#if isFixed}}
				<li class='nav-fixed nav-header' data-group='{{group}}'><a href='#api-{{group}}'>{{title}}</a></li>
			{{else}}
				<li class='nav-header' data-group='{{group}}'><a href='#api-{{group}}'>{{title}}</a></li>
			{{/if}}
		{{else}}
			<li {{#if hidden}}class='hide' {{/if}}data-group='{{group}}' data-name='{{name}}' data-version='{{version}}'><a href='#api-{{group}}-{{name}}'>{{title}}</a></li>
		{{/if}}
	{{/each}}   
	</ul>
</script>");

            // Page heading, title and desciption.
            html.Append(@"
<script id='template-project' type='text/x-handlebars-template'>
	<div class='pull-left'>
		<h1>{{heading}}</h1>
		{{#if title}}<h2>{{{nl2br title}}}</h2>{{/if}}
		{{#if description}}<p>{{{nl2br description}}}</p>{{/if}}
	</div>
	<div class='clearfix'></div>
</script>");

            // Handlebars template.
            html.Append(@"
<script id='template-apidoc' type='text/x-handlebars-template'>
	{{#if apidoc}}
		<div id='api-_' class='apidoc'>{{{apidoc}}}</div>
	{{/if}}
</script>");

            html.Append(@"
<script id='template-generator' type='text/x-handlebars-template'>
	{{#if generator}}
		<a href='https://api.icuk.co.uk/'>ICUK</a> {{{generator.version}}} - {{{generator.time}}}
	{{/if}}
</script>");

            html.Append(@"
<script id='template-sections' type='text/x-handlebars-template'>
	<section id='api-{{group}}'>
		<h1>{{title}}</h1>
        <p>{{controller}}</p>
		{{#each articles}}
			<div id='api-{{group}}-{{name}}'>
				{{{article}}}
			</div>
		{{/each}}
	</section>
</script>");

            html.Append(@"
<script id='template-article' type='text/x-handlebars-template'>
    <article id='api-{{link}}-{{article.name}}' {{#if hidden}}class='hide'{{/if}} data-group='{{article.group}}' data-name='{{article.name}}' data-version='{{article.version}}' {{#if article.property}}style='padding-bottom:5px'{{/if}}>
        <div class='pull-left'>
			<h1>{{article.title}}</h1>
		</div>
		<div class='clearfix'></div>

		{{#if article.description}}
			<p>{{{nl2br article.description}}}</p>
		{{/if}}

        <!-- Remove method and url from template if article is a type. (Has property fields) -->
    	{{#unless article.property}}
           {{#unless article.member}}
		    <pre class='prettyprint language-html' data-type='{{toLowerCase article.type}}'><code>{{article.url}}</code></pre>
           {{/unless}}
        {{/unless}}

		{{#if article.permission.name}}
			<p>
				{{__ 'Permission:'}} 
				{{article.permission.name}}

				{{#if article.permission.description}}
					&nbsp;<a href='#' data-toggle='popover' data-placement='right' data-html='true' data-content='{{nl2br article.permission.description}}' title='' data-original-title='{{article.permission.title}}'><span class='label label-info'><i class='icon icon-info-sign icon-white'></i></span></a>
				{{/if}}
			</p>
		{{else}}
			{{#if article.permission}}
				<p>{{__ 'Permission:'}} {{article.permission}}</p>
			{{/if}}
		{{/if}}

		{{#each article.examples}}
			<strong>{{title}}</strong>
			<pre class='prettyprint language-json' data-type='json'><code>{{{content}}}</code></pre>
		{{/each}}

        <!-- Struct -->
       	{{#if article.property}}
		    {{subTemplate 'article-param-block' params=article.property _title='Type' _hasType=_hasTypeInParameterFields}}

        {{else}}
            <!-- Enum -->
        	{{#if article.member}}
                {{subTemplate 'article-param-block' params=article.member _title='Enum' _hasValue=_hasTypeInMemberFields}}
            {{else}}
                {{subTemplate 'article-param-block' params=article.parameter _title='Parameter' _hasType=_hasTypeInParameterFields}}
		        {{subTemplate 'article-param-block' params=article.success _title='Success (200)' _hasType=_hasTypeInSuccessFields}}
		        {{subTemplate 'article-param-block' params=article.error _title='Error (4xx)' _col1='Type' _hasType=_hasTypeInErrorFields}}
       	    {{/if}}
        {{/if}}
    </article>
</script>");

            // Parameters block.
            html.Append(@"
<script id='template-article-param-block' type='text/x-handlebars-template'>
    {{#if params}}
		<h2>{{__ _title}}</h2>
		{{#if params.fields}}
			<table class='parameter-block'>
				<thead>
					<tr>
						<th style='width: 30%'>{{#if _col1}}{{__ _col1}}{{else}}{{__ 'Field'}}{{/if}}</th>
						{{#if _hasType}}<th style='width: 10%'>{{__ 'Type'}}</th>{{/if}}
						{{#if _hasValue}}<th style='width: 10%'>{{__ 'Value'}}</th>{{/if}}
						<th style='width: {{#if _hasType}}60%{{else}}70%{{/if}}'>{{__ 'Description'}}</th>
					</tr>
				</thead>
				<tbody>
			{{#each params.fields}}
					<tr>
						<td class='code'>{{{splitFill field '.' '&nbsp;&nbsp;'}}}{{#if optional}} <span class='label label-optional'>{{__ 'optional'}}</span>{{/if}}</td>
						{{#if ../../_hasType}}<td>{{{type}}}</td>{{/if}}
						{{#if ../../_hasValue}}<td>{{{value}}}</td>{{/if}}
						<td>{{{nl2br description}}}</td>
					</tr>
			{{/each}}
				</tbody>
			</table>
		{{else}}
			<p>{{__ 'No response values.'}}</p>
		{{/if}}

		{{#each params.examples}}
			<strong>{{title}}</strong>
			<pre class='prettyprint language-json' data-type='json'><code>{{{content}}}</code></pre>
		{{/each}}
	{{/if}}
</script>");

            html.Append(@"
<div id='border'></div>
<div class='container-fluid'>
	<div class='row-fluid'>
		<div class='span2'>
			<div id='sidenav'></div>
		</div>
		<div id='content'>
			<div id='project'></div>
			<div id='sections'></div>
			<div id='apidoc'></div>
            <div id='generator' style='padding-top:500px'></div>
		</div>
	</div>
</div>");

            StringBuilder script = new StringBuilder();
            script.Append(@"<script>");

            // Construct module summary.
            script.Append(@"
var page_doc =");

            // Get module information.
            List<ApiModule> modules = ApiModule.GetApiModules();
            foreach (ApiModule module in modules)
            {
                if (module.Name.Equals(moduleName))
                {
                    XmlPageComment moduleComment = new XmlPageComment()
                    {
                        Heading = "ICUK API",
                        Title =  "API.Controllers." + module.Name,
                        Description = module.Description,
                        Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                        Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                    script.Append(moduleComment.ToJson());
                }

            }           
            
            // Construct controller method documentation.
            script.Append(@"
var controller_doc =");

            Dictionary<string, string> moduleDoc = (Dictionary<string, string>)HttpContext.Current.Application["API_Modules_JSON"];

            string docs = moduleDoc[moduleName];
            script.Append(docs);
                        
            script.Append(@"</script>");

            html.Append(script);
            
            template = template.Replace("<- title ->", title);
            template = template.Replace("<- css ->", css);
            template = template.Replace("<- js ->", js);
            template = template.Replace("<- content ->", html.ToString());
            template = template.Replace("<- module dropdown ->", ApiModule.GetModuleDropDown());
            return template;
        }

    }
}