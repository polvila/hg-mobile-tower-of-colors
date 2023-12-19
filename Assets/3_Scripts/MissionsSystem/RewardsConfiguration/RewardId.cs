using UnityEngine;

[CreateAssetMenu(menuName = "Rewards Configuration/Create RewardId", fileName = "RewardId", order = 0)]
public class RewardId : ScriptableObject
{
	[SerializeField] private string _value;

	public string Value => _value;
}
