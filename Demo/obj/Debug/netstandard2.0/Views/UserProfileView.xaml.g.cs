//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("Demo.Views.UserProfileView.xaml", "Views/UserProfileView.xaml", typeof(global::Demo.Views.UserProfileView))]

namespace Demo.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\UserProfileView.xaml")]
    public partial class UserProfileView : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Frame BackgroundView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::ImageCircle.Forms.Plugin.Abstractions.CircleImage ProfileImage;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(UserProfileView));
            BackgroundView = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Frame>(this, "BackgroundView");
            ProfileImage = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::ImageCircle.Forms.Plugin.Abstractions.CircleImage>(this, "ProfileImage");
        }
    }
}
