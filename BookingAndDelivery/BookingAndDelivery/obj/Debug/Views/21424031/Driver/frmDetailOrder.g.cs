﻿#pragma checksum "..\..\..\..\..\Views\21424031\Driver\frmDetailOrder.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5D25EAF7CCCADB97EF4B31C7CEBB44F704D02A21635634D73CD94D9D4CB6D654"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BookingAndDelivery.Views.Driver;
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


namespace BookingAndDelivery.Views.Driver {
    
    
    /// <summary>
    /// frmDetailOrder
    /// </summary>
    public partial class frmDetailOrder : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\..\Views\21424031\Driver\frmDetailOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtNameCus;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\Views\21424031\Driver\frmDetailOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtPhone;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Views\21424031\Driver\frmDetailOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtAddressCus;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\Views\21424031\Driver\frmDetailOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtAdOrder;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\Views\21424031\Driver\frmDetailOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirmFix;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\Views\21424031\Driver\frmDetailOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\Views\21424031\Driver\frmDetailOrder.xaml"
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
            System.Uri resourceLocater = new System.Uri("/BookingAndDelivery;component/views/21424031/driver/frmdetailorder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\21424031\Driver\frmDetailOrder.xaml"
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
            this.txtNameCus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.txtPhone = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txtAddressCus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txtAdOrder = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.btnConfirmFix = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\..\Views\21424031\Driver\frmDetailOrder.xaml"
            this.btnConfirmFix.Click += new System.Windows.RoutedEventHandler(this.btnConfirmFix_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\..\Views\21424031\Driver\frmDetailOrder.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.btnConfirm_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\..\Views\21424031\Driver\frmDetailOrder.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

