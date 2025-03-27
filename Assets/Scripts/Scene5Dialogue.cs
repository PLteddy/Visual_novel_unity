using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Scene5Dialogue : MonoBehaviour //Vous changez le nom template en fonction du nom de votre scène
{
    //ça c pour déclarer les variables que vous allez utilisez dans le script 
    //Donc c ici que vous gérez les ajouts d'objets interactif ou de choix 
    public int primeInt = 1;        
    public TMP_Text Char1name;//C le nom du perso principal !ne pas touchez!
    public TMP_Text Char1speech;//C le texte du perso principal !ne pas touchez!
    public GameObject DialogueDisplay;//C les bulles de dialogues !ne pas touchez!
    public GameObject ArtChar1a;//C la photo du perso principal !ne pas touchez!
    public GameObject ArtBG1;//C l'arrière plan !ne pas touchez!
    public GameObject Rond1; //c le bouton qui permet de lancer un dialogue relié à rond1 il faut copier et coller pour en rajouter
    public GameObject Rond2;
    public GameObject Rond3;
    public GameObject Rond4;
    public GameObject Rond5;
    public GameObject Choice2a;
    public GameObject Choice2b;
    public GameObject ChoiceCodeCorrect; // Option pour entrer le bon code
    public GameObject ChoiceCodeWrong;   // Option pour entrer un mauvais code


    private bool allowSpace = true;// !ne pas touchez!




    //Variable pour vérifier que le joueur est déjà passé par là
    //a chaque fois que vous rajouter un dialogue + un bouton genre rond 5 vous devez mettre une variable pour vérifier
    private bool hasStartedDialogue = false;
    private bool hasStartedRond2 = false;
    private bool hasStartedRond3 = false;
    private bool hasStartedRond5 = false;

    void Start()
{

    DialogueDisplay.SetActive(false);//cache la bulle de dialogue
    ArtChar1a.SetActive(false);//cache l'image du personnage 
    ArtBG1.SetActive(true); //affiche l'arrière plan
    Rond1.SetActive(false); //cache les endroits cliquables
    Rond2.SetActive(false);
    Rond3.SetActive(false);
    Rond4.SetActive(false);
    Rond5.SetActive(false);
    Choice2a.SetActive(false);
    Choice2b.SetActive(false);
    ChoiceCodeCorrect.SetActive(false); // Option pour entrer le bon code
    ChoiceCodeWrong.SetActive(false);   // Option pour entrer un mauvais code

int visiteHall = PlayerPrefs.GetInt("SceneHallFirstTime", 1);

if (visiteHall == 1) // Si c'est la première fois
    {
        primeInt = 1;
        DialogueDisplay.SetActive(true);
        Next();
        
        PlayerPrefs.SetInt("SceneHallFirstTime", 2); // Marque la salle comme visitée
        PlayerPrefs.Save();  
    }
    else // Si le joueur est déjà passé
    {
        primeInt = 99;
        DialogueDisplay.SetActive(true);
        Next();
    }
}

    void Update() //!ne pas touchez ou les dialogues ne passeront plus!
    {
        if (allowSpace)
        {
            if (Input.GetKeyDown("space"))
            {
                Next();
            }
        }
    }

    public void Next() // L'endroit où il y a tous les dialogues IL NE DOIT PAS Y AVOIR DES DIALOGUES AUTRE PART
    
    { // <-Faites attention à ne pas supprimer cette accolade



        //Dialogue d'introduction quand on rentre dans la salle pour la première fois
        if (primeInt == 1)
        {
            ArtChar1a.SetActive(true); //active l'image du personnage
            Char1name.text = GameHandler.playerName; //le nom du personnage faudra changer mettre la variable et remplacer
            Char1speech.text = "C'est le hall..."; //là c les dialogues
            primeInt++; //pour que ça incrémente le dialogue 
        }
        else if (primeInt == 2)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "La sortie est juste là...";
            primeInt++;
        }
        else if (primeInt == 3)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Il faut absolument que je sorte avant qu'on ne me rattrape";
            primeInt++;
        }
        else if (primeInt == 4)
        {
            EndDialogue(); //emmène à la clôture du dialogue
        }
        else if (primeInt == 99) // Cas du "je suis déjà passé"
        {
           
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "La sortie est juste là...";
            primeInt = 100;
        }
        else if (primeInt == 100)
        {
            EndDialogue();//emmène à la clôture du dialogue
        }

//rond1_d
    if (primeInt == 40)
    {
        ArtChar1a.SetActive(true);
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "C'est une vieille commode rempli de babioles";
        primeInt++;
    }
    else if (primeInt == 41)
    {
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "Des livres, des mouchoirs et des photos...";
        primeInt++;
    }
    else if (primeInt == 42)
    {
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "Rien d'utile...";
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
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "Ce manteau sent la moisissure et la poussière";
        primeInt++;
    }
    else if (primeInt == 81)
    {
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "Je vais quand même fouiller les poches...";
        primeInt++;
    }
    else if (primeInt == 82)
    {
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "Beurk rien à part des mouchoirs usagés... Il faudra que je me lave les mains";
        primeInt++;
    }
    else if (primeInt == 83)
    {
        EndDialogue();
    }

