using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
public class TankView : MonoBehaviour
{
    private TankController tankController;
    WaitForSeconds waitForSeconds= new WaitForSeconds(2f); //can be serialized in case of making it more easier for designers
    [HideInInspector]
    public Joystick joystick;
    [HideInInspector]
    public CinemachineVirtualCamera virtualCamera;
    [HideInInspector]
    public Material materialFromScriptableObject;
    [SerializeField] MeshRenderer tankTurretMaterial ;
    [SerializeField] MeshRenderer tankBodyMaterial;
    public BulletService bulletService ;
    public void SetTankController(TankController _tankController)
    {
        virtualCamera= FindObjectOfType<CinemachineVirtualCamera>();
        virtualCamera.Follow = this.transform;
        tankController = _tankController;
        tankTurretMaterial.material = materialFromScriptableObject;
        tankBodyMaterial.material = materialFromScriptableObject;
    }

    private void Update()
    {

        if (joystick.Horizontal!=0 || joystick.Vertical!=0)
        {
            tankController.UpdateMovementAndRotation(joystick.Horizontal, joystick.Vertical);
        }
        if (Input.GetKeyDown(KeyCode.Space))
            tankController.Shoot();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.GetComponent<EnemyView>())
        {
            tankController.DisableTank();
            StartCoroutine(WaitBeforeDestroy());
            
        }
    }

    private IEnumerator WaitBeforeDestroy()
    {
        yield return waitForSeconds;
        FindObjectOfType<GameManager>().startDestroying = true; //believe me i tried many things, but this seems to work fine, and will only be called once, so win-win?
        tankController.DestroyTank();
    }

}
