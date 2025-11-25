
using System.Collections.Generic;
using UnityEngine;

public abstract class CooldownTrigger : Trigger
{
	[Tooltip("The minimum amount of time in seconds that must pass before the trigger can be executed again. For triggers that repeat, this is not the same as a repeat delay. It only affects the initial trigger.")]
	public float cooldown;

	
}
