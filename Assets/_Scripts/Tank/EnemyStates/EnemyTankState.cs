using Enemy.View;

namespace Enemy.State
{
    public abstract class EnemyTankState
    {
        protected EnemyView enemyView;

        public abstract void Tick();

        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }

        public EnemyTankState(EnemyView enemyView)
        {
            this.enemyView = enemyView;
        }
    }
}