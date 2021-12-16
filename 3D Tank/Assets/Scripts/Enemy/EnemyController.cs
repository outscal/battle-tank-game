using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Summary//
//Script Controls the Enemy AI
//-Summary//

public class EnemyController : GenericSingleton<EnemyController>
{
	public float lookRadius = 10f;  // Detection range for player

	Transform target;   // Reference to the player
	NavMeshAgent agent; // Reference to the NavMeshAgent

	void Start()
	{
		target = TankController.Instance.transform;
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		float distance = Vector3.Distance(target.position, transform.position);  // Distance to the target

		if (distance <= lookRadius)                    // If inside the lookRadius
		{
			agent.SetDestination(target.position);     // Move towards the target

			if (distance <= agent.stoppingDistance)    // If within attacking distance
			{
				FaceTarget();                          // Make sure to face towards the target
			}
		}
	}

	
	void FaceTarget()     // Rotate the enemy to face the target
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}
}

