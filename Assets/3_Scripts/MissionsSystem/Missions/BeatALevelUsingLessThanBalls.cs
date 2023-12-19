using UnityEngine;

public class BeatALevelUsingLessThanBalls : Mission
{
	private readonly BeatALevelUsingLessThanBallsConfiguration _missionConfiguration;
	
	public BeatALevelUsingLessThanBalls(BeatALevelUsingLessThanBallsConfiguration missionConfiguration) : base(missionConfiguration)
	{
		_missionConfiguration = missionConfiguration;
		MaxProgression = 1;
	}

	public override void Init()
	{
		EventSystemService.Instance.Subscribe<LevelStartedEvent>(OnLevelStarted);
		EventSystemService.Instance.Subscribe<BallShotEvent>(OnBallShot);
	}

	private void OnLevelStarted(LevelStartedEvent levelStartedEvent)
	{
		CurrentProgression = _missionConfiguration.BallsAmount;
	}

	private void OnBallShot(BallShotEvent ballShotEvent)
	{
		--CurrentProgression;
	}

	public override void Release()
	{
		EventSystemService.Instance.Unsubscribe<LevelStartedEvent>(OnLevelStarted);
		EventSystemService.Instance.Unsubscribe<BallShotEvent>(OnBallShot);
	}

	public override string PrintProgression()
	{
		return $"THE BEST: {(CurrentProgression == 0 ? "\u221e" : Mathf.Abs(CurrentProgression - _missionConfiguration.BallsAmount))}/{_missionConfiguration.BallsAmount}";
	}

	public override bool IsCompleted()
	{
		return CurrentProgression > 0 && CurrentProgression < _missionConfiguration.BallsAmount;
	}
}
