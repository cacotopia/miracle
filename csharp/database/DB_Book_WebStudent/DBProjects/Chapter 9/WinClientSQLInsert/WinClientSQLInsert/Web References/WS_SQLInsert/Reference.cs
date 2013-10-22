﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.1433.
// 
#pragma warning disable 1591

namespace WinClientSQLInsert.WS_SQLInsert {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WebServiceSQLInsertSoap", Namespace="http://www.ieee.org/9780521712354/")]
    public partial class WebServiceSQLInsert : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SetSQLInsertSPOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetSQLInsertOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetSQLInsertCourseOperationCompleted;
        
        private System.Threading.SendOrPostCallback SQLInsertDataSetOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebServiceSQLInsert() {
            this.Url = global::WinClientSQLInsert.Properties.Settings.Default.WinClientSQLInsert_WS_SQLInsert_WebServiceSQLInsert;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event SetSQLInsertSPCompletedEventHandler SetSQLInsertSPCompleted;
        
        /// <remarks/>
        public event GetSQLInsertCompletedEventHandler GetSQLInsertCompleted;
        
        /// <remarks/>
        public event GetSQLInsertCourseCompletedEventHandler GetSQLInsertCourseCompleted;
        
        /// <remarks/>
        public event SQLInsertDataSetCompletedEventHandler SQLInsertDataSetCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.ieee.org/9780521712354/SetSQLInsertSP", RequestNamespace="http://www.ieee.org/9780521712354/", ResponseNamespace="http://www.ieee.org/9780521712354/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public SQLInsertBase SetSQLInsertSP(string FacultyName, string CourseID, string Course, string Schedule, string Classroom, int Credit, int Enroll) {
            object[] results = this.Invoke("SetSQLInsertSP", new object[] {
                        FacultyName,
                        CourseID,
                        Course,
                        Schedule,
                        Classroom,
                        Credit,
                        Enroll});
            return ((SQLInsertBase)(results[0]));
        }
        
        /// <remarks/>
        public void SetSQLInsertSPAsync(string FacultyName, string CourseID, string Course, string Schedule, string Classroom, int Credit, int Enroll) {
            this.SetSQLInsertSPAsync(FacultyName, CourseID, Course, Schedule, Classroom, Credit, Enroll, null);
        }
        
