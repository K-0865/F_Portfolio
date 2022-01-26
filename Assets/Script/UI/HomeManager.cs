using System;
using UnityEngine;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
	[SerializeField] private bool still = false;
	[SerializeField] private bool FullScreen = false;
	[SerializeField] private int toggle = 1;
	
	[SerializeField] private Image background;
	[SerializeField] private Image Character;
	[SerializeField] private GameObject menuobject;
	[SerializeField] private GameObject other;
	[SerializeField] private GameObject returnobject;

	public void ScreenSwitch()
	{
		if (FullScreen)
		{
			if (still)
			{
				Character.enabled = false;
			}
			menuobject.SetActive(false);
			other.SetActive(false);
			returnobject.SetActive(true);
			FullScreen = false;
		}
		else
		{
			if (still == false)
			{
				Character.enabled = true;
			}
			menuobject.SetActive(true);
			other.SetActive(true);
			returnobject.SetActive(false);
			FullScreen = true;
		}
	}
	
	public void StillSwitch()
	{
		if (still)
		{
			still = false;
			switch (toggle)
			{
				case 1:
					Character.sprite = Resources.Load<Sprite>("Home/1010_Ruby");
					background.sprite = Resources.Load<Sprite>("Home/Barracks");
					break;
				case 2:
					Character.sprite = Resources.Load<Sprite>("Home/1020_Sapphire");
					background.sprite = Resources.Load<Sprite>("Home/DSC00549_1");
					break;
				case 3:
					Character.sprite = Resources.Load<Sprite>("Home/1030_Emerald");
					background.sprite = Resources.Load<Sprite>("Home/DSC00295");
					break;
				default:
					break;
			}
			Character.enabled = true;
		}
		else
		{
			still = true;
			switch (toggle)
			{
				case 1:
					background.sprite = Resources.Load<Sprite>("Home/1010_Still");
					break;
				case 2:
					background.sprite = Resources.Load<Sprite>("Home/black");
					break;
				case 3:
					background.sprite = Resources.Load<Sprite>("Home/black");
					break;
				default:
					break;
			}
			Character.enabled = false;
		}
	}

	public void CharacterChangeR()
	{
		switch (toggle)
		{
			case 1:
				Character.sprite = Resources.Load<Sprite>("Home/1020_Sapphire");
				background.sprite = Resources.Load<Sprite>("Home/DSC00549_1");
				toggle = 2;
				break;
			case 2:
				Character.sprite = Resources.Load<Sprite>("Home/1030_Emerald");
				background.sprite = Resources.Load<Sprite>("Home/DSC00295");
				toggle = 3;
				break;
			case 3:
				Character.sprite = Resources.Load<Sprite>("Home/1010_Ruby");
				background.sprite = Resources.Load<Sprite>("Home/Home1");
				toggle = 1;
				break;
			default:
				break;
		}
		if(still){
			switch (toggle)
			{
				case 1:
					background.sprite = Resources.Load<Sprite>("Home/1010_Still");
					break;
				case 2:
					background.sprite = Resources.Load<Sprite>("Home/black");
					break;
				case 3:
					background.sprite = Resources.Load<Sprite>("Home/black");
					break;
				default:
					break;
			}
		}
	}
	public void CharacterChangeL()
	{
		switch (toggle)
		{
			case 1:
				Character.sprite = Resources.Load<Sprite>("Home/1030_Emerald");
				background.sprite = Resources.Load<Sprite>("Home/DSC00295");
				toggle = 3;
				break;
			case 2:
				Character.sprite = Resources.Load<Sprite>("Home/1010_Ruby");
				background.sprite = Resources.Load<Sprite>("Home/Home1");
				toggle = 1;
				break;
			case 3:
				Character.sprite = Resources.Load<Sprite>("Home/1020_Sapphire");
				background.sprite = Resources.Load<Sprite>("Home/DSC00549_1");
				toggle = 2;
				break;
			default:
				break;
		}
		
		if(still){
			switch (toggle)
			{
				case 1:
					background.sprite = Resources.Load<Sprite>("Home/1010_Still");
					break;
				case 2:
					background.sprite = Resources.Load<Sprite>("Home/black");
					break;
				case 3:
					background.sprite = Resources.Load<Sprite>("Home/black");
					break;
				default:
					break;
			}
		}
	}
}
