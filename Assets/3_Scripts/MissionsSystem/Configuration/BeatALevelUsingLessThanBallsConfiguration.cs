using UnityEngine;

[CreateAssetMenu(menuName = "Missions Configuration/Create BeatALevelUsingLessThanBallsConfiguration", fileName = "BeatALevelUsingLessThanBallsConfiguration", order = 0)]
public class BeatALevelUsingLessThanBallsConfiguration : MissionConfiguration
{
	[SerializeField] 
	private int _ballsAmount;

	public int BallsAmount => _ballsAmount;
}
