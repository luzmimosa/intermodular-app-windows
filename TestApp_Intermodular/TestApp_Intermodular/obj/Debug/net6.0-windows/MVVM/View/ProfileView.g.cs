﻿#pragma checksum "..\..\..\..\..\MVVM\View\ProfileView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22E1DEB44AF3DBC97F01FEE9DAC3587D3273B203"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using TestApp_Intermodular.MVVM.View;


namespace TestApp_Intermodular.MVVM.View {
    
    
    /// <summary>
    /// ProfileView
    /// </summary>
    public partial class ProfileView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\..\MVVM\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Image;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\MVVM\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\MVVM\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NameTextBlock;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\MVVM\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTextBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\MVVM\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UserTextBlock;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\MVVM\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock BioTextBlock;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\MVVM\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock BioDescriptionTextBlock;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\..\MVVM\View\ProfileView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BiographyTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TestApp_Intermodular;component/mvvm/view/profileview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\View\ProfileView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Image = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            
            #line 24 "..\..\..\..\..\MVVM\View\ProfileView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ImageBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 25 "..\..\..\..\..\MVVM\View\ProfileView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ModifyProfile_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\..\MVVM\View\ProfileView.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.NameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.UserTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.BioTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.BioDescriptionTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.BiographyTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

