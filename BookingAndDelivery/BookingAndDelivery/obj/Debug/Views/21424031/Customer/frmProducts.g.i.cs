﻿#pragma checksum "..\..\..\..\..\Views\21424031\Customer\frmProducts.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BE13645EFBF12054CF7017EDB436247DBBB2B867B003FFA7C3FE39639288DF06"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BookingAndDelivery.Views.Customer;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace BookingAndDelivery.Views.Customer {
    
    
    /// <summary>
    /// frmProducts
    /// </summary>
    public partial class frmProducts : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\..\Views\21424031\Customer\frmProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtNamePn;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\Views\21424031\Customer\frmProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbBranch;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Views\21424031\Customer\frmProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtAddress;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\Views\21424031\Customer\frmProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvProducts;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\Views\21424031\Customer\frmProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTotal;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\..\Views\21424031\Customer\frmProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtStatus;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\Views\21424031\Customer\frmProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOrder;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\..\Views\21424031\Customer\frmProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BookingAndDelivery;component/views/21424031/customer/frmproducts.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\21424031\Customer\frmProducts.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtNamePn = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.cbBranch = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\..\..\..\Views\21424031\Customer\frmProducts.xaml"
            this.cbBranch.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbBranch_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtAddress = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.lvProducts = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.txtTotal = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.btnOrder = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\..\..\Views\21424031\Customer\frmProducts.xaml"
            this.btnOrder.Click += new System.Windows.RoutedEventHandler(this.btnOrder_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\..\..\Views\21424031\Customer\frmProducts.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
