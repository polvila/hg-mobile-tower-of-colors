using System;
using UnityEngine;

[Serializable]
public class RewardAmount
{
	[SerializeField] 
	private int _amount;
	[SerializeField] 
	private RewardId _rewardId;

	public int Amount => _amount;
	public RewardId RewardId => _rewardId;
}

public class MissionConfiguration : ScriptableObject
{
	[SerializeField] 
	private string _description;

	[SerializeField] 
	private RewardAmount[] _rewards;

	public string Description => _description;
	public RewardAmount[] Rewards => _rewards;
}