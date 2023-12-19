using UnityEngine;

[CreateAssetMenu(menuName = "Missions Configuration/Create FallBarrelsConfiguration", fileName = "FallBarrelsConfiguration", order = 0)]
public class FallBarrelsConfiguration : MissionConfiguration
{
	[SerializeField] 
	private int _barrelsAmount;
	[SerializeField] 
	private bool _singleBall;

	public int BarrelsAmount => _barrelsAmount;
	public bool SingleBall => _singleBall;
}
