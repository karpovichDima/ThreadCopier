using SimpleInjector;

namespace ConsoleAutofacDI.IoC.Impl
{
    class SimpleInjectorInit : AbstractContainer
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

        public override void RegistrationDependency<T, TN>()
        {
            Container.Register<T, TN>();
        }

        public override T Resolve<T>()
        {
            return Container.GetInstance<T>();
        }
    }
}