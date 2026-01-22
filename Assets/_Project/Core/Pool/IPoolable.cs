namespace Project.Core.Pool
{
    public interface IPoolable
    {
        void OnSpawned();
        void OnDespawned();
    }
}