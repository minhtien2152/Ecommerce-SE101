﻿#pragma checksum "..\..\..\..\MainApp\Cart\DisplayCart.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6669B41982F1F3B6CCB102E02CC42E06B936514C5357435AD16F8BB2338C8448"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ECommerce_GUI.MainApp.Cart;
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


namespace ECommerce_GUI.MainApp.Cart {
    
    
    /// <summary>
    /// DisplayCart
    /// </summary>
    public partial class DisplayCart : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\MainApp\Cart\DisplayCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image productImg;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\MainApp\Cart\DisplayCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock productName;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\MainApp\Cart\DisplayCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock productPrice;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\MainApp\Cart\DisplayCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock productQuantity;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\MainApp\Cart\DisplayCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buyMore;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\MainApp\Cart\DisplayCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteCart;
        
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
            System.Uri resourceLocater = new System.Uri("/ECommerce_GUI;component/mainapp/cart/displaycart.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MainApp\Cart\DisplayCart.xaml"
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
            this.productImg = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.productName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.productPrice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.productQuantity = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.buyMore = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\MainApp\Cart\DisplayCart.xaml"
            this.buyMore.Click += new System.Windows.RoutedEventHandler(this.buyMore_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.deleteCart = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\MainApp\Cart\DisplayCart.xaml"
            this.deleteCart.Click += new System.Windows.RoutedEventHandler(this.deleteCart_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

