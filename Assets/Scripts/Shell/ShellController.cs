using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ShellController
{
    private ShellModel ShellModel { get; }
    private ShellView ShellView { get; }
    private Transform spawn;
    private Rigidbody shellRb;

    public ShellController(ShellModel shellModel, ShellView shellView, Transform spawnTransform)
    {
        spawn = spawnTransform;
        ShellModel = shellModel;
        ShellView = GameObject.Instantiate<ShellView>(shellView, spawn.position + new Vector3(0f, 1.5f, 0f), spawn.rotation);
        ShellView.SetShellController(this);
        shellRb = ShellView.GetRigidbody();
    }
    public void Shot()
    {
        shellRb.velocity = spawn.forward * ShellModel.shell_Speed;
    }
    public ShellModel GetShellModel()
    {
        return ShellModel;
    }
}
