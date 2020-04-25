using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
	public TankView tankView;

	private void Start()
	{
		CreatTank();
	}

	private void CreatTank()
	{
		TankModel model = new TankModel(10f, 200f, 100f);
		TankController tank = new TankController(model, tankView);
	}
}
