using UnityEngine;

public class SafePoint : MonoBehaviour
{
    #region Private Data members

    private int _inside ;

    #endregion

    #region Public Properties

    public bool Safe { get; private set; }

    #endregion

    #region Unity Functions

    private void Start()
    {
        _inside = 0;
        Safe = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Tank.EnemyTankView>())
        {
            _inside++;
            Safe = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Tank.EnemyTankView>())
        {
            _inside--;
            Safe = _inside <= 0;
        }
    }

    #endregion
}
