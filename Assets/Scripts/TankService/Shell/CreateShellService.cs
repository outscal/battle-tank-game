
using UnityEngine;

namespace TankBattle.Tank.Bullets
{
    public class CreateShellService : GenericSingleton<CreateShellService>
    {
        [SerializeField] private ShellScriptableObject shellScriptableObject;

        public ShellModel GetBulletModel { get; set; }

        public ShellController CreateBulletShell(Transform fireTransform)
        {
            GetBulletModel = new ShellModel(shellScriptableObject);
            ShellController bulletShell = new ShellController(GetBulletModel, shellScriptableObject.shellView, fireTransform);
            bulletShell.GetShellView.SetShellController(bulletShell);
            return bulletShell;
        }
    }
}