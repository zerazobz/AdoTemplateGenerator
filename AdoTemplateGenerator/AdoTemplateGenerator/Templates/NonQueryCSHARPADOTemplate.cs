﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace AdoTemplateGenerator.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class NonQueryCSHARPADOTemplate : NonQueryCSHARPADOTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            this.Write("\r\n");
            this.Write("\r\n\tpublic int NonQuery");
            
            #line 15 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(procedureName));
            
            #line default
            #line hidden
            this.Write("(Model entity)\r\n\t{\r\n\t\tusing (SqlConnection connection = new SqlConnection(Configu" +
                    "rationManager.ConnectionStrings[\"");
            
            #line 17 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(connectionStringName));
            
            #line default
            #line hidden
            this.Write("\"].ConnectionString))\r\n        {\r\n            using (SqlCommand nonQueryCommand =" +
                    " new SqlCommand(\"");
            
            #line 19 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(procedureName));
            
            #line default
            #line hidden
            this.Write("\", connection))\r\n            {\r\n\t\t\t\tnonQueryCommand.CommandType = CommandType.Sto" +
                    "redProcedure;\r\n");
            
            #line 22 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"

foreach(var item in dictionaryParameters)
{
	if(item.Value.Item2)
	{

            
            #line default
            #line hidden
            this.Write("\t\t\t\tvar ");
            
            #line 28 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Key.Substring(4)));
            
            #line default
            #line hidden
            this.Write("output = new SqlParameter(\"");
            
            #line 28 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Key));
            
            #line default
            #line hidden
            this.Write("\", ");
            
            #line 28 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Value.Item1));
            
            #line default
            #line hidden
            this.Write(")\r\n                {\r\n                    Direction = ParameterDirection.Output\r\n" +
                    "                };\r\n\t\t\t\tnonQueryCommand.Parameters.Add(");
            
            #line 32 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Key.Substring(4)));
            
            #line default
            #line hidden
            this.Write("output);\r\n");
            
            #line 33 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"

	}
	else
	{

            
            #line default
            #line hidden
            this.Write("\t\t\t\tnonQueryCommand.Parameters.Add(\"");
            
            #line 38 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Key));
            
            #line default
            #line hidden
            this.Write("\", ");
            
            #line 38 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Value.Item1));
            
            #line default
            #line hidden
            this.Write(").Value = (object)entity.");
            
            #line 38 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Key.Substring(4)));
            
            #line default
            #line hidden
            this.Write(" ?? DBNull.Value;\r\n");
            
            #line 39 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"

	}
}

            
            #line default
            #line hidden
            this.Write("\t\t\t\tconnection.Open();\r\n\t\t\t\tvar resultNonQuery = nonQueryCommand.ExecuteNonQuery(" +
                    ");\r\n\t\t\t\treturn resultNonQuery;\r\n\t\t\t}\r\n\t\t}\r\n\t}\r\n\r\n\r\n\tpublic class Model\r\n\t{\r\n");
            
            #line 53 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"

foreach(var item in dictionaryParameters)
{

            
            #line default
            #line hidden
            this.Write("\t\tpublic ");
            
            #line 57 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Value.Item3));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 57 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Key.Substring(4)));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n");
            
            #line 58 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"

}

            
            #line default
            #line hidden
            this.Write("\t}");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryCSHARPADOTemplate.tt"

private string _procedureNameField;

/// <summary>
/// Access the procedureName parameter of the template.
/// </summary>
private string procedureName
{
    get
    {
        return this._procedureNameField;
    }
}

private string _connectionStringNameField;

/// <summary>
/// Access the connectionStringName parameter of the template.
/// </summary>
private string connectionStringName
{
    get
    {
        return this._connectionStringNameField;
    }
}

private global::System.Collections.Generic.Dictionary<string, System.Tuple<string, bool, string>> _dictionaryParametersField;

/// <summary>
/// Access the dictionaryParameters parameter of the template.
/// </summary>
private global::System.Collections.Generic.Dictionary<string, System.Tuple<string, bool, string>> dictionaryParameters
{
    get
    {
        return this._dictionaryParametersField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool procedureNameValueAcquired = false;
if (this.Session.ContainsKey("procedureName"))
{
    this._procedureNameField = ((string)(this.Session["procedureName"]));
    procedureNameValueAcquired = true;
}
if ((procedureNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("procedureName");
    if ((data != null))
    {
        this._procedureNameField = ((string)(data));
    }
}
bool connectionStringNameValueAcquired = false;
if (this.Session.ContainsKey("connectionStringName"))
{
    this._connectionStringNameField = ((string)(this.Session["connectionStringName"]));
    connectionStringNameValueAcquired = true;
}
if ((connectionStringNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("connectionStringName");
    if ((data != null))
    {
        this._connectionStringNameField = ((string)(data));
    }
}
bool dictionaryParametersValueAcquired = false;
if (this.Session.ContainsKey("dictionaryParameters"))
{
    this._dictionaryParametersField = ((global::System.Collections.Generic.Dictionary<string, System.Tuple<string, bool, string>>)(this.Session["dictionaryParameters"]));
    dictionaryParametersValueAcquired = true;
}
if ((dictionaryParametersValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("dictionaryParameters");
    if ((data != null))
    {
        this._dictionaryParametersField = ((global::System.Collections.Generic.Dictionary<string, System.Tuple<string, bool, string>>)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public class NonQueryCSHARPADOTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
