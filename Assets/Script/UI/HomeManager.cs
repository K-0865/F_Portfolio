using System;
using UnityEngine;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
	[SerializeField] private bool still = false;
	[SerializeField] private int toggle = 1;
	
	[SerializeField] private Image background;
	[SerializeField] private Image Character;
	[SerializeField] private GameObject menuobject;
	[SerializeField] private GameObject other;
	public void Start()
	{
	}

	public void StillSwitch()
	{
		if (still)
		{
			switch (toggle)
			{
				case 1:
					background.sprite = Resources.Load<Sprite>("MainMenu/1010_Still");
					break;
				case 2:
					background.sprite = Resources.Load<Sprite>("MainMenu/1120_Ruby_Sapphire");
					break;
				case 3:
					background.sprite = Resources.Load<Sprite>("MainMenu/1000_set");
					break;
				default:
					break;
			}
			Character.enabled = true;
			still = false;
		}
		else
		{
			switch (toggle)
			{
				case 1:
					Character.sprite = Resources.Load<Sprite>("MainMenu/1010_Ruby");
					toggle = 2;
					break;
				case 2:
					Character.sprite = Resources.Load<Sprite>("MainMenu/1020_Sapphire");
					toggle = 3;
					break;
				case 3:
					Character.sprite = Resources.Load<Sprite>("MainMenu/1210_Ruby");
					toggle = 1;
					break;
				default:
					break;
			}
			Character.enabled = false;
			still = true;
		}
	}

	public void CharacterChangeR()
	{
		switch (toggle)
		{
			case 1:
				Character.sprite = Resources.Load<Sprite>("MainMenu/1010_Ruby");
				toggle = 2;
				break;
			case 2:
				Character.sprite = Resources.Load<Sprite>("MainMenu/1020_Sapphire");
				toggle = 3;
				break;
			case 3:
				Character.sprite = Resources.Load<Sprite>("MainMenu/1210_Ruby");
				toggle = 1;
				break;
			default:
				break;
		}
	}
	public void CharacterChangeL()
	{
		switch (toggle)
		{
			case 1:
				Character.sprite = Resources.Load<Sprite>("MainMenu/1210_Ruby");
				toggle = 3;
				break;
			case 2:
				Character.sprite = Resources.Load<Sprite>("MainMenu/1210_Ruby");
				toggle = 1;
				break;
			case 3:
				Character.sprite = Resources.Load<Sprite>("MainMenu/1210_Ruby");
				toggle = 2;
				break;
			default:
				break;
		}
	}
}
