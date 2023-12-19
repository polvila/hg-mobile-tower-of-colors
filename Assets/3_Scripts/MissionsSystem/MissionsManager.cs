using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MissionsManager : Singleton<MissionsManager>
{
	[SerializeField] private MissionConfiguration[] _missionConfigurations;
	[SerializeField] private int _activeMissionsAmount;

	private MissionFactory _missionFactory;
	private Mission[] _activeMissions;

	public Mission[] ActiveMissions => _activeMissions;

	private void Awake()
	{
		if (!RemoteConfig.MISSIONS_ENABLED)
		{
			return;
		}
		
		_missionFactory = new MissionFactory();
		_activeMissions = new Mission[_activeMissionsAmount];
		
		if (!LoadMissions())
		{
			SetupNewRandomActiveMissions();
		}

		InitMissions();
	}

	public void ReleaseMissions()
	{
		if (!RemoteConfig.MISSIONS_ENABLED)
		{
			return;
		}
		
		foreach (var activeMission in _activeMissions)
		{
			activeMission.Release();
		}
		SaveMissions();
	}

	private void SaveMissions()
	{
		var arrayData = new MissionSavedData[_activeMissionsAmount];
		
		for (var i = 0; i < _activeMissionsAmount; ++i)
		{
			var activeMission = _activeMissions[i];
			arrayData[i] = new MissionSavedData
			{
				ID = activeMission.MissionConfiguration.name, 
				Progression = activeMission.CurrentProgression
			};
		}
		
		SaveData.MissionsSavedData = new MissionsSavedData { SavedArrayData = arrayData };
	}

	private bool LoadMissions()
	{
		var savedMissions = SaveData.MissionsSavedData;
		if (savedMissions.SavedArrayData == null || savedMissions.SavedArrayData.Length != _activeMissionsAmount)
		{
			return false;
		}
		
		for (var i = 0; i < _activeMissionsAmount; ++i)
		{
			foreach (var missionConfiguration in _missionConfigurations)
			{
				if (savedMissions.SavedArrayData[i].ID != missionConfiguration.name) continue;
				_activeMissions[i] = _missionFactory.Create(missionConfiguration);
				_activeMissions[i].CurrentProgression = savedMissions.SavedArrayData[i].Progression;
			}
		}

		return true;
	}

	private void SetupNewRandomActiveMissions()
	{
		var randomIndex = Enumerable.Range(0, _missionConfigurations.Length).OrderBy(x => Random.value).ToList();
		for (var i = 0; i < _activeMissionsAmount; ++i)
		{
			var mission = _missionFactory.Create(_missionConfigurations[randomIndex[i]]);
			_activeMissions[i] = mission;
		}
		SaveMissions();
	}

	private void InitMissions()
	{
		var allMissionsCompleted = true;
		for (var i = 0; i < _activeMissionsAmount; ++i)
		{
			var mission = _activeMissions[i];
			if (!mission.IsCompleted())
			{
				mission.Init();
				allMissionsCompleted = false;
			}
		}

		if (allMissionsCompleted)
		{
			SetupNewRandomActiveMissions();
			InitMissions();
		}
	}
}