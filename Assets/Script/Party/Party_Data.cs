using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Party_Data : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _PartyScreen;
    [SerializeField]
    private GameObject _CharacterScreen;
    [SerializeField]
    private List<Image> _Party_POS_IMG;
    [SerializeField] 
    private List<Image> _Party_Pos_Frame;
    [SerializeField] 
    private List<Image> _Party_Pos_backGround;
    private int _TryChange;
    
    [SerializeField] private DataTable_pre data = null;
    private List<int> CharacerId = null;
    private List<int> Rarity = null;

    void Start()
    {
        for (int i = 0; i < _Party_POS_IMG.Count; i++)
        {
            if (GManager.instance.character_pos[i] != 0)
            {
                _Party_POS_IMG[i].sprite = Resources.Load<Sprite>("Party_UI/" + GManager.instance.character_pos[i]);
                switch (GManager.instance.character_pos[i])
                {
                    case 101000:
                        _Party_Pos_Frame[i].sprite = Resources.Load<Sprite>("Party_UI/" + "RainbowFrame");
                        _Party_Pos_backGround[i].sprite = Resources.Load<Sprite>("Party_UI/" + "Rainbow");
                        break;
                    case 102000:
                        _Party_Pos_Frame[i].sprite = Resources.Load<Sprite>("Party_UI/" + "GoldFrame");
                        _Party_Pos_backGround[i].sprite = Resources.Load<Sprite>("Party_UI/" + "Rainbow");
                        break;
                    case 103000:
                        _Party_Pos_Frame[i].sprite = Resources.Load<Sprite>("Party_UI/" + "SilverFrame");
                        _Party_Pos_backGround[i].sprite = Resources.Load<Sprite>("Party_UI/" + "Rainbow");
                        break;
                    default:
                        _Party_Pos_Frame[i].sprite = Resources.Load<Sprite>("Party_UI/" + "EmptyFrame");
                        _Party_Pos_backGround[i].sprite = Resources.Load<Sprite>("Party_UI/" + "Rainbow");
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void party_change(int num)
    {
        _PartyScreen.SetActive(false);
        _CharacterScreen.SetActive(true);
        _TryChange = num;
    }

    public void Select_Char(int id)
    {
        GManager.instance.character_pos[_TryChange] = id;
        Debug.Log(id);
        _Party_POS_IMG[_TryChange].sprite = Resources.Load<Sprite>("Party_UI/" + id);
        _Party_Pos_Frame[_TryChange].sprite = Resources.Load<Sprite>("Party_UI/" + "frame");
        
        _CharacterScreen.SetActive(false);
        _PartyScreen.SetActive(true);
        _TryChange = 0;
    }
    
}
