using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ExitTrigger : TriggerColliderTrigger
{
	public override string GetTarget()
	{
		return "The Player/ObjectSyncer that exits this trigger.";
	}

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
