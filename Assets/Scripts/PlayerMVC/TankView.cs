using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TankServices;
public class TankView : GenricSingleton<TankView>
{
    private TankController tankController;
    WaitForSeconds waitForSeconds = new WaitForSeconds(2f); //can be serialized in case of making it more easier for designers
    [HideInInspector]
    public Joystick joystick;
    [HideInInspector]
    public CinemachineVirtualCamera virtualCamera;
    [HideInInspector]
    public Material materialFromScriptableObject;
    [SerializeField] MeshRenderer tankTurretMaterial;
    [SerializeField] MeshRenderer tankBodyMaterial;
    public BulletService bulletService;
    public void SetTankController(TankController _tankController)
    {
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        virtualCamera.Follow = this.transform;
        tankController = _tankController;
        tankTurretMaterial.material = materialFromScriptableObject;
        tankBodyMaterial.material = materialFromScriptableObject;
    }

    private void Update()
    {

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            tankController.UpdateMovementAndRotation(joystick.Horizontal, joystick.Vertical);
        }
        if (Input.GetKeyDown(KeyCode.Space))
            tankController.Shoot();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<EnemyView>())
        {
            tankController.DisableTank();
            this.GetComponent<ParticleSystem>().Play() ;
            tankTurretMaterial.enabled = false;
            tankBodyMaterial.enabled = false;
            StartCoroutine(WaitBeforeDestroy());

        }
    }

    private IEnumerator WaitBeforeDestroy()
    {
        yield return waitForSeconds;
        ServiceEvents.Instance.OnPlayerDeath?.Invoke();
        tankController.DestroyTank();
    }

}
