﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace ApliwebAgenviaje.com.somee.agenciaviajeabjsanti {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="AgenciaViajeLAB_SCSJSoap", Namespace="http://tempuri.org/")]
    public partial class AgenciaViajeLAB_SCSJ : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ConsultarEmpleadoOperationCompleted;
        
        private System.Threading.SendOrPostCallback Consultar_ClientesOperationCompleted;
        
        private System.Threading.SendOrPostCallback Consultar_FacturaOperationCompleted;
        
        private System.Threading.SendOrPostCallback BIENVENIDOS_A_NUESTRO_WEB_SERVICEOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public AgenciaViajeLAB_SCSJ() {
            this.Url = global::ApliwebAgenviaje.Properties.Settings.Default.ApliwebAgenviaje_com_somee_agenciaviajeabjsanti_AgenciaViajeLAB_SCSJ;
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
        public event ConsultarEmpleadoCompletedEventHandler ConsultarEmpleadoCompleted;
        
        /// <remarks/>
        public event Consultar_ClientesCompletedEventHandler Consultar_ClientesCompleted;
        
        /// <remarks/>
        public event Consultar_FacturaCompletedEventHandler Consultar_FacturaCompleted;
        
        /// <remarks/>
        public event BIENVENIDOS_A_NUESTRO_WEB_SERVICECompletedEventHandler BIENVENIDOS_A_NUESTRO_WEB_SERVICECompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ConsultarEmpleado", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet ConsultarEmpleado() {
            object[] results = this.Invoke("ConsultarEmpleado", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void ConsultarEmpleadoAsync() {
            this.ConsultarEmpleadoAsync(null);
        }
        
        /// <remarks/>
        public void ConsultarEmpleadoAsync(object userState) {
            if ((this.ConsultarEmpleadoOperationCompleted == null)) {
                this.ConsultarEmpleadoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConsultarEmpleadoOperationCompleted);
            }
            this.InvokeAsync("ConsultarEmpleado", new object[0], this.ConsultarEmpleadoOperationCompleted, userState);
        }
        
        private void OnConsultarEmpleadoOperationCompleted(object arg) {
            if ((this.ConsultarEmpleadoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConsultarEmpleadoCompleted(this, new ConsultarEmpleadoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Consultar_Clientes", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet Consultar_Clientes(int cedula) {
            object[] results = this.Invoke("Consultar_Clientes", new object[] {
                        cedula});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void Consultar_ClientesAsync(int cedula) {
            this.Consultar_ClientesAsync(cedula, null);
        }
        
        /// <remarks/>
        public void Consultar_ClientesAsync(int cedula, object userState) {
            if ((this.Consultar_ClientesOperationCompleted == null)) {
                this.Consultar_ClientesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConsultar_ClientesOperationCompleted);
            }
            this.InvokeAsync("Consultar_Clientes", new object[] {
                        cedula}, this.Consultar_ClientesOperationCompleted, userState);
        }
        
        private void OnConsultar_ClientesOperationCompleted(object arg) {
            if ((this.Consultar_ClientesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Consultar_ClientesCompleted(this, new Consultar_ClientesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Consultar_Factura", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet Consultar_Factura(int cedula) {
            object[] results = this.Invoke("Consultar_Factura", new object[] {
                        cedula});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void Consultar_FacturaAsync(int cedula) {
            this.Consultar_FacturaAsync(cedula, null);
        }
        
        /// <remarks/>
        public void Consultar_FacturaAsync(int cedula, object userState) {
            if ((this.Consultar_FacturaOperationCompleted == null)) {
                this.Consultar_FacturaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConsultar_FacturaOperationCompleted);
            }
            this.InvokeAsync("Consultar_Factura", new object[] {
                        cedula}, this.Consultar_FacturaOperationCompleted, userState);
        }
        
        private void OnConsultar_FacturaOperationCompleted(object arg) {
            if ((this.Consultar_FacturaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Consultar_FacturaCompleted(this, new Consultar_FacturaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/BIENVENIDOS_A_NUESTRO_WEB_SERVICE", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string BIENVENIDOS_A_NUESTRO_WEB_SERVICE() {
            object[] results = this.Invoke("BIENVENIDOS_A_NUESTRO_WEB_SERVICE", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void BIENVENIDOS_A_NUESTRO_WEB_SERVICEAsync() {
            this.BIENVENIDOS_A_NUESTRO_WEB_SERVICEAsync(null);
        }
        
        /// <remarks/>
        public void BIENVENIDOS_A_NUESTRO_WEB_SERVICEAsync(object userState) {
            if ((this.BIENVENIDOS_A_NUESTRO_WEB_SERVICEOperationCompleted == null)) {
                this.BIENVENIDOS_A_NUESTRO_WEB_SERVICEOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBIENVENIDOS_A_NUESTRO_WEB_SERVICEOperationCompleted);
            }
            this.InvokeAsync("BIENVENIDOS_A_NUESTRO_WEB_SERVICE", new object[0], this.BIENVENIDOS_A_NUESTRO_WEB_SERVICEOperationCompleted, userState);
        }
        
        private void OnBIENVENIDOS_A_NUESTRO_WEB_SERVICEOperationCompleted(object arg) {
            if ((this.BIENVENIDOS_A_NUESTRO_WEB_SERVICECompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BIENVENIDOS_A_NUESTRO_WEB_SERVICECompleted(this, new BIENVENIDOS_A_NUESTRO_WEB_SERVICECompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    public delegate void ConsultarEmpleadoCompletedEventHandler(object sender, ConsultarEmpleadoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConsultarEmpleadoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConsultarEmpleadoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    public delegate void Consultar_ClientesCompletedEventHandler(object sender, Consultar_ClientesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Consultar_ClientesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Consultar_ClientesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    public delegate void Consultar_FacturaCompletedEventHandler(object sender, Consultar_FacturaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Consultar_FacturaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Consultar_FacturaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    public delegate void BIENVENIDOS_A_NUESTRO_WEB_SERVICECompletedEventHandler(object sender, BIENVENIDOS_A_NUESTRO_WEB_SERVICECompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BIENVENIDOS_A_NUESTRO_WEB_SERVICECompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal BIENVENIDOS_A_NUESTRO_WEB_SERVICECompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591