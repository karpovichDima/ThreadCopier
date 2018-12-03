using Unity;

namespace ConsoleAutofacDI.IoC.Impl
{
    class UnityInit : AbstractContainer
    {
        private static UnityInit _unityInit;
        public IUnityContainer Container { get; set; }

        private UnityInit()
        {
            Container = new UnityContainer();
        }

        public static UnityInit GetInstance()
        {
            if (_unityInit != null) return _unityInit;
            _unityInit = new UnityInit();
            return _unityInit;
        }
        
        public override void RegistrationDependency<T, TN>()
        {
            Container.RegisterType<T, TN>();
        }

        public override T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
