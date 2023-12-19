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
	[SerializeField] 
	private DifficultyType _difficultyType;

	public string Description => _description;
	public RewardAmount[] Rewards => _rewards;
	public DifficultyType DifficultyType => _difficultyType;
}