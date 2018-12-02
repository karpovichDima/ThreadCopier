using SimpleInjector;

namespace ConsoleAutofacDI.IoC.Impl
{
    class SimpleInjectorInit
    {
        private static SimpleInjectorInit _simpleInjector;
        public static Container Container;

        private SimpleInjectorInit()
        {
            Container = new Container();
        }

        public static SimpleInjectorInit GetInstance()
        {
            if (_simpleInjector != null) return _simpleInjector;
            _simpleInjector = new SimpleInjectorInit();
            return _simpleInjector;
        }

        public void RegistrationDependency<T, TN>() where T : class where TN : class, T
        {
            Container.Register<T, TN>();
        }

        public T Resolve<T>() where T : class
        {
            return Container.GetInstance<T>();
        }
    }
}