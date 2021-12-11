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

	private GameObject Image;
	private GameObject RArrow;
	private GameObject LArrow;

	private bool Screen_switch = true;

	private int Toggle;

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
		}
		else
		{
			RArrow.SetActive(true);
			LArrow.SetActive(true);
			PlayerStatus.SetActive(true);
			Mask_Character.SetActive(true);
			Text_Box.SetActive(true);
			Banner.SetActive(true);
			MiniButton_Down.SetActive(true);
			MiniButton_Top.SetActive(true);
			MenuObject.SetActive(true);
			FullScreenReturn.SetActive(false);
			Screen_switch = true;
			Debug.Log(Screen_switch);
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
				Toggle = 1;
				break;
		}

	}
}
