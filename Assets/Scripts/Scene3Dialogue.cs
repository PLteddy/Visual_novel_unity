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
    //public GameObject Rond3;
    public GameObject Rond4;
    public GameObject Choice1a;
    public GameObject Choice1b;
    //public GameObject Choice2a;
    //public GameObject Choice2b;
    public GameObject nextButton;
    private bool allowSpace = true;

    private bool firstTime; // nouvelle variable pour simplifier
    private bool hasStartedDialogue = false;
    private bool hasStartedRond2 = false;

    void Start()
{
    // TEMP pour tester le premier passage à chaque fois :
    PlayerPrefs.DeleteKey("SceneGarageFirstTime"); //retirer DeleteKey() pour garder le système de "je suis déjà passé par ici".

    DialogueDisplay.SetActive(false);
    ArtChar1a.SetActive(false);
    ArtBG1.SetActive(true);
    Rond1.SetActive(false);
    Rond2.SetActive(false);
    //Rond3.SetActive(false);
    Rond4.SetActive(false);
    Choice1a.SetActive(false);
    Choice1b.SetActive(false);
    //Choice2a.SetActive(false);
    //Choice2b.SetActive(false);
    nextButton.SetActive(true);

    firstTime = PlayerPrefs.GetInt("SceneGarageFirstTime", 0) == 0;

    if (firstTime)
    {
        primeInt = 1;
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
        Next();
        PlayerPrefs.SetInt("SceneGarageFirstTime", 1);
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
            Char1name.text = "You";
            Char1speech.text = "Je suis dans un garage";
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
            Char1name.text = "You";
            Char1speech.text = "Peut-être que je devrais explorer un peu";
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

//rond1_d
    if (primeInt == 40)
    {
        ArtChar1a.SetActive(true);
        Char1name.text = "You";
        Char1speech.text = "C'est des étagères pleines de vieux outils";
        primeInt++;
    }
    else if (primeInt == 41)
    {
        Char1name.text = "YOU";
        Char1speech.text = "Je pourrais peut être fouiller et trouver quelque chose d'utilile";
        primeInt++;
    }
    else if (primeInt == 42)
    {
        Char1name.text = "You";
        Char1speech.text = "Il n'y avait rien d'intéressant";
        primeInt++;
    }
    else if (primeInt == 43)
    {
        EndDialogue();
    }

//rond2_d
        if (primeInt == 80)
        {
            ArtChar1a.SetActive(true);
            Char1name.text = "You";
            Char1speech.text = "C'est la porte du garage";
            primeInt++;
        }
        else if (primeInt == 81)
        {
            Char1name.text = "YOU";
            Char1speech.text = "Je pourrais peut être l'ouvrir et m'echapper";
            primeInt++;
        }
        else if (primeInt == 82)
        {
            Char1name.text = "You";
            Char1speech.text = "avec un peu de force ";
            primeInt++;
        }

else if (primeInt == 83){
    Char1name.text = "Jeda";
    Char1speech.text = "Je tente ou pas ?";
    nextButton.SetActive(false);
    allowSpace = false;
    Choice1a.SetActive(true);
    Choice1b.SetActive(true);
}

// after choice 1a
else if (primeInt == 84){
    Char1name.text = "YOU";
    Char1speech.text = "choix1 porte";
    primeInt = 85; // ira à 85 sur "Next"
}
else if (primeInt == 85){
    Char1name.text = "You";
    Char1speech.text = "Je suis le choix après 1";
    primeInt++;
}
else if (primeInt == 86){
    Char1name.text = "You";
    Char1speech.text = "On parle et parlote";
    primeInt++;
}
else if (primeInt == 87){
    EndDialogue();
}

// after choice 1b
else if (primeInt == 94){
    Char1name.text = "YOU";
    Char1speech.text = "choix2 porte";
    primeInt = 95; // ira à 95 sur "Next"
}
else if (primeInt == 95){
    Char1name.text = "You";
    Char1speech.text = "Je suis le choix après 2";
    primeInt++;
}
else if (primeInt == 96){
    Char1name.text = "You";
    Char1speech.text = "on parle et parlotte toujours";
    primeInt++;
}
else if (primeInt == 97){
    EndDialogue();
}



// Si on est déjà passé     AVANT DE DECOMMENTEZ IL FAUT VERIFIER SI LA VARIABLE MARCHE BIEN LE BOOLEAN 
//parce que ça semble pas marcher mon dialogue s'arrête au premier texte
// else if (primeInt == 199){ 
//     Char1name.text = "You";
//     Char1speech.text = "Je suis déjà passé là";
//     primeInt++;
    
// }
// else if (primeInt == 200){
//     EndDialogue();
// }


    }



    void EndDialogue()
    {
        DialogueDisplay.SetActive(false);
        nextButton.SetActive(false);
        allowSpace = false;
        ArtChar1a.SetActive(false);
        Rond1.SetActive(true);
        Rond2.SetActive(true);
        //Rond3.SetActive(true);
        Rond4.SetActive(true);
    }

public void Rond1_d()
{
    if (!hasStartedDialogue)
    {
        hasStartedDialogue = true;
        primeInt = 40;

        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
        allowSpace = true;
        Next(); // On lance le Next direct
    }
}

public void Rond2_d()
{
    if (!hasStartedRond2)
    {
        hasStartedRond2 = true;
        primeInt = 80;

        // Active le dialogue et les contrôles
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
        allowSpace = true;
        Next(); // On lance le Next direct
    }
    // else  voir211 pour plus d'informations
    // { 
    //     primeInt = 199;
    //     DialogueDisplay.SetActive(true);
    //     nextButton.SetActive(true);
    //     allowSpace = true;
    //     Next(); // On lance le Next direct
    // }
}
    
// FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and SceneChanges)
public void Choice1aFunct(){
    primeInt = 84;
    Choice1a.SetActive(false);
    Choice1b.SetActive(false);
    nextButton.SetActive(true);
    allowSpace = true;
}

public void Choice1bFunct(){
    primeInt = 94;
    Choice1a.SetActive(false);
    Choice1b.SetActive(false);
    nextButton.SetActive(true);
    allowSpace = true;
}

    
        public void Rond4_d()
        {
            SceneManager.LoadScene("SceneCouloir");
        }

    }   