if (primeInt == 120)
{
    ArtChar1a.SetActive(true);
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Qui met un pot de fleur à côté de sa porte ?";
    primeInt++;
}
else if (primeInt == 121)
{
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Elle est complètement asséchée...";
    primeInt++;
}
else if (primeInt == 122)
{
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "J'aimerais la déplacer mais je ne veux pas laisser de trace de mon passage...";
    primeInt++;
}
else if (primeInt == 123)
{
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Je déplace la plante ?";
    allowSpace = false;
    Choice2a.SetActive(true);
    Choice2b.SetActive(true);
}
else if (primeInt == 124)
{
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Allez viens là ma jolie je vais te déplacer.";
    primeInt++;
}
else if (primeInt == 125)
{
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Oh ? Une clé !";
    GameHandler.hasKey = true;
    primeInt++;
}
else if (primeInt == 126)
{
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Je vais la garder, ça peut être utile.";
    primeInt++;
}
else if (primeInt == 127)
{
    EndDialogue();
}
else if (primeInt == 144)
{
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Désolé petite plante je n'ai pas le temps.";
    primeInt = 145;
}
else if (primeInt == 145)
{
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Je vais la laisser à son triste sort...";
    primeInt++;
}
else if (primeInt == 146)
{
    EndDialogue();
}

// --- Vérification de la clé avant d'accéder au digicode ---
else if (primeInt == 520)
{
    ArtChar1a.SetActive(true);
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "La porte est verrouillée.";
    primeInt++;
}
else if (primeInt == 521)
{
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Il y a un cadenas qu'il faut ouvrir avec une clé.";
    primeInt++;
}
else if (primeInt == 522)
{
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Et un digicode pour rentrer un code...";
    primeInt++;
}
else if (primeInt == 523)
{
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Il faut commencer par la clé";

    if (GameHandler.hasKey)
    {
        Char1speech.text = "Le cadenas est ouvert.";
        primeInt = 525; // Passage logique
    }
    else
    {
        Char1speech.text = "Je n'ai pas la clé...";
        primeInt=325;
    }
}
else if (primeInt == 325)
{
EndDialogue();
}

else if (primeInt == 525) // Début de la saisie du code
{
    if (!GameHandler.isElectricityOff) 
    {
        Char1speech.text = "Mince ! L'alarme s'est déclenchée... J'aurais dû couper l'électricité.";
        primeInt = 672; // Alarme directe -> Échec
    }
    else 
    {
        Char1speech.text = "Je dois entrer le code.";
        allowSpace = false;
        ChoiceCodeCorrect.SetActive(true); // Option pour entrer le bon code
        ChoiceCodeWrong.SetActive(true);   // Option pour entrer un mauvais code
    }
    
}

else if (primeInt == 660) // Bon code mais vérification électricité
{
    if (!GameHandler.isElectricityOff) 
    {
        Char1speech.text = "Mince ! L'alarme s'est déclenchée... J'aurais dû couper l'électricité.";
        primeInt = 670; // Alarme directe -> Échec
    }
    else 
    {
        Char1speech.text = "Ça a marché !";
        primeInt++;
    }
}

else if (primeInt == 661)
{
    Char1speech.text = "La porte est ouverte !";
    primeInt++;
}
else if (primeInt == 662)
{
    SceneManager.LoadScene("SceneWin"); // Fin négative
}

else if (primeInt == 670) // Mauvais code ou électricité active -> Défaite
{
    Char1speech.text = "Oh non, ce n'est pas le bon code...";
    primeInt++;
}
else if (primeInt == 671)
{
    Char1speech.text = "Une alarme retentit dans toute la maison !";
    primeInt++;
}
else if (primeInt == 672)
{
    Char1speech.text = "C'est la fin...";
    primeInt++;
    SceneManager.LoadScene("SceneLoose"); // Fin négative
}





// Dialogue lorsqu'on on rappuie sur les boutons 

//rond1
        if (primeInt == 199)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Je suis déjà passé par là.";
            primeInt++;
        }
        else if (primeInt == 200)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Je ne vais pas perdre mon temps ici.";
            primeInt++;
        }
        else if (primeInt == 201)
        {
            EndDialogue();
        }

        //rond2
        if (primeInt == 299)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "J'ai déjà fouillé ce manteau.";
            primeInt++;
        }
        else if (primeInt == 300)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Je ne vais pas remettre mes doigts à l'intérieur...";
            primeInt++;
        }
        else if (primeInt == 301)
        {
            EndDialogue();
        }

if (primeInt == 399) {
    Char1name.text = GameHandler.playerName;
    
    if (!GameHandler.hasKey) {
        Char1speech.text = "Tiens... en regardant de plus près, il y a quelque chose ! ";
        primeInt = 125; // On saute directement à la récupération de la clé
    } else {
        Char1speech.text = "Je suis déjà passé par là.";
        primeInt++;
    }
}
else if (primeInt == 400) {
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Je ne vais pas perdre mon temps ici.";
    primeInt++;
}
else if (primeInt == 401) {
    EndDialogue();
}

 

    }// <-Faites attention à ne pas supprimer cette accolade 



    void EndDialogue() //Permet de fermer le dialogue vous ne touchez pas à part pour rajouter des ronds.
    {
        DialogueDisplay.SetActive(false);
        allowSpace = false;
        ArtChar1a.SetActive(false);
        Rond1.SetActive(true);
        Rond2.SetActive(true);
        Rond3.SetActive(true);
        Rond4.SetActive(true);
        Rond5.SetActive(true);
    }




