using System;
using System.Collections.Generic;

public class MissionFactory
{
	private readonly Dictionary<Type, Func<MissionConfiguration, Mission>> _missionCreators = new();

	public MissionFactory()
	{
		// Register your MissionConfiguration types and their corresponding Mission implementations
		Register<BeatALevelUsingLessThanBallsConfiguration, BeatALevelUsingLessThanBalls>(
			config => new BeatALevelUsingLessThanBalls(config));
		Register<CompleteLevelsConfiguration, CompleteLevels>(
			config => new CompleteLevels(config));
		Register<ExplodeBarrelsConfiguration, ExplodeBarrels>(
			config => new ExplodeBarrels(config));
		Register<FallBarrelsConfiguration, FallBarrels>(
			config => new FallBarrels(config));
		Register<PlayGamesConfiguration, PlayGames>(
			config => new PlayGames(config));
		// Add more registrations as needed
	}

	private void Register<TConfig, TMission>(Func<TConfig, Mission> creator) where TConfig : MissionConfiguration where TMission : Mission
	{
		_missionCreators[typeof(TConfig)] = config => creator((TConfig)config);
	}

	public Mission Create(MissionConfiguration missionConfiguration)
	{
		if (missionConfiguration == null)
		{
			throw new ArgumentNullException(nameof(missionConfiguration));
		}

		var configType = missionConfiguration.GetType();

		if (_missionCreators.TryGetValue(configType, out var creator))
		{
			return creator.Invoke(missionConfiguration);
		}

		throw new InvalidOperationException($"No registration found for MissionConfiguration type: {configType}");
	}
}
