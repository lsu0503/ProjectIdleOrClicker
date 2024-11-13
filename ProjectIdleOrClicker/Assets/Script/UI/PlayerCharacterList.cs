using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterList : MonoBehaviour
{
    [SerializeField] private GameObject CharacterInfoUIPrefab;
    public List<PlayerInfoUI> infoUIList = new List<PlayerInfoUI>();

    private void Awake()
    {
        UIManager.Instance.playerCharacterListUI = this;
    }

    public PlayerInfoUI AddInfoUI(Player player)
    {
        GameObject tempObj = Instantiate(CharacterInfoUIPrefab, this.transform);
        PlayerInfoUI tempUI = tempObj.GetComponent<PlayerInfoUI>();
        tempUI.SetCharacter(player);
        infoUIList.Add(tempUI);

        return tempUI;
    }
}