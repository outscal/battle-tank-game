using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaInstance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Characters<PlayerTank>.Instacnce.PlayerTankinit();
        Characters<EnemyTank>.Instacnce.EnemyTankinit();
    }

}
