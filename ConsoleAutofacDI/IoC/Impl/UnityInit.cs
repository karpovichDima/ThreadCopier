using Unity;

namespace ConsoleAutofacDI.IoC.Impl
{
    class UnityInit
    {
        private static UnityInit _unityInit;
        public IUnityContainer Container { get; set; }

        private UnityInit()
        {
            Container = new UnityContainer();
        }

        public void RegistrationDependency<T,TN>() where TN : T
        {
            Container.RegisterType<T, TN>();
        }

        public static UnityInit GetInstance()
        {
            if (_unityInit != null) return _unityInit;
            _unityInit = new UnityInit();
            return _unityInit;
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
