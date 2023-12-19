using UnityEngine;

public class MissionsUI : MonoBehaviour
{
	[SerializeField] 
	private MissionElementUI[] missionElements;

	private void OnEnable()
	{
		var activeMissions = MissionsManager.Instance.ActiveMissions;
		for(var i = 0; i < missionElements.Length; i++)
		{
			var activeMission = activeMissions[i];
			var missionElement = missionElements[i];
			missionElement.SetDescription(activeMission.MissionConfiguration.Description);
			missionElement.SetProgression(activeMission.PrintProgression());
			missionElement.SetProgressionBar(activeMission.CurrentProgression, activeMission.MaxProgression);
		}
	}
}
