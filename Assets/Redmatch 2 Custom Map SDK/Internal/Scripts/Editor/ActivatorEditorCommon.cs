using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class ActivatorEditorCommon
{
	public static void DrawCommon(SerializedObject serializedObject, Activator activator)
	{
		EditorGUI.indentLevel = 0;
		EditorGUILayout.BeginVertical("Box");
		EditorGUILayout.LabelField("Triggering Player Filter", EditorStyles.boldLabel);
		EditorGUILayout.HelpBox("If requirements are set, when triggered by a player, this activator will only activate if that player meets the set requirements.", MessageType.Info);

		EditorGUI.indentLevel++;
		EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(activator.playerTeamRequirementType)), new GUIContent("Team Requirement Type", ""), true);

		EditorGUI.indentLevel++;
		if(activator.playerTeamRequirementType != Activator.PlayerTeamRequirementType.NoRequirement)
		{
			EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(activator.requiredTeam)), new GUIContent("Team", ""), true);
		}

		EditorGUI.indentLevel--;
		EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(activator.playerStatRequirementType)), new GUIContent("Stat Requirement Type", ""), true);

		EditorGUI.indentLevel++;
		if(activator.playerStatRequirementType != Activator.PlayerStatRequirementType.NoRequirement)
		{
			EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(activator.playerStat)), new GUIContent("Stat", ""), true);
			EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(activator.requiredStat)), new GUIContent("Value", ""), true);
		}

		EditorGUILayout.EndVertical();
	}
}
