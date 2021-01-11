using System.Windows;
using System.Windows.Markup;

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
                                     //(used if a resource is not found in the page,
                                     // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
                                              //(used if a resource is not found in the page,
                                              // app, or any theme specific resource dictionaries)
)]

[assembly: XmlnsDefinition("http://schemas.lumiria.com/view-services",
    "ViewServices.View.Xaml")]
[assembly: XmlnsDefinition("http://schemas.lumiria.com/view-services",
    "ViewServices.View.Markups")]
[assembly: XmlnsDefinition("http://schemas.lumiria.com/view-services/components",
    "ViewServices.Components")]
[assembly: XmlnsDefinition("http://schemas.lumiria.com/view-services/utilities",
    "ViewServices.View.Extenders")]
[assembly: XmlnsDefinition("http://schemas.lumiria.com/view-services/utilities",
    "ViewServices.View.Converters")]
