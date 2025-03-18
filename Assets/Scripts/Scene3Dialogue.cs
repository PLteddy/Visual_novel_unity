using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Scene3Dialogue : MonoBehaviour
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
    public GameObject Rond4;
    public GameObject Choice1a;
    public GameObject Choice1b;
    public GameObject Choice2a;
    public GameObject Choice2b;
    public GameObject nextButton;
    private bool allowSpace = true;
    private bool firstTime;

    void Start()
    {
        PlayerPrefs.DeleteKey("SceneGarageFirstTime");
        DialogueDisplay.SetActive(false);
        ArtChar1a.SetActive(false);
        ArtBG1.SetActive(true);
        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond4.SetActive(false);
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        Choice2a.SetActive(false);
        Choice2b.SetActive(false);
        nextButton.SetActive(true);

        firstTime = PlayerPrefs.GetInt("SceneGarageFirstTime", 0) == 0;

        if (firstTime)
        {
            primeInt = 1;
            DialogueDisplay.SetActive(true);
            Next();
            PlayerPrefs.SetInt("SceneGarageFirstTime", 1);
        }
        else
        {
            primeInt = 99;
            DialogueDisplay.SetActive(true);
            Next();
        }
    }

    void Update()
    {
        if (allowSpace && Input.GetKeyDown("space"))
        {
            Next();
        }
    }

    public void Next()
    {
        switch(primeInt)
        {
            case 1:
                ArtChar1a.SetActive(true);
                Char1name.text = "You";
                Char1speech.text = "Je suis dans un garage";
                primeInt++;
                break;
            
            case 2:
                Char1name.text = "YOU";
                Char1speech.text = "Je ne reconnais pas cet endroit...";
                primeInt++;
                break;
            
            case 3:
                Char1name.text = "You";
                Char1speech.text = "Peut-être que je devrais explorer un peu";
                primeInt++;
                break;
            
            case 4:
                EndDialogue();
                break;
            
            // Après choix porte
            case 8:
                Char1name.text = "You";
                Char1speech.text = "Je suis le choix après 1";
                primeInt++;
                break;
            
            case 9:
                Char1name.text = "You";
                Char1speech.text = "On parle et parlote";
                primeInt++;
                break;
            
            // Après choix compteur
            case 20:
                Char1name.text = "You";
                Char1speech.text = "Je suis le choix après 2";
                primeInt++;
                break;
            
            case 21:
                Char1name.text = "You";
                Char1speech.text = "On parle et parlotte toujours";
                primeInt++;
                break;
            
            case 99:
                Char1name.text = "YOU";
                Char1speech.text = "Je suis déjà passé par ici...";
                primeInt = 100;
                break;
            
            case 100:
                EndDialogue();
                break;
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
        Rond4.SetActive(true);
    }

    public void Rond1_d()
    {
        if (!DialogueDisplay.activeSelf)
        {
            DialogueDisplay.SetActive(true);
            nextButton.SetActive(true);
            primeInt = 1;
            allowSpace = true;
            
            StartCoroutine(Rond1Dialogue());
        }
    }

    IEnumerator Rond1Dialogue()
    {
        Char1name.text = "You";
        Char1speech.text = "C'est des étagères pleines de vieux outils";
        yield return new WaitUntil(() => Input.GetKeyDown("space"));
        
        Char1name.text = "YOU";
        Char1speech.text = "Je pourrais peut-être fouiller...";
        yield return new WaitUntil(() => Input.GetKeyDown("space"));
        
        EndDialogue();
    }

    public void Rond2_d()
    {
        if (!DialogueDisplay.activeSelf)
        {
            DialogueDisplay.SetActive(true);
            primeInt = 1;
            allowSpace = true;
            StartCoroutine(Rond2Dialogue());
        }
    }

    IEnumerator Rond2Dialogue()
    {
        Char1name.text = "You";
        Char1speech.text = "C'est la porte du garage";
        yield return new WaitUntil(() => Input.GetKeyDown("space"));
        
        Char1name.text = "YOU";
        Char1speech.text = "Je pourrais peut-être l'ouvrir...";
        yield return new WaitUntil(() => Input.GetKeyDown("space"));
        
        Char1name.text = "Jeda";
        Char1speech.text = "Je tente ou pas ?";
        nextButton.SetActive(false);
        allowSpace = false;
        Choice1a.SetActive(true);
        Choice1b.SetActive(true);
    }

    public void Rond3_d()
    {
        if (!DialogueDisplay.activeSelf)
        {
            DialogueDisplay.SetActive(true);
            primeInt = 1;
            allowSpace = true;
            StartCoroutine(Rond3Dialogue());
        }
    }

    IEnumerator Rond3Dialogue()
    {
        Char1name.text = "You";
        Char1speech.text = "C'est le compteur électrique";
        yield return new WaitUntil(() => Input.GetKeyDown("space"));
        
        Char1name.text = "YOU";
        Char1speech.text = "Je pourrais peut-être couper le courant...";
        yield return new WaitUntil(() => Input.GetKeyDown("space"));
        
        Char1name.text = "Jeda";
        Char1speech.text = "Je tente ou pas ?";
        nextButton.SetActive(false);
        allowSpace = false;
        Choice2a.SetActive(true);
        Choice2b.SetActive(true);
    }

    // Fonctions de choix
    public void Choice1aFunct()
    {
        Char1name.text = "YOU";
        Char1speech.text = "choix1 porte";
        primeInt = 8;
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        nextButton.SetActive(true);
        allowSpace = true;
        Next();
    }

    public void Choice1bFunct()
    {
        Char1name.text = "YOU";
        Char1speech.text = "choix2 porte";
        primeInt = 20;
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        nextButton.SetActive(true);
        allowSpace = true;
        Next();
    }

    public void Choice2aFunct()
    {
        Char1name.text = "YOU";
        Char1speech.text = "choix1 compteur";
        primeInt = 8;
        Choice2a.SetActive(false);
        Choice2b.SetActive(false);
        nextButton.SetActive(true);
        allowSpace = true;
        Next();
    }

    public void Choice2bFunct()
    {
        Char1name.text = "YOU";
        Char1speech.text = "choix2 compteur";
        primeInt = 20;
        Choice2a.SetActive(false);
        Choice2b.SetActive(false);
        nextButton.SetActive(true);
        allowSpace = true;
        Next();
    }

    public void Rond4_d()
    {
        SceneManager.LoadScene("SceneCouloir");
    }
}
