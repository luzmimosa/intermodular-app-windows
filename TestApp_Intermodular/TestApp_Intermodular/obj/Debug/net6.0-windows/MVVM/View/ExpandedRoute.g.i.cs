#pragma checksum "..\..\..\..\..\MVVM\View\ExpandedRoute.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F10D715ADFC77405CA86588E1C5A6BF8547239FC"
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
    /// ExpandedRoute
    /// </summary>
    public partial class ExpandedRoute : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\..\MVVM\View\ExpandedRoute.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image RouteImage;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\MVVM\View\ExpandedRoute.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RouteTitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\MVVM\View\ExpandedRoute.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RouteDifficultyTextBox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\MVVM\View\ExpandedRoute.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RouteDistanceTextBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\MVVM\View\ExpandedRoute.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RouteDescriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\MVVM\View\ExpandedRoute.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CommentsTextBlock;
        
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
            System.Uri resourceLocater = new System.Uri("/TestApp_Intermodular;V1.0.0.0;component/mvvm/view/expandedroute.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\View\ExpandedRoute.xaml"
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
            this.RouteImage = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            
            #line 25 "..\..\..\..\..\MVVM\View\ExpandedRoute.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PrevButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 26 "..\..\..\..\..\MVVM\View\ExpandedRoute.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NextButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RouteTitleTextBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.RouteDifficultyTextBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.RouteDistanceTextBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.RouteDescriptionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.CommentsTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

