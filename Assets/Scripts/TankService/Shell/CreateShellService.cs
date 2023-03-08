
using UnityEngine;

namespace TankBattle.Tank.Bullets
{
    public class CreateShellService : GenericSingleton<CreateShellService>
    {
        [SerializeField] private ShellScriptableObject shellScriptableObject;

        private ShellModel bulletModel;

        public ShellController CreateBulletShell(Transform fireTransform)
        {
            bulletModel = new Bullets.ShellModel(shellScriptableObject);
            ShellController bulletShell = new Bullets.ShellController(bulletModel, shellScriptableObject.shellView, fireTransform);
            bulletShell.GetShellView.SetShellController(bulletShell);
            return bulletShell;
        }
    }
}
