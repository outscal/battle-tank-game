namespace EnemyStates
{
    public abstract class EnemyState
    {
        protected EnemyView enemyView;

        public EnemyState(EnemyView enemyView) { this.enemyView = enemyView; }

        public abstract void OnStateEnter();
        public abstract void Tick();
        public abstract void OnStateExit();
    }
}