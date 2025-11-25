
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MyceliumIdentity))]
public class HealthSyncer : SyncedBehaviour
{
	public int maxHealth = 100;
	public int health = 100;
	public ValueDisplay[] healthDisplays = new ValueDisplay[0];
	public Activator[] OnDamaged = new Activator[0];
	public Activator[] OnHealed = new Activator[0];
	public Activator[] OnDied = new Activator[0];

	public override IEnumerable<Activator> GetReferences()
	{
		foreach(var x in OnDamaged)
			yield return x;
		foreach(var x in OnHealed)
			yield return x;
		foreach(var x in OnDied)
			yield return x;
	}

	public override void RunErrorChecks(ref List<string> errors)
	{
		base.RunErrorChecks(ref errors);

		foreach(var reference in GetReferences())
		{
			if(!reference)
			{
				errors.Add("A specified object is null.");
			}
		}

		foreach(var display in healthDisplays)
		{
			if(!display)
			{
				errors.Add("A specified object is null.");
			}
		}
	}

	
}