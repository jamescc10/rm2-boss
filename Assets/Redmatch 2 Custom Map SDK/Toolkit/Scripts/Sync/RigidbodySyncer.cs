
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MyceliumIdentity))]
[RequireComponent(typeof(Rigidbody))]
public class RigidbodySyncer : SyncedBehaviour
{
	public bool syncPosition = true;
	public bool syncRotation = true;
	[Range(1f, 12f)] public int syncRate = 12;

	

	public override void RunErrorChecks(ref List<string> errors)
	{
		base.RunErrorChecks(ref errors);

		if(sync && !serverOnly)
		{
			errors.Add("Rigidbody Syncers require Host Only to be enabled if sync is on.");
		}
	}
}
