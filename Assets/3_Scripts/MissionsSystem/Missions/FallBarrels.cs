public class FallBarrels : Mission
{
	private readonly FallBarrelsConfiguration _missionConfiguration;
	private int _internalProgression;

	public FallBarrels(FallBarrelsConfiguration missionConfiguration) : base(missionConfiguration)
	{
		_missionConfiguration = missionConfiguration;
		MaxProgression = _missionConfiguration.BarrelsAmount;
	}

	public override void Init()
	{
		if (_missionConfiguration.SingleBall)
		{
			EventSystemService.Instance.Subscribe<BallShotEvent>(OnBallShot);
		}
		EventSystemService.Instance.Subscribe<BarrelFallenEvent>(OnBarrelFallen);
	}

	private void OnBallShot(BallShotEvent obj)
	{
		_internalProgression = 0;
	}

	private void OnBarrelFallen(BarrelFallenEvent obj)
	{
		++_internalProgression;

		if (!_missionConfiguration.SingleBall || _internalProgression > CurrentProgression)
		{
			CurrentProgression = _internalProgression;
		}
		
		if (!_missionConfiguration.SingleBall && CurrentProgression == MaxProgression)
		{
			Release();
		}
	}

	public override void Release()
	{
		if (_missionConfiguration.SingleBall)
		{
			EventSystemService.Instance.Unsubscribe<BallShotEvent>(OnBallShot);
		}
		EventSystemService.Instance.Unsubscribe<BarrelFallenEvent>(OnBarrelFallen);
	}

	public override string PrintProgression()
	{
		return $"{(_missionConfiguration.SingleBall ? "THE BEST: " : "")}{CurrentProgression}/{MaxProgression}";
	}

	public override bool IsCompleted()
	{
		return CurrentProgression >= MaxProgression;
	}
}
