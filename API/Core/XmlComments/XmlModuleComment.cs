using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Core.XmlComments {
   
    /// <summary>
    /// Stores deserialized module comments.
    /// </summary>
    public class XmlModuleComment 
    {
        /// <summary>
        /// Module methods.
        /// </summary>
        public List<XmlMethodComment> Methods { get; set; }
        /// <summary>
        /// Module types.
        /// </summary>
        public List<XmlTypeComment> Types { get; set; }
        /// <summary>
        /// Enum types.
        /// </summary>
        public List<XmlEnumComment> Enums { get; set; }

        /// <summary>
        /// XmlModuleComment.
        /// </summary>
        public XmlModuleComment() {
                
            Methods = new List<XmlMethodComment>();
            Types = new List<XmlTypeComment>();
            Enums = new List<XmlEnumComment>();

        }

        /// <summary>
        /// Deserializes module documentation JSON string into a XmlModuleComment object.
        /// </summary>
        /// <param name="json">Module documentation JSON string.</param>
        /// <returns>XmlModuleComment object.</returns>
        public static XmlModuleComment DeserializeJson(string json) {

            XmlModuleComment module = new XmlModuleComment();

            // Deserialize JSON into object
            dynamic moduleDoc;
            
            try {
                moduleDoc = JArray.Parse(json);
            }
            catch {
                return module;
            }
            
            // Loop through each item and add objects to module
            foreach (dynamic item in moduleDoc) {

                if (item.group != "Type" && item.group != "Enum") {

                    XmlMethodComment method = new XmlMethodComment() {
                        ControllerName = item.controller_name,
                        ControllerDescription = item.controller,
                        Description = item.description,
                        UrlParam = item.url_param,
                        Group = item.group,
                        Name = item.name,
                        Type = item.type,
                        Url = item.url
                    };

                    // Method parameters
                    try {
                        foreach (dynamic field in item.parameter.fields) {

                            if (method.Parameters == null)
                                method.Parameters = new List<XmlParameterComment>();

                            XmlParameterComment parameter = new XmlParameterComment() {
                                Type = field.type,
                                Field = field.field,
                                Optional = field.optional,
                                Description = field.description,
                                FromBody = field.frombody,
                                Day = field.day,
                                Time = field.time,
                                Date = field.date
                            };

                            method.Parameters.Add(parameter);

                        }
                    }
                    catch (RuntimeBinderException){}

                    // Method success fields
                    try {
                        foreach (dynamic field in item.success.fields) {

                            if (method.Success == null)
                                method.Success = new List<XmlSuccessComment>();

                            XmlSuccessComment success = new XmlSuccessComment() {
                                Description = field.description,
                                Field = field.field,
                                Optional = field.optional,
                                Type = field.type
                            };

                            method.Success.Add(success);

                        }
                    }
                    catch (RuntimeBinderException) { }


                    // Method example fields
                    try {
                        foreach (dynamic field in item.error.examples) {

                            if (method.Example == null)
                                method.Example = new List<XmlExampleComment>();

                            XmlExampleComment example = new XmlExampleComment() {
                                Title = field.title,
                                Content = field.content
                            };

                            method.Example.Add(example);
                        }
                    }
                    catch (RuntimeBinderException) { }

                    module.Methods.Add(method);
                }
                else if(item.group == "Type") {

                    XmlTypeComment type = new XmlTypeComment() {
                        Description = item.description,
                        Group = item.group,
                        Name = item.name
                    };

                    // Type property fields
                    try {
                        foreach (dynamic field in item.property.fields) {

                            if (type.Properties == null)
                                type.Properties = new List<XmlPropertyComment>();

                            XmlPropertyComment property = new XmlPropertyComment() {
                                Description = field.description,
                                Field = field.field,
                                Day = field.day,
                                Time = field.time,
                                Date = field.date,
                                ReadOnly = field.read_only,
                                Optional = field.optional,
                                Type = field.type
                            };

                            type.Properties.Add(property);

                        }
                    }
                    catch (RuntimeBinderException) { }

                    module.Types.Add(type);

                }
                else if (item.group == "Enum") {

                    XmlEnumComment type = new XmlEnumComment() {
                        Description = item.description,
                        Group = item.group,
                        Name = item.name
                    };

                    // Enum member
                    try {
                        foreach (dynamic field in item.member.fields) {

                            if (type.Members == null)
                                type.Members = new List<XmlMemberComment>();

                            XmlMemberComment member = new XmlMemberComment() {
                                Description = field.description,
                                Field = field.field,
                                Value = field.value,
                                Summary = field.summary
                            };

                            type.Members.Add(member);

                        }
                    }
                    catch (RuntimeBinderException) { }

                    module.Enums.Add(type);

                }

            }

            return module;
        }
    }
}