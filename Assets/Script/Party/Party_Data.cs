using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Party_Data : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _UI_Party;
    [SerializeField] private GameObject _UI_Select;
    [SerializeField] private GameObject _Character_BackGround;
    [SerializeField] private GameObject _Character_Frame;
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

    private int Rarerity;
    
    [SerializeField] private AudioClip sound;
    [SerializeField] private float Sec;
    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        for (int i = 0; i < _Party_POS_IMG.Count; i++)
        {
            _Party_Pos_Frame[i].sprite = Resources.Load<Sprite>("Party_UI/EmptyFrame");

            if (GManager.instance.character_pos[i] != 0)
            {
                _Party_POS_IMG[i].sprite = Resources.Load<Sprite>("Party_UI/Character/" + GManager.instance.character_pos[i]);
                for (int j = 0; j < data.Character.Count; j++)
                {
                    if (GManager.instance.character_pos[i] == data.Character[j].ID)
                    {

                        switch (data.Character[j].Rare)
                        {
                            case 1:
                                _Party_Pos_Frame[i].sprite = Resources.Load<Sprite>("Party_UI/SilverFrame");
                                _Party_Pos_backGround[i].sprite = Resources.Load<Sprite>("Party_UI/Silver");
                                break;
                            case 2:
                                _Party_Pos_Frame[i].sprite = Resources.Load<Sprite>("Party_UI/GoldFrame");
                                _Party_Pos_backGround[i].sprite = Resources.Load<Sprite>("Party_UI/Gold");
                                break;
                            case 3:
                                _Party_Pos_Frame[i].sprite = Resources.Load<Sprite>("Party_UI/RainbowFrame");
                                _Party_Pos_backGround[i].sprite = Resources.Load<Sprite>("Party_UI/Rainbow");
                                break;
                            default:
                                _Party_Pos_Frame[i].sprite = Resources.Load<Sprite>("Party_UI/EmptyFrame");
                                break;
                        }
                        
                    }
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
        _UI_Party.SetActive(false);
        _CharacterScreen.SetActive(true);
        
        _UI_Select.SetActive(true);
        _Character_Frame.SetActive(true);
        _Character_BackGround.SetActive(true);

        StartCoroutine(soundDelay());
        
        _TryChange = num;
    }

    public void Select_Char(int id)
    {
        GManager.instance.character_pos[_TryChange] = id;
        Debug.Log(id);
        _Party_POS_IMG[_TryChange].sprite = Resources.Load<Sprite>("Party_UI/Character/" + id);

        for (int i = 0; i < data.Character.Count; i++)
        {
            if (id == data.Character[i].ID)
            {
                Rarerity = data.Character[i].Rare;
            }
        
            switch (Rarerity)
            {
                case 1:
                    _Party_Pos_Frame[_TryChange].sprite = Resources.Load<Sprite>("Party_UI/SilverFrame");
                    _Party_Pos_backGround[_TryChange].sprite = Resources.Load<Sprite>("Party_UI/Silver");
                    break;
                case 2:
                    _Party_Pos_Frame[_TryChange].sprite = Resources.Load<Sprite>("Party_UI/GoldFrame");
                    _Party_Pos_backGround[_TryChange].sprite = Resources.Load<Sprite>("Party_UI/Gold");
                    break;
                case 3:
                    _Party_Pos_Frame[_TryChange].sprite = Resources.Load<Sprite>("Party_UI/RainbowFrame");
                    _Party_Pos_backGround[_TryChange].sprite = Resources.Load<Sprite>("Party_UI/Rainbow");
                    break;
                // default:
                //      _Party_Pos_Frame[i].sprite = Resources.Load<Sprite>("Party_UI/EmptyFrame");
                //      break;
            }

            
        }

        StartCoroutine(soundDelay());
        
        _CharacterScreen.SetActive(false);
        _UI_Party.SetActive(true);
        _PartyScreen.SetActive(true);
        _UI_Select.SetActive(false);
        _Character_Frame.SetActive(false);
        _Character_BackGround.SetActive(false);
        _TryChange = 0;
    }
    
    IEnumerator soundDelay ()
    {        
        _audioSource.PlayOneShot(sound);
        yield return new WaitForSeconds(Sec);
        
        Debug.Log("SceneLoad");
    }

}

