
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class StayTrigger : TriggerColliderTrigger
{
	public override string GetTarget()
	{
		return "The Player/ObjectSyncer that stays in this trigger.";
	}

	public float initialDelay = 0f;
	[Tooltip("This has a minimum value of 0.01.")]
	public float repeatDelay = 1f;

	void Reset()
	{
		if(gameObject.GetComponent<Rigidbody>() == null)
		{
			var rb = gameObject.AddComponent<Rigidbody>();
			rb.isKinematic = true;
			rb.useGravity = false;
			rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
		}
	}

	
}
