using System;
using System.Collections.Generic;
using UnityEngine;

public class AcheivementService : GenericSingleton<AcheivementService>
{
    public event Action<string> onBulletAcheivement;
    public event Action<string> onDistanceAcheivement;
    public event Action<string> onKillingAcheivement;

    //public DictIntString dicts ;
    //public DictFloatString dictsFloat;

    public List<AcheivementCondition> bulletAcheivement;
    public List<AcheivementCondition> killAcheivement;
    public List<AcheivementCondition> distanceAcheivement;
    public UIacheivement ui_acheivement;

    public int killAcheivementPointer = 0;
    int bulletAcheivementPointer = 0;
    int distanceAcheivementPointer = 0;

    protected override void Start()
    {
        base.Start();
        BulletService.Instance.bulletfire += bulletAcheivementCalculator;
        TankService.Instance.distanceMilestoneCover += distanceAcheivementCalculator;
        TankService.Instance.killCounter += killAcheivementCalculator;
    }

    public void bulletAcheivementCalculator(int count)
    {
        executeAcheivement(bulletAcheivement, ref bulletAcheivementPointer, onBulletAcheivement, count);
    }
    public void killAcheivementCalculator(int count)
    {
        executeAcheivement(killAcheivement, ref killAcheivementPointer, onKillingAcheivement, count);
    }
    public void distanceAcheivementCalculator(int count)
    {
        executeAcheivement(distanceAcheivement, ref distanceAcheivementPointer, onDistanceAcheivement, count);
    }
    private void executeAcheivement(List<AcheivementCondition> list, ref int pointer, Action<string> action, int checkCount)
    {
        if (pointer < list.Count)
        {
            AcheivementCondition acheivement = list[pointer];
            if (acheivement.condition == checkCount)
            {
                pointer++;
                if(!ui_acheivement.gameObject.activeSelf) ui_acheivement.gameObject.SetActive(true);
                action?.Invoke(acheivement.message);
            }
        }
    }

}

[Serializable]
public class AcheivementCondition //<I> : ISerializationCallbackReceiver where I : AcheivementCondition<I>
{
    [SerializeField] public int condition;
    [SerializeField] public string message;
}




