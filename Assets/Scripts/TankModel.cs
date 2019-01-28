using System;

public class TankModel
{
    public float MoveSpeed { get; private set; }

    private Vector3New position;

    public Vector3New Position
    {
        get
        {
            return position;
        }

        set
        {
            if(position != null)
            {
                position = value;
                if (OnPositionChanged != null)
                    OnPositionChanged(value);
            }
        }
    }

    public delegate void PositionEvent(Vector3New position);
    public event PositionEvent OnPositionChanged;


}
