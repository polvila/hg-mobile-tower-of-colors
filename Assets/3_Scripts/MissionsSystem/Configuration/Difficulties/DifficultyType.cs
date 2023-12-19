using UnityEngine;

[CreateAssetMenu(menuName = "Difficulty Configuration/Create Difficulty Type", fileName = "DifficultyType", order = 0)]
public class DifficultyType : ScriptableObject
{
	[SerializeField]
	private int _value;

	public int Value => _value;
}
