using UnityEngine;

public class CharacterData : MonoBehaviour
{
    //データテーブルからキャラクターデータを読み込む
    [SerializeField] private DataTable_pre data = null;

    //[SerializeField]
    private int id;

    [SerializeField] public CharacterTable CharacterStatus;
    
    //生成する為にステータスを保管する
    void Awake()
    {
        id = this.gameObject.GetComponentInParent<Character_Present_Data>()._ID;
        for (int i = 0; i < data.Character.Count; i++)
        {
            if ((int)data.Character[i].ID == id)
            {
                CharacterStatus = data.Character[i];
                break;
            }
        }
        //this.gameObject.tag = this.transform.parent.tag;
        
    }

}
