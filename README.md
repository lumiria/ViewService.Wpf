# ViewService.Wpf
This provides view services for communicating from the ViewModel to the View.

## Install
~~~
PM > Install-Package ViewService.Wpf
~~~

## Introduction
When implementing the MVVM pattern, we have a separation between the View and ViewModel.  
*ViewService.Wpf* provides some view services and their containers for communicating from the ViewModel to the View.

See [this article](https://docs.microsoft.com/en-us/archive/msdn-magazine/2013/march/mvvm-messenger-and-view-services-in-mvvm) for view services in MVVM.


## Quick start
Add the view services you want to use from ViewModel to ViewServiceProvider container on View.

Implements the services to be used by the code-behind of View or define it in XAML resource.

### For XAML
```markup
<Window xmlns:service="http://schemas.lumiria.com/view-services">
    <Window.Resources>
        <ResourceDictionary>
            <service:ViewServiceProvider x:Key="ViewServiceProvider">
                <service:WindowService Key="Sub"
                                       WindowType="{x:Type view:SubWindow}"
                                       Owner="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type Window}}}" /> 
                <service:MessageBoxService Owner="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type Window}}}" />
            </service:ViewServiceProvider>
        </ResourceDictionary>
    </Window.Resources>
    <!-- Contents -->
</Window>
```
Pass the resource of ViewServiceProvider to the ViewModel.
In the ViewModel, you get the necessary services from ViewServiceProvider and used.

```csharp
var windowService = provider.Get<IWindowService>("Sub");
windowService.ShowDialog();
```


### For Code-Behind

Implement the properties of IViewServiceProvider in ViewModel.

```csharp
private IViewServiceProvider _viewServiceProvider;
public IViewServiceProvider ViewServiceProvider
{
    get => _viewServiceProvider ??= ViewService.CreateProvider();
    set => _viewServiceProvider = value;
}
```

On View, add the view services you want to use to IViewServiceProvider exposed by ViewModel.

```csharp
var provider = ViewModel.ViewServiceProvider;
provider.AddService(
    () => ViewServiceFactory.CreateWindowAction(this));
provider.AddService(
    () => ViewServiceFactory.CreateMessageBox(this));
provider.AddService(
    () => ViewServiceFactory.CreateOpenFileDialog(this));
provider.AddService(
    () => ViewServiceFactory.CreateSaveFileDialog(this));
```

In the ViewModel, you get the necessary services from ViewServiceProvider and used.

```csharp
var service = ViewServiceProvider.Get<IWindowActionService>();
service.Close();
```

## Implemented services
* **IWindowService**
    
    Display any window.

* **IWindowActionService**

    Executes standard actions ot the target window.

* **IMessageBoxService**

    Display a message box.

* **IOpenFileDialogService**

    Call [OpenFileDialog](https://docs.microsoft.com/ja-jp/dotnet/api/microsoft.win32.openfiledialog).

* **ISaveFileDialogService**

    Call [SaveFileDialog](https://docs.microsoft.com/ja-jp/dotnet/api/microsoft.win32.savefiledialog).

## License
This library is under the MIT License.