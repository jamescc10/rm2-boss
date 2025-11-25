using UnityEngine;

public class EnterTrigger : TriggerColliderTrigger
{
	public override string GetTarget()
	{
		return "The Player/ObjectSyncer that enters this trigger.";
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
