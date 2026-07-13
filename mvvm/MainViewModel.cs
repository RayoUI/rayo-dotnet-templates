using Rayo.Core;
using Rayo.Reactivity;

namespace RayoMvvmApp;

public sealed class MainViewModel : ViewModelBase
{
    public Signal<int> Counter { get; } = new(0);

    public void IncrementCounter()
    {
        Counter.Value++;
    }
}
