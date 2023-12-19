using UnityEngine;

[CreateAssetMenu(menuName = "Missions Configuration/Create ExplodeBarrelsConfiguration", fileName = "ExplodeBarrelsConfiguration", order = 0)]
public class ExplodeBarrelsConfiguration : MissionConfiguration
{
	[SerializeField] 
	private int _barrelsAmount;
	[SerializeField] 
	private bool _singleBall;

	public int BarrelsAmount => _barrelsAmount;
	public bool SingleBall => _singleBall;
}
