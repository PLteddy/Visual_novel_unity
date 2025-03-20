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

    private bool firstTime; // nouvelle variable pour simplifier

    void Start()
{
    // TEMP pour tester le premier passage à chaque fois :
    PlayerPrefs.DeleteKey("SceneCouloirFirstTime"); //retirer DeleteKey() pour garder le système de "je suis déjà passé par ici".

    DialogueDisplay.SetActive(false);
    ArtChar1a.SetActive(false);
    ArtBG1.SetActive(true);
    nextButton.SetActive(false);
    Rond1.SetActive(false);
    Rond2.SetActive(false);
    Rond3.SetActive(false);

    firstTime = PlayerPrefs.GetInt("SceneCouloirFirstTime", 0) == 0;

    if (firstTime)
    {
        primeInt = 1;
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
        Next();
        PlayerPrefs.SetInt("SceneCouloirFirstTime", 1);
    }
    else
    {
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
        primeInt = 99;
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
            Char1name.text = "Jeda";
            Char1speech.text = "Tu es enfin arrivé dans le couloir...";
            primeInt++;
        }
        else if (primeInt == 2)
        {
            Char1name.text = "YOU";
            Char1speech.text = "Je ne reconnais pas cet endroit...";
            primeInt++;
        }
        else if (primeInt == 3)
        {
            Char1name.text = "Jeda";
            Char1speech.text = "C'est ici que tout commence.";
            primeInt++;
        }
        else if (primeInt == 4)
        {
            EndDialogue();
        }
        else if (primeInt == 99)
        {
            // Cas du "je suis déjà passé"
            Char1name.text = "YOU";
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
        SceneManager.LoadScene("Credits");
    }

    public void GoToScene3()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
