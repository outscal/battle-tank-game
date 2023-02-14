public interface StateInterface<T>
{
    void OnEnterState(T ObjectState);
    void Update();
    void OnExitState(T ObjectState);
}