        /// <remarks/>
        public void SetSQLInsertSPAsync(string FacultyName, string CourseID, string Course, string Schedule, string Classroom, int Credit, int Enroll, object userState) {
            if ((this.SetSQLInsertSPOperationCompleted == null)) {
                this.SetSQLInsertSPOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetSQLInsertSPOperationCompleted);
            }
            this.InvokeAsync("SetSQLInsertSP", new object[] {
                        FacultyName,
                        CourseID,
                        Course,
                        Schedule,
                        Classroom,
                        Credit,
                        Enroll}, this.SetSQLInsertSPOperationCompleted, userState);
        }
        
        private void OnSetSQLInsertSPOperationCompleted(object arg) {
            if ((this.SetSQLInsertSPCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetSQLInsertSPCompleted(this, new SetSQLInsertSPCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.ieee.org/9780521712354/GetSQLInsert", RequestNamespace="http://www.ieee.org/9780521712354/", ResponseNamespace="http://www.ieee.org/9780521712354/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public SQLInsertBase GetSQLInsert(string FacultyName) {
            object[] results = this.Invoke("GetSQLInsert", new object[] {
                        FacultyName});
            return ((SQLInsertBase)(results[0]));
        }
        
        /// <remarks/>
        public void GetSQLInsertAsync(string FacultyName) {
            this.GetSQLInsertAsync(FacultyName, null);
        }
        
        /// <remarks/>
        public void GetSQLInsertAsync(string FacultyName, object userState) {
            if ((this.GetSQLInsertOperationCompleted == null)) {
                this.GetSQLInsertOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSQLInsertOperationCompleted);
            }
            this.InvokeAsync("GetSQLInsert", new object[] {
                        FacultyName}, this.GetSQLInsertOperationCompleted, userState);
        }
        
        private void OnGetSQLInsertOperationCompleted(object arg) {
            if ((this.GetSQLInsertCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSQLInsertCompleted(this, new GetSQLInsertCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.ieee.org/9780521712354/GetSQLInsertCourse", RequestNamespace="http://www.ieee.org/9780521712354/", ResponseNamespace="http://www.ieee.org/9780521712354/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public SQLInsertBase GetSQLInsertCourse(string CourseID) {
            object[] results = this.Invoke("GetSQLInsertCourse", new object[] {
                        CourseID});
            return ((SQLInsertBase)(results[0]));
        }
        
        /// <remarks/>
        public void GetSQLInsertCourseAsync(string CourseID) {
            this.GetSQLInsertCourseAsync(CourseID, null);
        }
        
        /// <remarks/>
        public void GetSQLInsertCourseAsync(string CourseID, object userState) {
            if ((this.GetSQLInsertCourseOperationCompleted == null)) {
                this.GetSQLInsertCourseOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSQLInsertCourseOperationCompleted);
            }
            this.InvokeAsync("GetSQLInsertCourse", new object[] {
                        CourseID}, this.GetSQLInsertCourseOperationCompleted, userState);
        }
        
        private void OnGetSQLInsertCourseOperationCompleted(object arg) {
            if ((this.GetSQLInsertCourseCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSQLInsertCourseCompleted(this, new GetSQLInsertCourseCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.ieee.org/9780521712354/SQLInsertDataSet", RequestNamespace="http://www.ieee.org/9780521712354/", ResponseNamespace="http://www.ieee.org/9780521712354/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet SQLInsertDataSet(string FacultyName, string CourseID, string Course, string Schedule, string Classroom, int Credit, int Enroll) {
            object[] results = this.Invoke("SQLInsertDataSet", new object[] {
                        FacultyName,
                        CourseID,
                        Course,
                        Schedule,
                        Classroom,
                        Credit,
                        Enroll});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void SQLInsertDataSetAsync(string FacultyName, string CourseID, string Course, string Schedule, string Classroom, int Credit, int Enroll) {
            this.SQLInsertDataSetAsync(FacultyName, CourseID, Course, Schedule, Classroom, Credit, Enroll, null);
        }
        
        /// <remarks/>
        public void SQLInsertDataSetAsync(string FacultyName, string CourseID, string Course, string Schedule, string Classroom, int Credit, int Enroll, object userState) {
            if ((this.SQLInsertDataSetOperationCompleted == null)) {
                this.SQLInsertDataSetOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSQLInsertDataSetOperationCompleted);
            }
            this.InvokeAsync("SQLInsertDataSet", new object[] {
                        FacultyName,
                        CourseID,
                        Course,
                        Schedule,
                        Classroom,
                        Credit,
                        Enroll}, this.SQLInsertDataSetOperationCompleted, userState);
        }
        
        private void OnSQLInsertDataSetOperationCompleted(object arg) {
            if ((this.SQLInsertDataSetCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SQLInsertDataSetCompleted(this, new SQLInsertDataSetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.1433")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.ieee.org/9780521712354/")]
    public partial class SQLInsertBase {
        
        private bool sQLInsertOKField;
        
        private string sQLInsertErrorField;
        
        private string facultyIDField;
        
        private string[] courseIDField;
        
        private string courseField;
        
        private string scheduleField;
        
        private string classroomField;
        
        private int creditField;
        
        private int enrollmentField;
        
        /// <remarks/>
        public bool SQLInsertOK {
            get {
                return this.sQLInsertOKField;
            }
            set {
                this.sQLInsertOKField = value;
            }
        }
        
        /// <remarks/>
        public string SQLInsertError {
            get {
                return this.sQLInsertErrorField;
            }
            set {
                this.sQLInsertErrorField = value;
            }
        }
        
        /// <remarks/>
        public string FacultyID {
            get {
                return this.facultyIDField;
            }
            set {
                this.facultyIDField = value;
            }
        }
        
        /// <remarks/>
        public string[] CourseID {
            get {
                return this.courseIDField;
            }
            set {
                this.courseIDField = value;
            }
        }
        
        /// <remarks/>
        public string Course {
            get {
                return this.courseField;
            }
            set {
                this.courseField = value;
            }
        }
        
        /// <remarks/>
        public string Schedule {
            get {
                return this.scheduleField;
            }
            set {
                this.scheduleField = value;
            }
        }
        
        /// <remarks/>
        public string Classroom {
            get {
                return this.classroomField;
            }
            set {
                this.classroomField = value;
            }
        }
        
        /// <remarks/>
        public int Credit {
            get {
                return this.creditField;
            }
            set {
                this.creditField = value;
            }
        }
        
        /// <remarks/>
        public int Enrollment {
            get {
                return this.enrollmentField;
            }
            set {
                this.enrollmentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void SetSQLInsertSPCompletedEventHandler(object sender, SetSQLInsertSPCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SetSQLInsertSPCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SetSQLInsertSPCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public SQLInsertBase Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((SQLInsertBase)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void GetSQLInsertCompletedEventHandler(object sender, GetSQLInsertCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSQLInsertCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSQLInsertCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public SQLInsertBase Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((SQLInsertBase)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void GetSQLInsertCourseCompletedEventHandler(object sender, GetSQLInsertCourseCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSQLInsertCourseCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSQLInsertCourseCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public SQLInsertBase Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((SQLInsertBase)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void SQLInsertDataSetCompletedEventHandler(object sender, SQLInsertDataSetCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SQLInsertDataSetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SQLInsertDataSetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591