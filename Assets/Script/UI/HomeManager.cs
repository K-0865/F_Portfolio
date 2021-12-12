using System.Collections;
using System.Collections.Generic;
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
	[SerializeField] private UnityEngine.UI.Image Charcater;

	[SerializeField] private GameObject RArrow;
	[SerializeField] private GameObject LArrow;

	private bool Screen_switch = true;

	[SerializeField] private int Toggle = 1;
	private int CharaChange;
	
	//クリックされるたびにUIの表示、非表示を切り替える
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
			
			//立ち絵がある場合キャラクターを非表示にする
			if (Toggle % 10 != 0)
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
			
			//立ち絵がある場合キャラクターを非表示にする
			if (Toggle % 10 != 0)
			{
				Mask_Character.SetActive(true);
			}
		}
	}
	
	//背景かスチルを別キャラクターに切り替える
	//右送りにトグル(動作不安定)
	//2桁がstill,1桁が背景＋立ち絵
	public void SwitchBackGroundR()
	{
		switch (Toggle)
		{
			case 10:
				Debug.Log("R10");
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().Still1;
				Back.SetNativeSize();
				Mask_Character.SetActive(false);
				ResourceTank.GetComponent<ResourceTank>().TextBox1.SetActive(false);
				Toggle = 20;
				break;
			case 20:
				Debug.Log("R20");
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().Still2;
				Back.SetNativeSize();
				Mask_Character.SetActive(false);
				ResourceTank.GetComponent<ResourceTank>().TextBox2.SetActive(false);
				Toggle = 30;
				break;
			case 30:
				Debug.Log("R30");
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().Still3;
				Back.SetNativeSize();
				Mask_Character.SetActive(false);
				ResourceTank.GetComponent<ResourceTank>().TextBox3.SetActive(false);
				Toggle = 10;
				break;
			case 1:
				Debug.Log("R1");
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().BackImage1;
				Back.SetNativeSize();
				Charcater.sprite = ResourceTank.GetComponent<ResourceTank>().Charcater1;
				Charcater.SetNativeSize();
				Mask_Character.SetActive(true);
				ResourceTank.GetComponent<ResourceTank>().TextBox1.SetActive(true);
				Toggle = 2;
				break;
			case 2:
				Debug.Log("R2");
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().BackImage2;
				Back.SetNativeSize();
				Charcater.sprite = ResourceTank.GetComponent<ResourceTank>().Charcater2;
				Charcater.SetNativeSize();
				Mask_Character.SetActive(true);
				ResourceTank.GetComponent<ResourceTank>().TextBox2.SetActive(true);
				Toggle = 3;
				break;
			case 3:
				Debug.Log("R3");
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().BackImage3;
				Back.SetNativeSize();
				Charcater.sprite = ResourceTank.GetComponent<ResourceTank>().Charcater3;
				Charcater.SetNativeSize();
				Mask_Character.SetActive(true);
				ResourceTank.GetComponent<ResourceTank>().TextBox3.SetActive(true);
				Toggle = 1;
				break;
			default:
				break;
		}
	}
	
	//背景かスチルを別キャラクターに切り替える
	//左送りにトグル(動作不安定)
	//2桁がstill,1桁が背景＋立ち絵
	public void SwitchBackGroundL()
	{
		switch (Toggle)
		{
			case 10:
				Debug.Log("L10");
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().Still1;
				Back.SetNativeSize();
				Mask_Character.SetActive(false);
				ResourceTank.GetComponent<ResourceTank>().TextBox1.SetActive(false);
				Toggle = 30;
				break;
			case 20:
				Debug.Log("L20");
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().Still2;
				Back.SetNativeSize();
				Mask_Character.SetActive(false);
				ResourceTank.GetComponent<ResourceTank>().TextBox2.SetActive(false);
				Toggle = 10;
				break;
			case 30:
				Debug.Log("L30");
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().Still3;
				Back.SetNativeSize();
				Mask_Character.SetActive(false);
				ResourceTank.GetComponent<ResourceTank>().TextBox3.SetActive(false);
				Toggle = 20;
				break;
			case 1:
				Debug.Log("L1");
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().BackImage1;
				Back.SetNativeSize();
				Charcater.sprite = ResourceTank.GetComponent<ResourceTank>().Charcater1;
				Charcater.SetNativeSize();
				Mask_Character.SetActive(true);
				ResourceTank.GetComponent<ResourceTank>().TextBox1.SetActive(true);
				Toggle = 2;
				break;
			case 2:
				Debug.Log("L2");
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().BackImage2;
				Back.SetNativeSize();
				Charcater.sprite = ResourceTank.GetComponent<ResourceTank>().Charcater2;
				Charcater.SetNativeSize();
				Mask_Character.SetActive(true);
				ResourceTank.GetComponent<ResourceTank>().TextBox2.SetActive(true);
				Toggle = 3;
				break;
			case 3:
				Debug.Log("L3");
				Back.sprite = ResourceTank.GetComponent<ResourceTank>().BackImage3;
				Back.SetNativeSize();
				Charcater.sprite = ResourceTank.GetComponent<ResourceTank>().Charcater3;
				Charcater.SetNativeSize();
				Mask_Character.SetActive(true);
				ResourceTank.GetComponent<ResourceTank>().TextBox3.SetActive(true);
				Toggle = 1;
				break;
			default:
				break;
		}
	}

	//スチルと背景＋立ち絵を切り替える
	//2桁がstill,1桁が背景＋立ち絵（動作不安定）
	public void SwitchStill()
	{
		if (Toggle == 1)
		{
			Back.sprite = ResourceTank.GetComponent<ResourceTank>().BackImage1;
			Back.SetNativeSize();
			Charcater.sprite = ResourceTank.GetComponent<ResourceTank>().Charcater1;
			Charcater.SetNativeSize();
			Mask_Character.SetActive(true);
			Toggle = 10;
		}
		else if(Toggle == 10)
		{
			Back.sprite = ResourceTank.GetComponent<ResourceTank>().Still1;
			Back.SetNativeSize();
			Mask_Character.SetActive(false);
			Toggle = 1;
		}
		
		if (Toggle == 2)
		{
			Back.sprite = ResourceTank.GetComponent<ResourceTank>().BackImage2;
			Back.SetNativeSize();
			Charcater.sprite = ResourceTank.GetComponent<ResourceTank>().Charcater2;
			Charcater.SetNativeSize();
			Mask_Character.SetActive(true);
			Toggle = 20;
		}
		else if(Toggle == 20)
		{
			Back.sprite = ResourceTank.GetComponent<ResourceTank>().Still3;
			Back.SetNativeSize();
			Mask_Character.SetActive(false);
			Toggle = 2;
		}
		
		if (Toggle == 3)
		{
			Back.sprite = ResourceTank.GetComponent<ResourceTank>().BackImage3;
			Back.SetNativeSize();
			Charcater.sprite = ResourceTank.GetComponent<ResourceTank>().Charcater3;
			Charcater.SetNativeSize();
			Mask_Character.SetActive(true);
			Toggle = 30;
		}
		else if(Toggle == 30)
		{
			Back.sprite = ResourceTank.GetComponent<ResourceTank>().Still3;
			Back.SetNativeSize();
			Mask_Character.SetActive(false);
			Toggle = 3;
		}
	}
}
