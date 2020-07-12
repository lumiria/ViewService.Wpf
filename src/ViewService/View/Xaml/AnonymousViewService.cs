#nullable enable

using System;
using System.Windows;

namespace Lumiria.ViewServices.View.Xaml
{
    internal sealed class AnonymousViewService : FreezableViewService
    {
        private readonly Type _serviceType;
        private readonly Func<IViewService> _serviceFactory;
        private IViewService? _serviceImpl;

        public AnonymousViewService(Type serviceType, Func<IViewService> serviceFactory, string? key = null)
        {
            _serviceType = serviceType;
            _serviceFactory = serviceFactory;
            Key = key;
        }

        public override Type ServiceType => _serviceType;

        protected override Freezable CreateInstanceCore() =>
            throw new NotSupportedException();

        internal override IViewService GetService() =>
            _serviceImpl ??= _serviceFactory();
    }

    internal sealed class AnonymousViewService<T> : FreezableViewService
        where T : IViewService
    {
        private readonly Type _serviceType;
        private readonly Func<T> _serviceFactory;
        private IViewService? _serviceImpl;

        public AnonymousViewService(Func<T> serviceFactory, string? key = null)
        {
            _serviceType = typeof(T);
            _serviceFactory = serviceFactory;
            Key = key;
        }

        public override Type ServiceType => _serviceType;

        protected override Freezable CreateInstanceCore() =>
            throw new NotSupportedException();

        internal override IViewService GetService() =>
            _serviceImpl ??= _serviceFactory();
    }
}
