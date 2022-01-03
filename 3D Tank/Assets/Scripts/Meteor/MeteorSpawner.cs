using System.Collections;
using UnityEngine;
using Pause;

public class MeteorSpawner : MonoBehaviour {

	public GameObject meteorPrefab;
	private int xPos;
	private int zPos;

	void Start ()
	{ 
        {
			StartCoroutine(SpawnMeteor());
		}
	}

	IEnumerator SpawnMeteor()
	{
		xPos = Random.Range(55,-45);
		zPos = Random.Range(20,-90);
		if (PauseMenuController.Instance.state == GameStates.RunningState)
        {
			Instantiate(meteorPrefab, new Vector3(xPos, 30f, zPos), Quaternion.identity);
		}
		yield return new WaitForSeconds(0.35f);

		StartCoroutine(SpawnMeteor());
	}

}
