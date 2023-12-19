using UnityEngine;

public class MissionsButton : MonoBehaviour
{
	private void Start()
	{
		gameObject.SetActive(RemoteConfig.MISSIONS_ENABLED);
	}
}
