
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : ActivatorReferencer
{
	public Activator[] activators = new Activator[0];

	public override IEnumerable<Activator> GetReferences()
	{
		return activators;
	}

	public override void RunErrorChecks(ref List<string> errors)
	{
		foreach(var activator in activators)
		{
			if(!activator)
			{
				errors.Add("A specified Activator is null.");
			}
		}
	}

	public abstract string GetTarget();

	
}
