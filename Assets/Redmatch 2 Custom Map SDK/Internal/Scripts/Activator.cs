
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class Activator : ActivatorReferencer
{
	public enum PlayerTeamRequirementType { NoRequirement, SpecificTeam, AnyTeamExcept };
	public PlayerTeamRequirementType playerTeamRequirementType;
	public Team requiredTeam;

	public enum PlayerStatRequirementType { NoRequirement, MoreThan, EqualTo, LessThan };
	public PlayerStatRequirementType playerStatRequirementType;
	public enum PlayerStat { Kills = 0, Deaths = 1, Points = 18 }
	public PlayerStat playerStat;
	public int requiredStat;

	public float actionDelay = 0f;
	public float cooldown = 0f;

	

#if UNITY_EDITOR
	List<ActivatorReferencer> cachedReferencers;

	public void RecacheReferences()
	{
		cachedReferencers = null;
	}

	void OnDrawGizmosSelected()
	{
		if(cachedReferencers == null)
		{
			cachedReferencers = new List<ActivatorReferencer>();

			foreach(var root in SceneManager.GetActiveScene().GetRootGameObjects())
			{
				foreach(var reference in root.GetComponentsInChildren<ActivatorReferencer>())
				{
					if(reference.GetReferences().Contains(this))
					{
						cachedReferencers.Add(reference);
					}
				}
			}
		}

		Gizmos.color = Color.white;
		foreach(var reference in cachedReferencers)
		{
			if(reference)
			{
				Gizmos.DrawSphere(reference.transform.position, 0.3f);
				Gizmos.DrawLine(reference.transform.position, transform.position);
				Handles.Label(reference.transform.position + Vector3.up * 0.7f, $"Triggered by\n{reference}");
			}
		}
	}
#endif
}