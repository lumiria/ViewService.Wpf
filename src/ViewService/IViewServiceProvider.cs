#nullable enable

namespace ViewServices
{
    /// <summary>
    /// Defines a mechanism for retrieving a service object for the view.
    /// </summary>
    public interface IViewServiceProvider
    {
        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the service object.</typeparam>
        /// <param name="key">The key that identifies the service object.</param>
        /// <returns>A service object of type T.</returns>
        T Get<T>(string? key=null) where T : class, IViewService;

    }
}
