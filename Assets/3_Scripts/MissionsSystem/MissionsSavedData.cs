using System;

[Serializable]
public class MissionSavedData
{
	public string ID;
	public int Progression;
}

[Serializable]
public class MissionsSavedData
{
	public MissionSavedData[] SavedArrayData;
}
