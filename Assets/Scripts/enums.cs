using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum EnemyTankType
{
    None = 0,
    Pink = 1,
    Yellow = 2,
    SkyBlue = 3

}
public enum BulletType
{
    None = 0,
    PlayerBullet = 1,
    EnemyBullet = 2,
    HighDamage = 3

}

public enum PlayerTankType
{
    None = 0,
    FirstTank = 1,
    SecondTank = 2,
    ThirdTank = 3

}

public enum EnemyStates
{
    None = 0,
    Idle = 1,
    Patroling = 2,
    Chasing = 3,
    Attacking = 4
}

public enum PlayerSfx
{
    Idle,
    Walk,
    Fire,
    EnemyKill,
    Death,
}
public enum CollectibleSfx
{
    Coin,
    Key,
    Life,
}

public enum GameEffects
{

}

public enum UISfx
{
    ButtonClick,
    NextLevl,
    Restart,
    PopUp,
}
public enum GameSfx
{
    Intro,
    MainMenu,
    GameBg,
    GameOver,
    LevelComplete,
    GameComplete,

}
