using UnityEngine;

public class PlayerTank : Tank<PlayerTank>
{
    [SerializeField]
    float movementSpeed = 1f;

    [SerializeField]
    Joystick joystick;

    protected override void Awake()
    {
        if (joystick == null)
            throw new MissingReferenceException("joystick");
        base.Awake();
    }

    void FixedUpdate()
    {
        float horizontal = joystick.Horizontal;
        horizontal = horizontal >= .2f || horizontal <= -.2f ? horizontal : 0;
        float vertical = joystick.Vertical;
        vertical = vertical >= .2f || vertical <= -.2f ? vertical : 0;

        Vector3 position = transform.position;
        position.x += horizontal * movementSpeed * Time.fixedDeltaTime;
        position.z += vertical * movementSpeed * Time.fixedDeltaTime;

        Vector3 rotation = new Vector3(horizontal, position.y, vertical);

        transform.rotation = Quaternion.LookRotation(rotation);
        transform.position = position;
    }
}