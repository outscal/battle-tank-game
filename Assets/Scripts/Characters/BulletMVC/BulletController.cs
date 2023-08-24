using UnityEngine;

public class BulletController
{
    public BulletModel _bulletmodel { get; private set; }
    private BulletView _bulletview;
    private BulletScriptableObject _bulletscript;
    [SerializeField] private Transform shootPoint;
    public BulletController(BulletModel bulletModel,BulletScriptableObject BulletSO)
    {
        _bulletmodel = bulletModel;
        _bulletscript = BulletSO;
        _bulletview = _bulletscript.bulletView;
        _bulletview.SetBulletController(this, _bulletmodel);
        //GameObject bullet= GameObject.Instantiate(_bulletscript.bulletView.gameObject);
    }
    public int GetSpeed()
    {
        return _bulletmodel.SpeedLive;
    }
    public int GetDuration()
    {
        return _bulletmodel.Duration;
    }

    
}
