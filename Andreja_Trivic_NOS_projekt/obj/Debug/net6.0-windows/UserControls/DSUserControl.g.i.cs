﻿#pragma checksum "..\..\..\..\UserControls\DSUserControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CDD05FCD51248F7D4668B183C424B995713C6EA5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Andreja_Trivic_NOS_projekt.UserControls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Andreja_Trivic_NOS_projekt.UserControls {
    
    
    /// <summary>
    /// DSUserControl
    /// </summary>
    public partial class DSUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\UserControls\DSUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGeneratePublicAndPrivateKey;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\..\UserControls\DSUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUploadFile;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\UserControls\DSUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFileName;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\UserControls\DSUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFileText;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\UserControls\DSUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddSignature;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\UserControls\DSUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGeneratedSignature;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\UserControls\DSUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVerifySignature;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\UserControls\DSUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtError;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\UserControls\DSUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtSignatureValid;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\UserControls\DSUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGenerateHash;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\UserControls\DSUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtHash;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.13.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Andreja_Trivic_NOS_projekt;component/usercontrols/dsusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\DSUserControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.13.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnGeneratePublicAndPrivateKey = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\..\..\UserControls\DSUserControl.xaml"
            this.btnGeneratePublicAndPrivateKey.Click += new System.Windows.RoutedEventHandler(this.btnGeneratePublicAndPrivateKey_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnUploadFile = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\..\UserControls\DSUserControl.xaml"
            this.btnUploadFile.Click += new System.Windows.RoutedEventHandler(this.btnUploadFile_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtFileName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtFileText = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\..\..\UserControls\DSUserControl.xaml"
            this.txtFileText.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtFileText_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnAddSignature = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\UserControls\DSUserControl.xaml"
            this.btnAddSignature.Click += new System.Windows.RoutedEventHandler(this.btnAddSignature_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtGeneratedSignature = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\..\UserControls\DSUserControl.xaml"
            this.txtGeneratedSignature.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtGeneratedSignature_KeyUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnVerifySignature = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\UserControls\DSUserControl.xaml"
            this.btnVerifySignature.Click += new System.Windows.RoutedEventHandler(this.btnVerifySignature_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.txtSignatureValid = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.btnGenerateHash = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\UserControls\DSUserControl.xaml"
            this.btnGenerateHash.Click += new System.Windows.RoutedEventHandler(this.btnGenerateHash_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.txtHash = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

