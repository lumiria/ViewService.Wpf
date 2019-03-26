# ViewService.Wpf
This provides a service for accessing View from ViewModel.

## Install
~~~
PM > Install-Package ViewService.Wpf
~~~

## Quick start
Implements the services to be userd by code-behind of View or define it in XAML resource.
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
Pass instance of ViewServiceProvider in the View to the ViewModel.
In the ViewModel, you gets the necessary services from ViewServiceProvider and used.

```csharp
var windowService = provider.Get<IWindowService>("Sub");
windowService.ShowDialog();
```

## Implemented services
* WindowService
    
    A service to display a window.
* WindowActionService

    A service that executes the action ot the target window.
* MessageBoxService

    A service to display a message box.

## License
This library is under the MIT License.