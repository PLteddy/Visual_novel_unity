using UnityEngine;
using TMPro;

public class NameInputHandler : MonoBehaviour
{
    public TMP_InputField nameInputField; // L'input où le joueur tape son nom

    public void SavePlayerName()
    {
        if (!string.IsNullOrEmpty(nameInputField.text)) // Vérifie que le champ n'est pas vide
        {
            GameHandler.SetPlayerName(nameInputField.text); // Stocke le nom
        }
    }
}
