using UnityEngine;

public class CharacterData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private DataTable_pre data = null;

    //[SerializeField]
    private int id;

    [SerializeField] public CharacterTable CharacterStatus;
    void Awake()
    {
        id = this.gameObject.GetComponentInParent<Character_Present_Data>()._ID;
        for (int i = 0; i < data.Character.Count; i++)
        {
            if (data.Character[i].ID == id)
            {
                CharacterStatus = data.Character[i];
                break;
            }
        }
        this.gameObject.tag = this.transform.parent.tag;

    }

}
