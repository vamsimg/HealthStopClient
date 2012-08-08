﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.269.
// 
#pragma warning disable 1591

namespace HealthStopClient.com.healthstop {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="POSWebServiceSoap", Namespace="http://healthstop.com.au/")]
    public partial class POSWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback TestConnectionOperationCompleted;
        
        private System.Threading.SendOrPostCallback UploadPurchaseOrdersOperationCompleted;
        
        private System.Threading.SendOrPostCallback DownloadInvoicesOperationCompleted;
        
        private System.Threading.SendOrPostCallback MarkInvoiceAsDownloadedOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public POSWebService() {
            this.Url = global::HealthStopClient.Properties.Settings.Default.HealthStopClient_com_healthstop_POSWebService;
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
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event TestConnectionCompletedEventHandler TestConnectionCompleted;
        
        /// <remarks/>
        public event UploadPurchaseOrdersCompletedEventHandler UploadPurchaseOrdersCompleted;
        
        /// <remarks/>
        public event DownloadInvoicesCompletedEventHandler DownloadInvoicesCompleted;
        
        /// <remarks/>
        public event MarkInvoiceAsDownloadedCompletedEventHandler MarkInvoiceAsDownloadedCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://healthstop.com.au/HelloWorld", RequestNamespace="http://healthstop.com.au/", ResponseNamespace="http://healthstop.com.au/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://healthstop.com.au/TestConnection", RequestNamespace="http://healthstop.com.au/", ResponseNamespace="http://healthstop.com.au/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public OrderResponse TestConnection(int companyID, string password) {
            object[] results = this.Invoke("TestConnection", new object[] {
                        companyID,
                        password});
            return ((OrderResponse)(results[0]));
        }
        
        /// <remarks/>
        public void TestConnectionAsync(int companyID, string password) {
            this.TestConnectionAsync(companyID, password, null);
        }
        
        /// <remarks/>
        public void TestConnectionAsync(int companyID, string password, object userState) {
            if ((this.TestConnectionOperationCompleted == null)) {
                this.TestConnectionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTestConnectionOperationCompleted);
            }
            this.InvokeAsync("TestConnection", new object[] {
                        companyID,
                        password}, this.TestConnectionOperationCompleted, userState);
        }
        
        private void OnTestConnectionOperationCompleted(object arg) {
            if ((this.TestConnectionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TestConnectionCompleted(this, new TestConnectionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://healthstop.com.au/UploadPurchaseOrders", RequestNamespace="http://healthstop.com.au/", ResponseNamespace="http://healthstop.com.au/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public OrderResponse UploadPurchaseOrders(int companyID, string password, LocalPurchaseOrder[] orders) {
            object[] results = this.Invoke("UploadPurchaseOrders", new object[] {
                        companyID,
                        password,
                        orders});
            return ((OrderResponse)(results[0]));
        }
        
        /// <remarks/>
        public void UploadPurchaseOrdersAsync(int companyID, string password, LocalPurchaseOrder[] orders) {
            this.UploadPurchaseOrdersAsync(companyID, password, orders, null);
        }
        
        /// <remarks/>
        public void UploadPurchaseOrdersAsync(int companyID, string password, LocalPurchaseOrder[] orders, object userState) {
            if ((this.UploadPurchaseOrdersOperationCompleted == null)) {
                this.UploadPurchaseOrdersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUploadPurchaseOrdersOperationCompleted);
            }
            this.InvokeAsync("UploadPurchaseOrders", new object[] {
                        companyID,
                        password,
                        orders}, this.UploadPurchaseOrdersOperationCompleted, userState);
        }
        
        private void OnUploadPurchaseOrdersOperationCompleted(object arg) {
            if ((this.UploadPurchaseOrdersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UploadPurchaseOrdersCompleted(this, new UploadPurchaseOrdersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://healthstop.com.au/DownloadInvoices", RequestNamespace="http://healthstop.com.au/", ResponseNamespace="http://healthstop.com.au/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public OrderResponse DownloadInvoices(int companyID, string password) {
            object[] results = this.Invoke("DownloadInvoices", new object[] {
                        companyID,
                        password});
            return ((OrderResponse)(results[0]));
        }
        
        /// <remarks/>
        public void DownloadInvoicesAsync(int companyID, string password) {
            this.DownloadInvoicesAsync(companyID, password, null);
        }
        
        /// <remarks/>
        public void DownloadInvoicesAsync(int companyID, string password, object userState) {
            if ((this.DownloadInvoicesOperationCompleted == null)) {
                this.DownloadInvoicesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDownloadInvoicesOperationCompleted);
            }
            this.InvokeAsync("DownloadInvoices", new object[] {
                        companyID,
                        password}, this.DownloadInvoicesOperationCompleted, userState);
        }
        
        private void OnDownloadInvoicesOperationCompleted(object arg) {
            if ((this.DownloadInvoicesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DownloadInvoicesCompleted(this, new DownloadInvoicesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://healthstop.com.au/MarkInvoiceAsDownloaded", RequestNamespace="http://healthstop.com.au/", ResponseNamespace="http://healthstop.com.au/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public OrderResponse MarkInvoiceAsDownloaded(int companyID, string password, int invoiceID) {
            object[] results = this.Invoke("MarkInvoiceAsDownloaded", new object[] {
                        companyID,
                        password,
                        invoiceID});
            return ((OrderResponse)(results[0]));
        }
        
        /// <remarks/>
        public void MarkInvoiceAsDownloadedAsync(int companyID, string password, int invoiceID) {
            this.MarkInvoiceAsDownloadedAsync(companyID, password, invoiceID, null);
        }
        
        /// <remarks/>
        public void MarkInvoiceAsDownloadedAsync(int companyID, string password, int invoiceID, object userState) {
            if ((this.MarkInvoiceAsDownloadedOperationCompleted == null)) {
                this.MarkInvoiceAsDownloadedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMarkInvoiceAsDownloadedOperationCompleted);
            }
            this.InvokeAsync("MarkInvoiceAsDownloaded", new object[] {
                        companyID,
                        password,
                        invoiceID}, this.MarkInvoiceAsDownloadedOperationCompleted, userState);
        }
        
        private void OnMarkInvoiceAsDownloadedOperationCompleted(object arg) {
            if ((this.MarkInvoiceAsDownloadedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MarkInvoiceAsDownloadedCompleted(this, new MarkInvoiceAsDownloadedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://healthstop.com.au/")]
    public partial class OrderResponse {
        
        private bool is_errorField;
        
        private string errorMessageField;
        
        private string statusMessageField;
        
        private LocalPurchaseOrder[] localPurchaseOrdersField;
        
        private LocalInvoice[] localInvoicesField;
        
        /// <remarks/>
        public bool is_error {
            get {
                return this.is_errorField;
            }
            set {
                this.is_errorField = value;
            }
        }
        
        /// <remarks/>
        public string errorMessage {
            get {
                return this.errorMessageField;
            }
            set {
                this.errorMessageField = value;
            }
        }
        
        /// <remarks/>
        public string statusMessage {
            get {
                return this.statusMessageField;
            }
            set {
                this.statusMessageField = value;
            }
        }
        
        /// <remarks/>
        public LocalPurchaseOrder[] localPurchaseOrders {
            get {
                return this.localPurchaseOrdersField;
            }
            set {
                this.localPurchaseOrdersField = value;
            }
        }
        
        /// <remarks/>
        public LocalInvoice[] localInvoices {
            get {
                return this.localInvoicesField;
            }
            set {
                this.localInvoicesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://healthstop.com.au/")]
    public partial class LocalPurchaseOrder {
        
        private string local_codeField;
        
        private int supplier_idField;
        
        private System.DateTime order_datetimeField;
        
        private System.DateTime due_datetimeField;
        
        private LocalPurchaseOrderItem[] itemListField;
        
        /// <remarks/>
        public string local_code {
            get {
                return this.local_codeField;
            }
            set {
                this.local_codeField = value;
            }
        }
        
        /// <remarks/>
        public int supplier_id {
            get {
                return this.supplier_idField;
            }
            set {
                this.supplier_idField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime order_datetime {
            get {
                return this.order_datetimeField;
            }
            set {
                this.order_datetimeField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime due_datetime {
            get {
                return this.due_datetimeField;
            }
            set {
                this.due_datetimeField = value;
            }
        }
        
        /// <remarks/>
        public LocalPurchaseOrderItem[] itemList {
            get {
                return this.itemListField;
            }
            set {
                this.itemListField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://healthstop.com.au/")]
    public partial class LocalPurchaseOrderItem {
        
        private string barcodeField;
        
        private double quantityField;
        
        /// <remarks/>
        public string barcode {
            get {
                return this.barcodeField;
            }
            set {
                this.barcodeField = value;
            }
        }
        
        /// <remarks/>
        public double quantity {
            get {
                return this.quantityField;
            }
            set {
                this.quantityField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://healthstop.com.au/")]
    public partial class LocalInvoiceItem {
        
        private string barcodeField;
        
        private double quantityField;
        
        private decimal cost_exField;
        
        private decimal rRPField;
        
        private bool isGSTField;
        
        private string descriptionField;
        
        /// <remarks/>
        public string barcode {
            get {
                return this.barcodeField;
            }
            set {
                this.barcodeField = value;
            }
        }
        
        /// <remarks/>
        public double quantity {
            get {
                return this.quantityField;
            }
            set {
                this.quantityField = value;
            }
        }
        
        /// <remarks/>
        public decimal cost_ex {
            get {
                return this.cost_exField;
            }
            set {
                this.cost_exField = value;
            }
        }
        
        /// <remarks/>
        public decimal RRP {
            get {
                return this.rRPField;
            }
            set {
                this.rRPField = value;
            }
        }
        
        /// <remarks/>
        public bool isGST {
            get {
                return this.isGSTField;
            }
            set {
                this.isGSTField = value;
            }
        }
        
        /// <remarks/>
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://healthstop.com.au/")]
    public partial class LocalInvoice {
        
        private int invoice_idField;
        
        private string supplier_codeField;
        
        private int supplierIDField;
        
        private string supplierNameField;
        
        private string purchaseorder_codeField;
        
        private decimal freight_incField;
        
        private decimal taxField;
        
        private decimal total_incField;
        
        private System.DateTime creation_datetimeField;
        
        private LocalInvoiceItem[] itemListField;
        
        /// <remarks/>
        public int invoice_id {
            get {
                return this.invoice_idField;
            }
            set {
                this.invoice_idField = value;
            }
        }
        
        /// <remarks/>
        public string supplier_code {
            get {
                return this.supplier_codeField;
            }
            set {
                this.supplier_codeField = value;
            }
        }
        
        /// <remarks/>
        public int supplierID {
            get {
                return this.supplierIDField;
            }
            set {
                this.supplierIDField = value;
            }
        }
        
        /// <remarks/>
        public string supplierName {
            get {
                return this.supplierNameField;
            }
            set {
                this.supplierNameField = value;
            }
        }
        
        /// <remarks/>
        public string purchaseorder_code {
            get {
                return this.purchaseorder_codeField;
            }
            set {
                this.purchaseorder_codeField = value;
            }
        }
        
        /// <remarks/>
        public decimal freight_inc {
            get {
                return this.freight_incField;
            }
            set {
                this.freight_incField = value;
            }
        }
        
        /// <remarks/>
        public decimal tax {
            get {
                return this.taxField;
            }
            set {
                this.taxField = value;
            }
        }
        
        /// <remarks/>
        public decimal total_inc {
            get {
                return this.total_incField;
            }
            set {
                this.total_incField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime creation_datetime {
            get {
                return this.creation_datetimeField;
            }
            set {
                this.creation_datetimeField = value;
            }
        }
        
        /// <remarks/>
        public LocalInvoiceItem[] itemList {
            get {
                return this.itemListField;
            }
            set {
                this.itemListField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void TestConnectionCompletedEventHandler(object sender, TestConnectionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TestConnectionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TestConnectionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public OrderResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((OrderResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void UploadPurchaseOrdersCompletedEventHandler(object sender, UploadPurchaseOrdersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UploadPurchaseOrdersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UploadPurchaseOrdersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public OrderResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((OrderResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void DownloadInvoicesCompletedEventHandler(object sender, DownloadInvoicesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DownloadInvoicesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DownloadInvoicesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public OrderResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((OrderResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void MarkInvoiceAsDownloadedCompletedEventHandler(object sender, MarkInvoiceAsDownloadedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MarkInvoiceAsDownloadedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MarkInvoiceAsDownloadedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public OrderResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((OrderResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591