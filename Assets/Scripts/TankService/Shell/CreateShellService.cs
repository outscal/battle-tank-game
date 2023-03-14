
using UnityEngine;

namespace TankBattle.Tank.Bullets
{
    public class CreateShellService : GenericSingleton<CreateShellService>
    {
        [SerializeField] private ShellScriptableObject shellScriptableObject;

        public ShellModel GetBulletModel { get; set; }

        public void CreateBullet(Transform fireTransform, Vector3 velocityVector)
        {
            GetBulletModel = new ShellModel(shellScriptableObject);
            ShellController bulletShell = new ShellController(GetBulletModel, shellScriptableObject.shellView, fireTransform);
            bulletShell.GetShellView.SetShellController(bulletShell);

            // Fire/Launch bullet
            bulletShell.GetShellView.AddVelocity(velocityVector);
        }
    }
}