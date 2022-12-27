using Zenject;

namespace DI
{
    public class InputMoveInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputMoveProvider>()
                .To<KeyInputMoveProvider>().AsCached();
        }
    }
}