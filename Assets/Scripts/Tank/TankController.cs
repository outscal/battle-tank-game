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
		Vector3 moveTank=transform.forward*vertical*MoveSpeed*Time.deltaTime;
		rigidbody.MovePosition(rigidbody.position + moveTank);
	}

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

	private void TankRotate()
	{
		float rotate = horizontal*rotateSpeed*Time.deltaTime;
		Quaternion rotateTank=Quaternion.Euler(0f,rotate,0f);
		rigidbody.MoveRotation(rigidbody.rotation*rotateTank);
	}

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````joystick
	// private void JoyStickMove()
	// {
	// 	rigidbody.velocity= new Vector3(joystick.Horizontal*5f,rigidbody.velocity.y,joystick.Vertical*5f);
	// }
	
}
