public class CompleteLevels : Mission
{
	private readonly CompleteLevelsConfiguration _missionConfiguration;

	public CompleteLevels(CompleteLevelsConfiguration missionConfiguration) : base(missionConfiguration)
	{
		_missionConfiguration = missionConfiguration;
		MaxProgression = _missionConfiguration.LevelsAmount;
	}

	public override void Init()
	{
		EventSystemService.Instance.Subscribe<LevelCompletedEvent>(OnLevelCompleted);
	}

	private void OnLevelCompleted(LevelCompletedEvent levelCompletedEvent)
	{
		++CurrentProgression;
	}

	public override void Release()
	{
		EventSystemService.Instance.Unsubscribe<LevelCompletedEvent>(OnLevelCompleted);
	}

	public override string PrintProgression()
	{
		return $"{CurrentProgression}/{MaxProgression}";
	}

	public override bool IsCompleted()
	{
		return CurrentProgression == _missionConfiguration.LevelsAmount;
	}
}
