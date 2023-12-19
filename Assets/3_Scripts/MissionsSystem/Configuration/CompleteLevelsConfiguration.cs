using UnityEngine;

[CreateAssetMenu(menuName = "Missions Configuration/Create CompleteLevelsConfiguration", fileName = "CompleteLevelsConfiguration", order = 0)]
public class CompleteLevelsConfiguration : MissionConfiguration
{
	[SerializeField] 
	private int _levelsAmount;

	public int LevelsAmount => _levelsAmount;
}
