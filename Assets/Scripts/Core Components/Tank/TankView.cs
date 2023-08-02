using UnityEngine;

public class TankView : MonoBehaviour
{
    public Vector3 Position { get; set; }
    public Vector3 LocalScale { get; set; }
    public Quaternion Rotation { get; set; }

    protected virtual void Awake()
    {
        Position = transform.position;
        Rotation = transform.rotation;
        LocalScale = transform.localScale;
    }

    protected virtual void Update() { }

    protected virtual void LateUpdate()
    {
        transform.position = Position;
        transform.rotation = Rotation;
        transform.localScale = LocalScale;
    }

    protected virtual void FixedUpdate() { }
}