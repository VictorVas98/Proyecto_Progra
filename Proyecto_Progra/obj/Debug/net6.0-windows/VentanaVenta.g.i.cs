﻿#pragma checksum "..\..\..\VentanaVenta.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1D72F13BC3B0945BEF9849E37DDAE55478E24AAC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Proyecto_Progra;
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


namespace Proyecto_Progra {
    
    
    /// <summary>
    /// VentanaVenta
    /// </summary>
    public partial class VentanaVenta : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\VentanaVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrecio;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\VentanaVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCantidad;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\VentanaVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTotal;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\VentanaVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\VentanaVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVender;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\VentanaVenta.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCantidadActual;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Proyecto_Progra;V1.0.0.0;component/ventanaventa.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\VentanaVenta.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtPrecio = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtCantidad = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\VentanaVenta.xaml"
            this.txtCantidad.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtCantidad_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtTotal = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\VentanaVenta.xaml"
            this.cb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnVender = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\VentanaVenta.xaml"
            this.btnVender.Click += new System.Windows.RoutedEventHandler(this.btnVender_Click_1);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtCantidadActual = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 24 "..\..\..\VentanaVenta.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

