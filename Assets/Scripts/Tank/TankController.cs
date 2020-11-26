using UnityEngine;

public class TankController : MonoBehaviour {
	
	[SerializeField]private float MoveSpeed;
	[SerializeField]private  float rotateSpeed;

	//[SerializeField]private Joystick joystick;

	private float vertical;
	private float horizontal;
	
	private Rigidbody rigidbody;

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

	private void Awake()
	{
		//joystick=FindObjectOfType<Joystick>();
		rigidbody=GetComponent<Rigidbody>();
	}

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

	private void FixedUpdate()
	{
		//JoyStickMove();
		TankMovement();
		TankRotate();
	}

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

	void Update ()
	{	
		vertical=Input.GetAxis("Vertical");
		horizontal=Input.GetAxis("Horizontal");

		if(vertical==0 && horizontal ==0){
			rigidbody.constraints = RigidbodyConstraints.FreezePositionX|RigidbodyConstraints.FreezePositionY|RigidbodyConstraints.FreezePositionZ; 
		}
		else{
			rigidbody.constraints = RigidbodyConstraints.None;
			rigidbody.constraints = RigidbodyConstraints.FreezePositionY|RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationY;
			
		}

	}

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

	private void TankMovement()
	{
		if(vertical!=0){
			Vector3 moveTank=transform.forward*vertical*MoveSpeed*Time.deltaTime;
			rigidbody.MovePosition(rigidbody.position + moveTank);
		}
	}

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

	private void TankRotate()
	{
		if(horizontal!=0){
			float rotate = horizontal*rotateSpeed*Time.deltaTime;
			Quaternion rotateTank=Quaternion.Euler(0f,rotate,0f);
			rigidbody.MoveRotation(rigidbody.rotation*rotateTank);
		}
	}


}
