using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Scene2Dialogue : MonoBehaviour
{
    public int primeInt = 1;        
    public TMP_Text Char1name;
    public TMP_Text Char1speech;
    public GameObject DialogueDisplay;
    public GameObject ArtChar1a;
    public GameObject ArtBG1;
    public GameObject Rond1;
    public GameObject Rond2;
    public GameObject Rond3;
    public GameObject nextButton;
    private bool allowSpace = true;


    void Start()
{

    DialogueDisplay.SetActive(false);
    ArtChar1a.SetActive(false);
    ArtBG1.SetActive(true);
    nextButton.SetActive(false);
    Rond1.SetActive(false);
    Rond2.SetActive(false);
    Rond3.SetActive(false);
int visiteCouloir = PlayerPrefs.GetInt("SceneCouloirFirstTime", 1);

if (visiteCouloir == 1) // Si c'est la première fois
    {
        primeInt = 1;
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
        Next();
        
        PlayerPrefs.SetInt("SceneCouloirFirstTime", 2); // Marque la salle comme visitée
        PlayerPrefs.Save();  
    }
    else // Si le joueur est déjà passé
    {
        primeInt = 99;
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
        Next();
    }
}

    void Update()
    {
        if (allowSpace)
        {
            if (Input.GetKeyDown("space"))
            {
                Next();
            }
        }
    }

    public void Next()
    {
        if (primeInt == 1)
        {
            ArtChar1a.SetActive(true);
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Ce long couloir est angoissant...";
            primeInt++;
        }
        else if (primeInt == 2)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Je ne me sens pas à l'aise ici...";
            primeInt++;
        }
        else if (primeInt == 3)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Il faut vite que je pars mais par où passer ?";
            primeInt++;
        }
        else if (primeInt == 4)
        {
            EndDialogue();
        }
        else if (primeInt == 99)
        {
            // Cas du "je suis déjà passé"
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Je suis déjà passé par ici...";
            primeInt = 100;
        }
        else if (primeInt == 100)
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        DialogueDisplay.SetActive(false);
        nextButton.SetActive(false);
        allowSpace = false;
        ArtChar1a.SetActive(false);
        Rond1.SetActive(true);
        Rond2.SetActive(true);
        Rond3.SetActive(true);
    }

    public void GoToScene1()
    {
        SceneManager.LoadScene("SceneGarage");
    }

    public void GoToScene2()
    {
        SceneManager.LoadScene("SceneSalledebain");
    }

    public void GoToScene3()
    {
        SceneManager.LoadScene("SceneHall");
    }
}
