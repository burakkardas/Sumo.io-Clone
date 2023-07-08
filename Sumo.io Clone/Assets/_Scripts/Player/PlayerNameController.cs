using UnityEngine;
using TMPro;

public class PlayerNameController : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private TMP_Text playerNameText = null;
    private string _playerName = "Sumo13883";



    public void SetPlayerName()
    {
        _playerName = nameInputField.text;
        playerNameText.text = _playerName;
    }


    public string GetPlayerName()
    {
        return _playerName;
    }
}
