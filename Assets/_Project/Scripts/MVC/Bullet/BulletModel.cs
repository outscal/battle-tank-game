namespace BattleTank
{
    public class BulletModel
    {
        public float damage { get; private set; }
        public float speed { get; private set; }

        public BulletModel(BulletScriptableObject bulletScriptableObject)
        {
            damage = bulletScriptableObject.damage;
            speed = bulletScriptableObject.speed;
        }
    }
}