
using System.Collections.Generic;
using UnityEngine;

public class TargetActivator : Activator
{
	public enum TargetActivatorTargetMode { Dynamic, Preset };
	public TargetActivatorTargetMode targetMode = TargetActivatorTargetMode.Dynamic;
	public GameObject presetTarget;

	// Player
	public bool affectPlayers;
	public short playerDamage;

	// Physics Objects
	public bool applyForce;
	public Vector3 force;
	public enum RelativeForceMode { World, Self, Target, Orbital };
	public RelativeForceMode relativeForceMode = RelativeForceMode.Self;
	public enum TargetActivatorForceMode { Force, Acceleration, Impulse, VelocityChange, VelocityOverwrite };
	public TargetActivatorForceMode forceMode = TargetActivatorForceMode.VelocityOverwrite;
	public Transform teleport;
	public bool useTeleportLocationRotation;
	public bool keepOffsetWhenTeleporting;

	public override void RunErrorChecks(ref List<string> errors)
	{
		if(targetMode == TargetActivatorTargetMode.Preset)
		{
			if(presetTarget)
			{
				if(!presetTarget.TryGetComponent(out RigidbodySyncer rb))
				{
					errors.Add("Your preset target needs a RigidbodySyncer component.");
				}
			}
			else
			{
				errors.Add("When using the Preset target mode, you need to specify a target.");
			}

			if(affectPlayers)
			{
				errors.Add("You can't have Affect Players enabled with Preset target mode, since you can't specify a player ahead of time. If you want to affect players you need to use the Dynamic target mode.");
			}
		}
	}

	
}
