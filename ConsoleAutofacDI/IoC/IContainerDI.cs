
namespace ConsoleAutofacDI.IoC
{
    public interface IContainerDI
    {
        T Resolve<T, TN>() where T : class where TN : class, T;
    }
}
