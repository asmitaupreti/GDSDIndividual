//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("Demo.Views.UsersView.xaml", "Views/UsersView.xaml", typeof(global::Demo.Views.UsersView))]

namespace Demo.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\UsersView.xaml")]
    public partial class UsersView : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Syncfusion.ListView.XForms.SfListView listView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.DataTemplate LeftSwipeTemplate;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.DataTemplate RightSwipeTemplate;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(UsersView));
            listView = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Syncfusion.ListView.XForms.SfListView>(this, "listView");
            LeftSwipeTemplate = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.DataTemplate>(this, "LeftSwipeTemplate");
            RightSwipeTemplate = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.DataTemplate>(this, "RightSwipeTemplate");
        }
    }
}
