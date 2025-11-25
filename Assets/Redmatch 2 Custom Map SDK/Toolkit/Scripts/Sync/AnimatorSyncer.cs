
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MyceliumIdentity))]
public class AnimatorSyncer : SyncedBehaviour
{
	public bool desyncProtection = true;

	void Reset()
	{
		GetComponent<Animator>().updateMode = AnimatorUpdateMode.AnimatePhysics;
	}

	
}
