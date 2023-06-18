namespace BattleTank.BulletShooting
{
    public class BulletModel
    {
        public BulletType BulletType;
        public BulletController BulletController { get; private set; }

        public void SetBulletController(BulletController bulletController)
        {
            BulletController = bulletController;
        }

        public BulletModel(BulletScriptableObject bulletScriptableObject)
        {
            BulletType = bulletScriptableObject.BulletType;
        }
    }
}