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
    
    #line 1 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class NonQueryVBADOTemplate : NonQueryVBADOTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            this.Write("\r\n");
            this.Write("\r\n\t\'\'Public Function cn");
            
            #line 15 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(procedureName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 15 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(String.Join(", ", dictionaryParameters.Select(kvp => $"{kvp.Key.Substring(4)} As {kvp.Value.Item3}").ToList())));
            
            #line default
            #line hidden
            this.Write(") As Integer\r\n\tPublic Function cn");
            
            #line 16 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(procedureName));
            
            #line default
            #line hidden
            this.Write("(ByVal entity As Model) As Integer\r\n\t\t\'\'Return _objDatos.cd");
            
            #line 17 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(procedureName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 17 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(String.Join(", ", dictionaryParameters.Select(kvp => kvp.Key.Substring(4)).ToList())));
            
            #line default
            #line hidden
            this.Write(")\r\n\t\tReturn _objDatos.cd");
            
            #line 18 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(procedureName));
            
            #line default
            #line hidden
            this.Write("(entity)\r\n\tEnd Function\r\n\r\n\t\'\'Public Function cd");
            
            #line 21 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(procedureName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 21 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(String.Join(", ", dictionaryParameters.Select(kvp => $"{kvp.Key.Substring(4)} As {kvp.Value.Item3}").ToList())));
            
            #line default
            #line hidden
            this.Write(") As Integer\r\n\tPublic Function cd");
            
            #line 22 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(procedureName));
            
            #line default
            #line hidden
            this.Write("(ByVal entity As Model) As Integer\r\n\t\tReDim campoParam(");
            
            #line 23 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(dictionaryParameters.Count() - 1));
            
            #line default
            #line hidden
            this.Write(")\r\n\t\tlistParam.Clear()\r\n\t\t\r\n");
            
            #line 26 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"

int iIndex = 0;
foreach(var item in dictionaryParameters)
{
	if(item.Value.Item2)
	{
		

            
            #line default
            #line hidden
            this.Write("\t\t\'Does not exists output parameters\r\n");
            
            #line 35 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"

	}
	else
	{

            
            #line default
            #line hidden
            this.Write("\t\tcampoParam(");
            
            #line 40 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(iIndex++));
            
            #line default
            #line hidden
            this.Write(") = New SqlParameter(\"");
            
            #line 40 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Key));
            
            #line default
            #line hidden
            this.Write("\", If(Not CType(entity.");
            
            #line 40 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Key.Substring(4)));
            
            #line default
            #line hidden
            this.Write(", Object) Is Nothing, CType(entity.");
            
            #line 40 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Key.Substring(4)));
            
            #line default
            #line hidden
            this.Write(", Object), DBNull.Value))\r\n");
            
            #line 41 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"

	}
}

            
            #line default
            #line hidden
            this.Write("\t\tFor Each iParam In campoParam\r\n            listParam.Add(iParam)\r\n        Next\r" +
                    "\n\r\n        Return _objConexion.pEjecutarOperacionSP_ResultadoEjecucion(\"");
            
            #line 49 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(procedureName));
            
            #line default
            #line hidden
            this.Write("\", listParam)\r\n\tEnd Function\r\n\r\n\r\n\tPublic Class Model\r\n");
            
            #line 54 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"

foreach(var item in dictionaryParameters)
{

            
            #line default
            #line hidden
            this.Write("\t\tProperty ");
            
            #line 58 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Key.Substring(4)));
            
            #line default
            #line hidden
            this.Write(" As ");
            
            #line 58 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Value.Item3));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 59 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"

}

            
            #line default
            #line hidden
            this.Write("\tEnd Class\r\n\r\n");
            
            #line 64 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
 foreach(var item in dictionaryParameters) { 
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 64 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Key.Substring(4)));
            
            #line default
            #line hidden
            this.Write(" As ");
            
            #line 64 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Value.Item3));
            
            #line default
            #line hidden
            this.Write(",  ");
            
            #line 64 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
 } 
            
            #line default
            #line hidden
            
            #line 65 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(String.Join(", ", dictionaryParameters.Select(kvp => kvp.Key.Substring(3)).ToList())));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 66 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(String.Join(", ", dictionaryParameters.Select(kvp => $"{kvp.Key.Substring(4)} As {kvp.Value.Item3}").ToList())));
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\Development\Neo\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\AdoTemplateGenerator\Templates\NonQueryVBADOTemplate.tt"

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
    public class NonQueryVBADOTemplateBase
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
