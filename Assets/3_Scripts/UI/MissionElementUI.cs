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
	[SerializeField]
	private GameObject _coinsLabel;
	[SerializeField]
	private TMP_Text _coinsText;
	[SerializeField]
	private GameObject _diamondsLabel;
	[SerializeField]
	private TMP_Text _diamondsText;
	[SerializeField] 
	private Image _background;
	[SerializeField] 
	private Color _inProgressColor;
	[SerializeField] 
	private Color _completedColor;

	private void OnEnable()
	{
		_coinsLabel.SetActive(false);
		_coinsText.gameObject.SetActive(false);
		
		_diamondsLabel.SetActive(false);
		_diamondsText.gameObject.SetActive(false);
	}

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

	public void SetCoins(int amount)
	{
		_coinsText.SetText(amount.ToString());
		_coinsLabel.SetActive(true);
		_coinsText.gameObject.SetActive(true);
	}

	public void SetDiamonds(int amount)
	{
		_diamondsText.SetText(amount.ToString());
		_diamondsLabel.SetActive(true);
		_diamondsText.gameObject.SetActive(true);
	}

	public void SetBackground(bool isCompleted)
	{
		_background.color = isCompleted ? _completedColor : _inProgressColor;
	}
}
