using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
	[SerializeField] GameObject BackGroundImage;
	[SerializeField] GameObject PlayerStatus;
	[SerializeField] GameObject Mask_Character;
	[SerializeField] GameObject Text_Box;
	[SerializeField] GameObject Banner;
	[SerializeField] GameObject MiniButton_Down;
	[SerializeField] GameObject MiniButton_Top;
	[SerializeField] GameObject MenuObject;
	[SerializeField] GameObject FullScreenReturn;
	[SerializeField] GameObject ResourceTank;

	//[SerializeField] private UnityEngine.UI.Button buttontest;
	[SerializeField] private UnityEngine.UI.Image Back;
	[SerializeField] private UnityEngine.UI.Image Charcter;

	private GameObject Image;
	private GameObject RArrow;
	private GameObject LArrow;

	private bool Screen_switch = true;

	private int Toggle;
	private int CharaChange;

	private void Awake()
	{
		//Image = BackGroundImage.transform.Find("Image").gameObject;
		//RArrow = Image.transform.Find("Image").gameObject;
		//LArrow = Image.transform.Find("Image").gameObject;
	}

	private void InitializeHome()
	{

	}

	public void FullScreen()
	{
		//buttontest.onClick.AddListener();
		Debug.Log("FullScreen");
		if (Screen_switch)
		{
			RArrow.SetActive(false);
			LArrow.SetActive(false);
			PlayerStatus.SetActive(false);
			Text_Box.SetActive(false);
			Banner.SetActive(false);
			MiniButton_Down.SetActive(false);
			MiniButton_Top.SetActive(false);
			MenuObject.SetActive(false);
			FullScreenReturn.SetActive(true);
			Screen_switch = false;
			Debug.Log(Screen_switch);
			if (Toggle % 10 == 0)
			{
				Mask_Character.SetActive(false);
			}
		}
		else
		{
			RArrow.SetActive(true);
			LArrow.SetActive(true);
			PlayerStatus.SetActive(true);
			Text_Box.SetActive(true);
			Banner.SetActive(true);
			MiniButton_Down.SetActive(true);
			MiniButton_Top.SetActive(true);
			MenuObject.SetActive(true);
			FullScreenReturn.SetActive(false);
			Screen_switch = true;
			Debug.Log(Screen_switch);
			if (Toggle % 10 == 0)
			{
				Mask_Character.SetActive(true);
			}
		}
	}

	public void SwitchBackGround()
	{
		InitializeHome();
		switch (Toggle)
		{
			case 1:
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().Still1;
				Back.SetNativeSize();
				Toggle = 2;
				break;
			case 2:
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().Still2;
				Back.SetNativeSize();
				Toggle = 10;
				break;
			case 10:
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().BackImage1;
				Back.SetNativeSize();
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().Charcter1;
				Back.SetNativeSize();
				Toggle = 20;
				break;
			case 20:
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().BackImage2;
				Back.SetNativeSize();
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().Charcter2;
				Back.SetNativeSize();
				Toggle = 1;
				break;
			default:
				break;
		}
	}
}