public void Rond1_d() //Permet de gérer les dialogues et choix du bouton 1 
{
    if (!hasStartedDialogue) //Si c'est la première fois qu'on fait ce dialogue 
    {
        hasStartedDialogue = true; //on active le passage 
        primeInt = 40; //on va vers le dialogue 40

        // Désactiver les boutons ronds pour éviter qu'ils restent affichés rajoutez en si vous en avez rajoutez
        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond4.SetActive(false);
        Rond5.SetActive(false);
        DialogueDisplay.SetActive(true);
        allowSpace = true;
        Next(); 
    }
    else if (hasStartedDialogue) // Si déjà visité alors on va vers le dialogue 199
    {
        primeInt = 199; 
         // Désactiver les boutons ronds pour éviter qu'ils restent affichés rajoutez en si vous en avez rajoutez
        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond4.SetActive(false);
        Rond5.SetActive(false);
        DialogueDisplay.SetActive(true);
        allowSpace = true;
        Next(); 
    }
}



public void Rond2_d()//pareil que rond1 
{
    if (!hasStartedRond2) // Si non visité
    {
        hasStartedRond2 = true;
        primeInt = 80;

        
        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond4.SetActive(false);
        Rond5.SetActive(false);

        // Active le dialogue et les contrôles
        DialogueDisplay.SetActive(true);
        allowSpace = true;
        Next(); 
    }
    else if (hasStartedRond2) // Si déjà visité
    {
        primeInt = 299; 

        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond4.SetActive(false);
        Rond5.SetActive(false);
        DialogueDisplay.SetActive(true);
        allowSpace = true;
        Next(); 
    }
}



public void Rond3_d() //pareil que rond1
{
    if (!hasStartedRond3)// Si non visité
    {
        hasStartedRond3 = true;
        primeInt = 120;

       
        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond4.SetActive(false);
        Rond5.SetActive(false);

       
        DialogueDisplay.SetActive(true);
        allowSpace = true;
        Next(); 
    }
    else if (hasStartedRond3) // Si déjà visité
    {
        primeInt = 399; 

        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond4.SetActive(false);
        Rond5.SetActive(false);
        DialogueDisplay.SetActive(true);
        allowSpace = true;
        Next(); 
    }
}

public void Rond5_d() //pareil que rond1
{
    if (!hasStartedRond5)// Si non visité
    {
        hasStartedRond3 = true;
        primeInt = 520;

       
        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond4.SetActive(false);
        Rond5.SetActive(false);

       
        DialogueDisplay.SetActive(true);
        allowSpace = true;
        Next(); 
    }
    else if (hasStartedRond5) // Si déjà visité
    {
        primeInt = 399; 

        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond4.SetActive(false);
        Rond5.SetActive(false);
        DialogueDisplay.SetActive(true);
        allowSpace = true;
        Next(); 
    }
}



// FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and SceneChanges)
//ça c pour que ça sache sur quel bouton on a cliqué et donc sur quel dialogue on va déboucher


public void Choice2aFunct(){
    primeInt = 124;
    Choice2a.SetActive(false);// pareil pour désactiver la vue des choix après que ça a été fait
    Choice2b.SetActive(false);
    allowSpace = true;
}

public void Choice2bFunct(){
    primeInt = 144;
    Choice2a.SetActive(false);
    Choice2b.SetActive(false);
    allowSpace = true;
}


public void ChoiceCodeCorrectFunct()
{
    primeInt = 661; // Succès
    ChoiceCodeCorrect.SetActive(false);
    ChoiceCodeWrong.SetActive(false);
    allowSpace = true;
}

public void ChoiceCodeWrongFunct()
{
    primeInt = 670; // Échec
    ChoiceCodeCorrect.SetActive(false);
    ChoiceCodeWrong.SetActive(false);
    allowSpace = true;
}




//ATTENTION POUR LES RAJOUTS DES CHOIX IL FAUT BIEN FAIRE EN SORTE QUE VOUS AVEZ RAJOUTE DES BOUTONS EN HAUT DU FICHIER 
// ET QUE VOUS AVEZ BIEN ACTIVE LE ONCLIK DANS L'INSPECTEUR ET RELIE A LA BONNE FONCTION SI VOUS Y ARRIVEZ PAS DEMANDEZ MOI. 



    //ça c si jamais vous voulez pas de dialogues mais genre allez dans une salle ou retourner en arrière
        public void Rond4_d()
        {
            //Il faut que ça ait le même nom que la scène si ça ne marche pas il faut me demander 
            //de faire un truc mais ça touche le github donc ne le faites pas sans en parler sinon ça va tout casser
            SceneManager.LoadScene("SceneCouloir");
        }

}
    
