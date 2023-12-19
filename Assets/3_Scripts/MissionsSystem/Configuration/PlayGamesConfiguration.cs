using UnityEngine;

[CreateAssetMenu(menuName = "Missions Configuration/Create PlayGamesConfiguration", fileName = "PlayGamesConfiguration", order = 0)]
public class PlayGamesConfiguration : MissionConfiguration
{
	[SerializeField] 
	private int _gamesAmount;

	public int GamesAmount => _gamesAmount;
}
