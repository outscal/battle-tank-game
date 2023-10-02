using UnityEngine;

public class ShellController
{
    private ShellModel ShellModel { get; }
    private ShellView ShellView { get; }
    private Transform spawn;
    private Rigidbody shellRb;

    public ShellController(ShellModel shellModel, ShellView shellView, LayerMask shellLayer, Transform spawnTransform)
    {
        spawn = spawnTransform;
        ShellModel = shellModel;
        ShellView = GameObject.Instantiate<ShellView>(shellView, spawn.position + new Vector3(0f, 1.5f, 0f), spawn.rotation);
        ShellView.gameObject.layer = GetLayerFromMask(shellLayer);
        ShellView.SetShellController(this);
        shellRb = ShellView.GetRigidbody();
    }
    public void Shot()
    {
        shellRb.velocity = spawn.forward * ShellModel.Speed;
    }
    public ShellModel GetShellModel()
    {
        return ShellModel;
    }

    private int GetLayerFromMask(LayerMask mask)
    {
        int layerNumber = 0;
        int layer = mask.value;
        while (layer > 0)
        {
            layer = layer >> 1;
            layerNumber++;
        }

        return layerNumber - 1;
    }

}
