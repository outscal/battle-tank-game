using UnityEngine;

public class PlayerTankView : TankView
{
    public PlayerTankController PlayerTankController { get; set; }

    protected override void Update()
    {
        base.Update();

        if (PlayerTankController != null)
            PlayerTankController.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (PlayerTankController != null)
            PlayerTankController.FixedUpdate();
    }

    public void Destroy()
    {
        // Remove the TankParts from the Scene
        foreach (Transform childTransform in gameObject.transform)
        {
            // Check if the child transform has the specified tag
            if (childTransform.CompareTag("Player"))
            {
                GameObject.Destroy(childTransform.gameObject);
            }
        }

        StartCoroutine(PlayerTankController.Destroyer());
    }
}