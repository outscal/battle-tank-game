using UnityEngine;

public class TankController 
{
    public TankModel TankModel { get; }
    public TankView tankView { get; }
    private Rigidbody rb;

    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        tankView = GameObject.Instantiate<TankView>(tankPrefab);
        rb = tankView.GetRigidBody();
        TankModel.SetTankController(this);
        tankView.SetTankController(this);
    }

    public void Move(float movement, float Speed){
        Vector3 velocity = tankView.transform.transform.position += tankView.transform.forward*movement*Speed;
        rb.MovePosition(velocity);
        
    }

    public void Rotate(float rotate, float rotateSpeed){
        Vector3 vector = new Vector3(0f, rotate*rotateSpeed,0f);
        Quaternion deltaRotation = Quaternion.Euler(vector*Time.deltaTime);
        rb.MoveRotation(rb.rotation*deltaRotation);
    }

    public void ApplyDamage(BulletType bulletType, int damage){
        if(TankModel.Health <= 0){

        }
        else{
            TankModel.Health -= damage;
            Debug.Log("Player took Damaeg: " + TankModel.Health);
        }
    }

}