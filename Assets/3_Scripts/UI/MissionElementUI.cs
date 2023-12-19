using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionElementUI : MonoBehaviour
{
	[SerializeField] 
	private TMP_Text _descriptionText;
	[SerializeField]
	private TMP_Text _progressionText;
	[SerializeField]
	private Slider _progressionBar;

	public void SetDescription(string text)
	{
		_descriptionText.SetText(text);
	}

	public void SetProgression(string text)
	{
		_progressionText.SetText(text);
	}

	public void SetProgressionBar(int current, int max)
	{
		_progressionBar.maxValue = max;
		_progressionBar.value = current;
	}
}
