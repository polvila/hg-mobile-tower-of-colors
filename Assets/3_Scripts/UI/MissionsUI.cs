using UnityEngine;

public class MissionsUI : MonoBehaviour
{
	[SerializeField] 
	private MissionElementUI[] _missionElements;
	[SerializeField] 
	private RewardId _coins;
	[SerializeField] 
	private RewardId _diamonds;

	private void OnEnable()
	{
		var activeMissions = MissionsManager.Instance.ActiveMissions;
		for(var i = 0; i < _missionElements.Length; i++)
		{
			var activeMission = activeMissions[i];
			var missionElement = _missionElements[i];
			missionElement.SetDescription(activeMission.MissionConfiguration.Description);
			missionElement.SetProgression(activeMission.PrintProgression());
			missionElement.SetProgressionBar(activeMission.CurrentProgression, activeMission.MaxProgression);

			foreach (var reward in activeMission.MissionConfiguration.Rewards)
			{
				if (reward.RewardId.Value == _coins.Value)
				{
					missionElement.SetCoins(reward.Amount);
				}
				else if (reward.RewardId.Value == _diamonds.Value)
				{
					missionElement.SetDiamonds(reward.Amount);
				}
			}
		}
	}
}
