// Updated by XamlIntelliSenseFileGenerator 7/13/2020 5:42:16 AM
#pragma checksum "..\..\..\MainApp\Customer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "83B92D0A23663EB857FFE7C691206B89B8AD780CBEF971CB2BE3C32ABBF0C9F2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ECommerce_GUI.MainApp;
using ECommerce_GUI.MainApp.Product;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace ECommerce_GUI.MainApp
{


    /// <summary>
    /// CustomerWindow
    /// </summary>
    public partial class CustomerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 27 "..\..\..\MainApp\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeBtn;

#line default
#line hidden


#line 37 "..\..\..\MainApp\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button username;

#line default
#line hidden


#line 48 "..\..\..\MainApp\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button notification;

#line default
#line hidden


#line 60 "..\..\..\MainApp\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button homePage;

#line default
#line hidden


#line 66 "..\..\..\MainApp\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button rechargeAccount;

#line default
#line hidden


#line 72 "..\..\..\MainApp\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sellerPage;

#line default
#line hidden


#line 92 "..\..\..\MainApp\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox searchBar;

#line default
#line hidden


#line 96 "..\..\..\MainApp\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button search;

#line default
#line hidden


#line 103 "..\..\..\MainApp\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cart;

#line default
#line hidden


#line 116 "..\..\..\MainApp\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ECommerce_GUI.MainApp.Product.ProductMain productMain;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ECommerce_GUI;component/mainapp/customer.xaml", System.UriKind.Relative);

#line 1 "..\..\..\MainApp\Customer.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 15 "..\..\..\MainApp\Customer.xaml"
                    ((ECommerce_GUI.MainApp.CustomerWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);

#line default
#line hidden
                    return;
                case 2:

#line 23 "..\..\..\MainApp\Customer.xaml"
                    ((System.Windows.Controls.StackPanel)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.tileBar_MouseLeftButtonDown);

#line default
#line hidden
                    return;
                case 3:
                    this.closeBtn = ((System.Windows.Controls.Button)(target));

#line 32 "..\..\..\MainApp\Customer.xaml"
                    this.closeBtn.Click += new System.Windows.RoutedEventHandler(this.closeBtn_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.username = ((System.Windows.Controls.Button)(target));
                    return;
                case 5:
                    this.notification = ((System.Windows.Controls.Button)(target));
                    return;
                case 6:
                    this.homePage = ((System.Windows.Controls.Button)(target));
                    return;
                case 7:
                    this.rechargeAccount = ((System.Windows.Controls.Button)(target));
                    return;
                case 8:
                    this.sellerPage = ((System.Windows.Controls.Button)(target));

#line 76 "..\..\..\MainApp\Customer.xaml"
                    this.sellerPage.Click += new System.Windows.RoutedEventHandler(this.sellerPage_Click);

#line default
#line hidden
                    return;
                case 9:
                    this.searchBar = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 10:
                    this.search = ((System.Windows.Controls.Button)(target));
                    return;
                case 11:
                    this.cart = ((System.Windows.Controls.Button)(target));
                    return;
                case 12:
                    this.controlGrid = ((System.Windows.Controls.Grid)(target));
                    return;
                case 13:
                    this.productMain = ((ECommerce_GUI.MainApp.Product.ProductMain)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        public System.Windows.Controls.Grid controlGrid;
        internal System.Windows.Controls.Button backPage;
    }
}

