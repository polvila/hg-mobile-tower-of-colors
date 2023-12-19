
public abstract class Mission
{
	public MissionConfiguration MissionConfiguration { get; }

	public int CurrentProgression { get; set; }
	public int MaxProgression { get; protected set; }

	protected Mission(MissionConfiguration missionConfiguration, int currentProgression = 0)
	{
		MissionConfiguration = missionConfiguration;
		CurrentProgression = currentProgression;
	}

	public abstract void Init();
	public abstract void Release();
	public abstract string PrintProgression();
	public abstract bool IsCompleted();
}
