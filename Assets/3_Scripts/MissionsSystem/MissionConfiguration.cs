using UnityEngine;

public class MissionConfiguration : ScriptableObject
{
	[SerializeField] 
	private string _description;

	public string Description => _description;
}