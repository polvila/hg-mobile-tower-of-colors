public class PlayGames : Mission
{
	private readonly PlayGamesConfiguration _missionConfiguration;

	public PlayGames(PlayGamesConfiguration missionConfiguration) : base(missionConfiguration)
	{
		_missionConfiguration = missionConfiguration;
		MaxProgression = _missionConfiguration.GamesAmount;
	}

	public override void Init()
	{
		EventSystemService.Instance.Subscribe<LevelStartedEvent>(OnLevelStarted);
	}

	private void OnLevelStarted(LevelStartedEvent levelStartedEvent)
	{
		++CurrentProgression;
	}

	public override void Release()
	{
		EventSystemService.Instance.Unsubscribe<LevelStartedEvent>(OnLevelStarted);
	}

	public override string PrintProgression()
	{
		return $"{CurrentProgression}/{MaxProgression}";
	}

	public override bool IsCompleted()
	{
		return CurrentProgression == MaxProgression;
	}
}
