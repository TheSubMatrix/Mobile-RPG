public interface IInteractionPair<T1, in T2>
    where T1 : IInteractionPair<T1, T2>
    where T2 : IInteractionPair<T2, T1>
{
    void InteractWith(T2 other);
}