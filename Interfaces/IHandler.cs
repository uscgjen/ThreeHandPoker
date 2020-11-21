using ThreeHandPoker.Models;

namespace ThreeHandPoker.Interfaces
{
    public interface IHandler
    {
        void SetNextHandler(IHandler handler);
        void Process(PlayerHand player);
    }
}
