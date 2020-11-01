using UnityEngine;

public class TankModel: MonoSingeltonGeneric<TankController>
{
    public float Speed = 5f;

    internal float getSpeed(){
        return Speed;
    }
}
