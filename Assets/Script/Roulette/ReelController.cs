using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelController : MonoBehaviour {
	public GameObject GM;
	private GameController gc;
	private Roulette Rl;

	public int line_ID = 0;	//リールのid
	//private GameObject[] imgobj; //絵柄のプレハブを格納
	public List<GameObject> imgobj; //絵柄のプレハブを格納
	[SerializeField] int[] lines = new int[3];	//リール停止時に見えている絵柄のid(imgobjの番号)を格納
	int[] current = {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};	//配列に全体の絵柄idを格納
	[SerializeField]
	GameObject[] tmp_obj = new GameObject[18];
	Transform[] img_pos = new Transform[18]; 

	Transform pos;	//リールのTransform
	Vector3 initpos; //リールの初期位置
	public bool first = true;
	public int speed; //リールの回転速度
	bool turn = false; //回転させるか否か
	int flg = 0;
	private int Target_Num = 0;
	private BattleManager _battleManager;
	void Awake(){
		_battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
		for (int i = 0; i < _battleManager._AliveID.Count; i++)
		{
			imgobj.Add((GameObject)Resources.Load("Emblem/"+_battleManager._AliveID[i]));
		}

		if (_battleManager.boss)
		{
			imgobj.Add((GameObject)Resources.Load("Emblem/"+104000));

		}
		pos = GetComponent<Transform> ();
		initpos = pos.localPosition;
		for (int i = 0; i < 18; i++) {
			Vector3 pos = new Vector3 (0.0f,-0.9f + (0.9f*i),0.0f);
			int tmp = Random.Range (0, imgobj.Count);//絵柄をランダムで生成

			if (i != 0 && i < 9) {
				while (current [i - 1] == tmp) { //前の絵柄と同じにならないように再抽選
					tmp = Random.Range (0, imgobj.Count);
				}
				//Debug.Log(tmp);
			} else if (i == 9)
			{
				tmp = 0;
			}else if (i == 10)
			{
				tmp = 1;
			}else if (i == 11)
			{
				tmp = 2;
				if (tmp > imgobj.Count-1)
				{
					while (current [i - 1] == tmp || tmp > imgobj.Count-1) { //前の絵柄と同じにならないように再抽選
						tmp = Random.Range (0, imgobj.Count);
					}
				}
			}else if (i == 12)
			{
				tmp = 3;
				if (tmp > imgobj.Count-1)
				{
					while (current [i - 1] == tmp||tmp > imgobj.Count-1) { //前の絵柄と同じにならないように再抽選
						tmp = Random.Range (0, imgobj.Count);
					}
				}
			}else if (i == 13)
			{
				tmp = 4;
				if (tmp > imgobj.Count-1)
				{
					while (current [i - 1] == tmp ||tmp > imgobj.Count-1) { //前の絵柄と同じにならないように再抽選
						tmp = Random.Range (0, imgobj.Count);
					}
				}
			}else if (i == 14)
			{
				tmp = 5;
				if (tmp > imgobj.Count-1)
				{
					while (current [i - 1] == tmp || tmp > imgobj.Count-1) { //前の絵柄と同じにならないように再抽選
						tmp = Random.Range (0, imgobj.Count);
					}
				}
			}else if (i == 15) {
				tmp = current [0];
			} else if (i == 16) {
				tmp = current [1];
			} else if (i == 17) {
				tmp = current [2];
			}

			current[i] = tmp;
			tmp_obj [i] = (GameObject)Instantiate (imgobj[tmp]); //プレハブからGameObjectを生成
			tmp_obj [i].transform.SetParent (transform, false); //リールのオブジェクトを親にする
			img_pos [i] = tmp_obj[i].GetComponent<Transform>();
			img_pos [i].localPosition = pos;
		}
		gc = GM.GetComponent<GameController>();
		Rl = GM.GetComponent<Roulette>();
		
	}

	// Update is called once per frame
	void Update()
	{

		if (pos.localPosition.y < -13.5*2)
		{
			pos.localPosition = initpos;
		}
		
		if (turn)
		{
			pos.localPosition = new Vector3(pos.localPosition.x, pos.localPosition.y - (speed * Time.deltaTime),
				pos.localPosition.z);
		}
		else
		{
			// if (pos.localPosition.y % 0.9f < -0.06f)
			// {
			// 	//絵柄をマスで固定するために回転スピードを弱める
			// 	flg = 0;
			// 	pos.localPosition = new Vector3(pos.localPosition.x, pos.localPosition.y - 0.03f, pos.localPosition.z);
			//
			// }
			// else
			// {
				int c = -1 * (int) (pos.localPosition.y / 1.8); //何マス回転（移動）したか
				Target_Num = Rl.ReturnTarget(line_ID);
				Vector3 target_pos = Vector3.zero;
				for (int i = 0; i < current.Length; i++)
				{
					if (current[i+1] == Target_Num)
					{
						target_pos = img_pos[i + 1].localPosition;
				
						break;
					}
				}

				
				//Debug.Log(speed_f + ": Speed_f : L:"+ line_ID);
				//Target_Num = 1;
				if (pos.localPosition.y < -19.8f)
				{
					// flg = 0;
					// pos.localPosition = new Vector3(pos.localPosition.x, pos.localPosition.y - 0.03f,
					// 	pos.localPosition.z);
					flg = 0;
					pos.localPosition = new Vector3(pos.localPosition.x, pos.localPosition.y - (speed * Time.deltaTime),
						pos.localPosition.z);
				}else{

				if (current[(c + 1)] != Target_Num && !first)
				{
					flg = 0;
					// Debug.Log(Target_Num + "Line" + line_ID);
					// Debug.Log(target_pos.y + "POSLine" + line_ID);
					pos.localPosition = new Vector3(pos.localPosition.x, -1 * (target_pos.y*2), pos.localPosition.z);
					// pos.localPosition = new Vector3(pos.localPosition.x, pos.localPosition.y - (0.03f),
					// 	pos.localPosition.z);
				}
				else
				{
					if (flg == 0)
					{

						//トリガー
						flg = 1;
						int under = -1 * (int) (pos.localPosition.y / 1.8); //何マス回転（移動）したか

						for (int i = 0; i < 3; i++)
						{
							//Debug.Log(under + "under");
							lines[i] = current[(under) + i]; //絵柄を特定
						}

						//値送り、絵柄配列を送る[0]が一番下の絵柄[1]が真ん中[2]が一番上
						if (line_ID == 0)
						{
							gc.SetLineR(lines);
						}
						else if (line_ID == 1)
						{
							gc.SetLineC(lines);
						}
						else
						{
							gc.SetLineL(lines);
						}
					}
				}
				//}
				// if (pos.localPosition.y % 0.9f < -0.06f) {	//絵柄をマスで固定するために回転スピードを弱める
				// 	flg = 0;
				// 	pos.localPosition = new Vector3 (pos.localPosition.x, pos.localPosition.y - 0.03f, pos.localPosition.z); 
				// } else {	//固定完了
				// 	if (flg == 0) {	//トリガー
				// 		flg = 1;
				// 		int under = -1 * (int)(pos.localPosition.y / 0.9);	//何マス回転（移動）したか
				//
				// 		for (int i = 0; i < 3; i++) {
				// 			lines [i] = current [(under) + i];	//絵柄を特定
				// 		}
				// 		//値送り、絵柄配列を送る[0]が一番下の絵柄[1]が真ん中[2]が一番上
				// 		if (line_ID == 0) {
				// 			gc.SetLineR (lines);
				// 		} else if (line_ID == 1) {
				// 			gc.SetLineC (lines);
				// 		} else {
				// 			gc.SetLineL (lines);
				// 		}
				//
				// 	}
				// }

			}
		}
	}

	//リールを止める
	public int Reel_Stop(){
		turn = false;
		gc.Stopbt_f (line_ID);
		return line_ID;
	}

	//リールが動いているかどうか
	public void Reel_Move(){
		turn = true;
		flg = 0;
	}

}