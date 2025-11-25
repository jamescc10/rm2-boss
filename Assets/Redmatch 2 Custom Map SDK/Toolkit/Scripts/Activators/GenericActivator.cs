
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*
 * The general architecture of this class is that it should facilitate
 * networked events, not actually deal with networking. That way
 * all state can be managed by other components and conflicts such as
 * enabling and disabling the same GameObject from multiple Activators
 * can be avoided.
 */

public class GenericActivator : Activator
{
	public enum AuthorityRequirement { OnlyHost, OnlyLocalPlayer, Everyone };
	public AuthorityRequirement authorityRequirement;
	public GameObjectSyncer[] objectsToEnable = new GameObjectSyncer[0];
	public GameObjectSyncer[] objectsToDisable = new GameObjectSyncer[0];
	public GameObjectSyncer[] randomObjectToEnable = new GameObjectSyncer[0];
	public GameObjectSyncer[] randomObjectToDisable = new GameObjectSyncer[0];
	public AnimatorActionData[] animatorActions = new AnimatorActionData[0];
	public Activator[] activatorActions = new Activator[0];
	public HealthSyncerActionData[] healthSyncerActions = new HealthSyncerActionData[0];

	public override IEnumerable<Activator> GetReferences()
	{
		foreach(var x in activatorActions) yield return x;
	}

	public override void RunErrorChecks(ref List<string> errors)
	{
		foreach(var obj in AllObjects())
		{
			if(obj == null)
			{
				errors.Add($"A specified object is null.");
			}
		}
	}

	IEnumerable<object> AllObjects()
	{
		foreach(var x in objectsToEnable)
			yield return x;
		foreach(var x in objectsToDisable)
			yield return x;
		foreach(var x in randomObjectToEnable)
			yield return x;
		foreach(var x in randomObjectToDisable)
			yield return x;
		foreach(var x in animatorActions)
			yield return x.animatorSyncer;
		foreach(var x in activatorActions)
			yield return x;
		foreach(var x in healthSyncerActions)
			yield return x.healthSyncer;
	}


	
}

[System.Serializable]
public class AnimatorActionData
{
	public enum AnimatorActionType { SetFloat, SetRandomFloatFrom0To1, SetInteger, SetBool, SetTrigger, ResetTrigger };
	public AnimatorSyncer animatorSyncer;
	public AnimatorActionType actionType;
	public string parameter;
	[ConditionalHide(nameof(actionType), 0, true, false)]
	public float floatValue;
	[ConditionalHide(nameof(actionType), 2, true, false)]
	public int intValue;
	[ConditionalHide(nameof(actionType), 3, true, false)]
	public bool boolValue;
}

[System.Serializable]
public class HealthSyncerActionData
{
	public enum HealthSyncerActionType { ChangeHealth, SetHealth, DynamicFromDamageableTrigger };

	public HealthSyncer healthSyncer;
	public HealthSyncerActionType actionType;
	[ConditionalHide(nameof(actionType), 2, true, true)]
	public int amount;
}