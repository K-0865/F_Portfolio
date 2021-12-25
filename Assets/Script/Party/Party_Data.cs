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
    private int _TryChange;
    void Start()
    {
        for (int i = 0; i < _Party_POS_IMG.Count; i++)
        {
            if (GManager.instance.character_pos[i] != 0)
            {
                _Party_POS_IMG[i].sprite = Resources.Load<Sprite>("Party_UI/" + GManager.instance.character_pos[i]);

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
        
        _CharacterScreen.SetActive(false);
        _PartyScreen.SetActive(true);
        _TryChange = 0;
    }
    
}
