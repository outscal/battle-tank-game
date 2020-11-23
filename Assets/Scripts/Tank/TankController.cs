using UnityEngine;

public class TankController : MonoBehaviour {
	
	[SerializeField]private float MoveSpeed;
	[SerializeField]private  float rotateSpeed;
	private float vertical;
	private float horizontal;
	//private Joystick joystick;
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
		vertical=Input.GetAxis("VerticalUI");
		horizontal=Input.GetAxis("HorizontalUI");
	}

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

	private void TankMovement()
	{
		if(vertical!=0){
			Vector3 moveTank=transform.forward*vertical*MoveSpeed*Time.deltaTime;
			rigidbody.MovePosition(rigidbody.position + moveTank);
		}
		else{
			rigidbody.MovePosition(rigidbody.position);
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
		else{
			rigidbody.MoveRotation(rigidbody.rotation);
		}
	}


}
