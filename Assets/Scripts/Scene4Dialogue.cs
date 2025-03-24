using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene4Dialogue : MonoBehaviour //Vous changez le nom template en fonction du nom de votre scène
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
    public GameObject Choice1a;//c les boutons qui permettent de choisir les choix il faut copier et coller pour en rajouter
    public GameObject Choice1b;
    public GameObject Choice2a;
    public GameObject Choice2b;
    public GameObject nextButton;
    public TMP_InputField nameInputField; // Champ texte où le joueur entre son nom
    public GameObject namePrompt; // Le panel contenant l'input field et le bouton de validation
    public Button validateNameButton; // Bouton pour valider le nom


    private bool allowSpace = true;// !ne pas touchez!




    //Variable pour vérifier que le joueur est déjà passé par là
    //a chaque fois que vous rajouter un dialogue + un bouton genre rond 5 vous devez mettre une variable pour vérifier
    private bool firstTime; //on touche pas
    private bool hasStartedDialogue = false;
    private bool hasStartedRond2 = false;
    private bool hasStartedRond3 = false;

    void Start()
{
    //pour tester le premier passage à chaque fois :
    //!toucher seulement le nom de la variable ou me demander pour savoir si on retire le truc en bas! 
    PlayerPrefs.DeleteKey("SceneGarageFirstTime"); //retirer DeleteKey() pour garder le système de "je suis déjà passé par ici".

    DialogueDisplay.SetActive(false);//cache la bulle de dialogue
    ArtChar1a.SetActive(false);//cache l'image du personnage 
    ArtBG1.SetActive(true); //affiche l'arrière plan
    Rond1.SetActive(false); //cache les endroits cliquables
    Rond2.SetActive(false);
    Rond3.SetActive(false);
    Rond4.SetActive(false);
    Choice1a.SetActive(false);//cache les boutons de choix
    Choice1b.SetActive(false);
    Choice2a.SetActive(false);
    Choice2b.SetActive(false);
    nextButton.SetActive(true); //ça permet de faire next dans le dialogue d'introduction de la salle
    namePrompt.SetActive(false); // Cache la saisie de nom au départ
    validateNameButton.gameObject.SetActive(false); 
    nameInputField.gameObject.SetActive(false);


    //pas toucher à part pour changer le nom de la variable 
    firstTime = PlayerPrefs.GetInt("SceneGarageFirstTime", 0) == 0;

    if (firstTime)// si c la première fois ça fait appraître un dialogue pour la découverte de la salle
    {
        primeInt = 1;// Prime int est définit à 1
        DialogueDisplay.SetActive(true); // la bulle de dialogue apparaît
        nextButton.SetActive(true);//le bouton next apparaît et on peut passer les dialogues
        Next(); //Quand vous voyez ça veut dire que ça emmène dans Next donc vérifier le primeInt pour voir dans quel dialogue ça emmène
        PlayerPrefs.SetInt("SceneGarageFirstTime", 1);//Transforme le booléen en 1 au lieu de 0 pour dire qu'on est passé
    }
    else //sinon ça fait un autre dialogue en mode g déjà vu ça
    {
        DialogueDisplay.SetActive(true);// la bulle de dialogue apparaît
        nextButton.SetActive(true);//le bouton next apparaît et on peut passer les dialogues
        primeInt = 99; // Prime int est définit à 99
        Next();//ça emmène dans Next donc vérifier le primeInt pour voir dans quel dialogue ça emmène
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



if (primeInt == 1)
{
    ArtChar1a.SetActive(true);
    Char1name.text = "???"; // Le personnage ne se souvient pas de son nom
    Char1speech.text = "Ohlala... Comment je m'appelle déjà ?";
    primeInt++;
}
else if (primeInt == 2)
{
    Char1name.text = "???";
    Char1speech.text = "Je suis incapable de me souvenir...";
    primeInt++;
}
else if (primeInt == 3)
{
    Char1name.text = "???";
    Char1speech.text = "Peut-être que si je me concentre, ça va me revenir.";
    primeInt++;

}
else if (primeInt == 4)
{
    DialogueDisplay.SetActive(false); // Cache la boîte de dialogue
    
    namePrompt.SetActive(true); // Affiche l'input field pour taper son nom
    validateNameButton.gameObject.SetActive(true); 
    nameInputField.gameObject.SetActive(true);
}
else if (primeInt == 5)
{
    namePrompt.SetActive(false); // Cache l'input field après validation
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Ah oui, bien sûr ! Je m'appelle " + GameHandler.playerName + " !";
    primeInt++;
}

else if (primeInt == 6)
{
    EndDialogue();//emmène à la clôture du dialogue
}

        else if (primeInt == 99) // Cas du "je suis déjà passé"
        {
           
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je suis déjà passé par ici...";
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
        Char1speech.text = "C'est des étagères pleines de vieux outils";
        primeInt++;
    }
    else if (primeInt == 41)
    {
        Char1name.text = GameHandler.playerName; 
        Char1speech.text = "Je pourrais peut être fouiller et trouver quelque chose d'utilile";
        primeInt++;
    }
    else if (primeInt == 42)
    {
        Char1name.text = GameHandler.playerName; 
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
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "C'est la porte du garage";
            primeInt++;
        }
        else if (primeInt == 81)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je pourrais peut être l'ouvrir et m'echapper";
            primeInt++;
        }
        else if (primeInt == 82)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "avec un peu de force ";
            primeInt++;
        }

else if (primeInt == 83){  //C'est pour les choix faites attention ici où ça va pas marcher
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Je tente ou pas ?";
    nextButton.SetActive(false);//ça fait en sorte qu'on ne puisse pas passer le dialogue 
    allowSpace = false;// N'autorise pas pas le passage au dialogue suivant avec la barre espace
    Choice1a.SetActive(true);//active les choix possibles
    Choice1b.SetActive(true);//active les choix possibles
}

// après le choix 1a
else if (primeInt == 84){
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "choix1 porte";
    primeInt = 85; 
}
else if (primeInt == 85){
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Je suis le choix après 1";
    primeInt++;
}
else if (primeInt == 86){
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "On parle et parlote";
    primeInt++;
}
else if (primeInt == 87){
    EndDialogue();
}

// après le choix 1b
else if (primeInt == 94){
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "choix2 porte";
    primeInt = 95; 
}
else if (primeInt == 95){
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Je suis le choix après 2";
    primeInt++;
}
else if (primeInt == 96){
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "on parle et parlotte toujours";
    primeInt++;
}
else if (primeInt == 97){
    EndDialogue();
}


//Rond3_d

        if (primeInt == 120)
        {
            ArtChar1a.SetActive(true);
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "C'est la porte du garage";
            primeInt++;
        }
        else if (primeInt == 121)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je pourrais peut être l'ouvrir et m'echapper";
            primeInt++;
        }
        else if (primeInt == 122)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "avec un peu de force ";
            primeInt++;
        }

else if (primeInt == 123){
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Je tente ou pas ?";
    nextButton.SetActive(false);
    allowSpace = false;
    Choice2a.SetActive(true);
    Choice2b.SetActive(true);
}

// après choix 2a
else if (primeInt == 124){
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "choix1 porte";
    primeInt = 125; 
}
else if (primeInt == 125){
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Je suis le choix après 1";
    primeInt++;
}
else if (primeInt == 126){
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "On parle et parlote";
    primeInt++;
}
else if (primeInt == 127){
    EndDialogue();
}

// après choix 2b
else if (primeInt == 144){
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "choix2 porte";
    primeInt = 145; 
}
else if (primeInt == 145){
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Je suis le choix après 2";
    primeInt++;
}
else if (primeInt == 146){
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "on parle et parlotte toujours";
    primeInt++;
}
else if (primeInt == 147){
    EndDialogue();
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
            Char1speech.text = "Je suis déjà passé par là.";
            primeInt++;
        }
        else if (primeInt == 300)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je ne vais pas perdre mon temps ici.";
            primeInt++;
        }
        else if (primeInt == 301)
        {
            EndDialogue();
        }


        //rond3
                if (primeInt == 399)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je suis déjà passé par là.";
            primeInt++;
        }
        else if (primeInt == 400)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je ne vais pas perdre mon temps ici.";
            primeInt++;
        }
        else if (primeInt == 401)
        {
            EndDialogue();
        }

 

    }// <-Faites attention à ne pas supprimer cette accolade 



    void EndDialogue() //Permet de fermer le dialogue vous ne touchez pas à part pour rajouter des ronds.
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
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
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
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
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

        // Active le dialogue et les contrôles
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
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
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
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

       
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
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
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
        allowSpace = true;
        Next(); 
    }
}




// FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and SceneChanges)
//ça c pour que ça sache sur quel bouton on a cliqué et donc sur quel dialogue on va déboucher
public void Choice1aFunct(){
    primeInt = 84;
    Choice1a.SetActive(false); //pour désactiver la vue des choix après que ça a été fait 
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

public void Choice2aFunct(){
    primeInt = 124;
    Choice2a.SetActive(false);// pareil pour désactiver la vue des choix après que ça a été fait
    Choice2b.SetActive(false);
    nextButton.SetActive(true);
    allowSpace = true;
}

public void Choice2bFunct(){
    primeInt = 144;
    Choice2a.SetActive(false);
    Choice2b.SetActive(false);
    nextButton.SetActive(true);
    allowSpace = true;
}
//ATTENTION POUR LES RAJOUTS DES CHOIX IL FAUT BIEN FAIRE EN SORTE QUE VOUS AVEZ RAJOUTE DES BOUTONS EN HAUT DU FICHIER 
// ET QUE VOUS AVEZ BIEN ACTIVE LE ONCLIK DANS L'INSPECTEUR ET RELIE A LA BONNE FONCTION SI VOUS Y ARRIVEZ PAS DEMANDEZ MOI. 

public void SaveName()
{
    if (!string.IsNullOrEmpty(nameInputField.text)) // Vérifie que le champ n'est pas vide
    {
        GameHandler.SetPlayerName(nameInputField.text); // Stocke le nom dans GameHandler
        
        // Cache l'interface de saisie du nom
        namePrompt.SetActive(false); 
        validateNameButton.gameObject.SetActive(false); 
        nameInputField.gameObject.SetActive(false);

        // Réaffiche la boîte de dialogue
        DialogueDisplay.SetActive(true); 

        primeInt = 5; // Passe au dialogue suivant
        Next(); // Affiche le prochain dialogue
    }
}



    //ça c si jamais vous voulez pas de dialogues mais genre allez dans une salle ou retourner en arrière
        public void Rond4_d()
        {
            //Il faut que ça ait le même nom que la scène si ça ne marche pas il faut me demander 
            //de faire un truc mais ça touche le github donc ne le faites pas sans en parler sinon ça va tout casser
            SceneManager.LoadScene("SceneCouloir");
        }

}
    









//TEMPLATE DE RAJOUT DE DIALOGUE DE BOUTON ETC COPIER COLLER AU BON ENDROIT ET MODIFIER SI BESOIN






// Dans public class Scene3Dialogue : MonoBehaviour
    //public GameObject Rond5; <- vous changez si vous voulez appeler ça autrement mais vous le changer partout
    //public GameObject Choice3a;//Pareil là vous faites attention au nommage ils ne peut pas y avoir 2 choice avec le même nom
   // public GameObject Choice3b;


    //private bool hasStartedRond5 = false; le nom de la variable pour vérifier si on est déjà passé là où pas





// Dans void Start()
    //Rond5.SetActive(false);//cache le bouton
   // Choice3a.SetActive(false);//cache les boutons de choix
   // Choice3b.SetActive(false);







   // Dans Next()

   //rond5_d
//        // if (primeInt == 210) LES PRIMEINT VOUS LES CHANGEZ MAIS VOUS FAITES ATTENTION A CE QUE VOUS METTEZ PAS DE DOUBLON ET VERIFIER QUE TOUT SE SUIT
//         {
//             ArtChar1a.SetActive(true);
//             Char1name.text = GameHandler.playerName; 
//             Char1speech.text = "C'est la porte du garage"; //je vais pas vous apprendre à changer les dialogues
//             primeInt++;
//         }
//         else if (primeInt == 211)
//         {
//             Char1name.text = GameHandler.playerName; 
//             Char1speech.text = "Je pourrais peut être l'ouvrir et m'echapper";
//             primeInt++;
//         }
//         else if (primeInt == 212)
//         {
//             Char1name.text = GameHandler.playerName; 
//             Char1speech.text = "avec un peu de force ";
//             primeInt++;
//         }

// else if (primeInt == 213){  
//     Char1name.text = GameHandler.playerName; 
//     Char1speech.text = "Je tente ou pas ?";
//     nextButton.SetActive(false);//ça fait en sorte qu'on ne puisse pas passer le dialogue 
//     allowSpace = false;// N'autorise pas pas le passage au dialogue suivant avec la barre espace
//     Choice3a.SetActive(true); ici faut que ce soit le même nom que vous avez défini avant vérifiez bien. 
//     Choice3b.SetActive(true);
// }

// // après le choix 1a
// else if (primeInt == 214){
//     Char1name.text = GameHandler.playerName; 
//     Char1speech.text = "choix1 porte";
//     primeInt = 215; //Il faut que tu expliques ici Yussera
// }
// else if (primeInt == 215){
//     Char1name.text = GameHandler.playerName; 
//     Char1speech.text = "Je suis le choix après 1";
//     primeInt++;
// }
// else if (primeInt == 216){
//     Char1name.text = GameHandler.playerName; 
//     Char1speech.text = "On parle et parlote";
//     primeInt++;
// }
// else if (primeInt == 217){
//     EndDialogue();
// }

// // après le choix 1b
// else if (primeInt == 224){
//     Char1name.text = GameHandler.playerName; 
//     Char1speech.text = "choix2 porte";
//     primeInt = 225; 
// }
// else if (primeInt == 225){
//     Char1name.text = GameHandler.playerName; 
//     Char1speech.text = "Je suis le choix après 2";
//     primeInt++;
// }
// else if (primeInt == 226){
//     Char1name.text = GameHandler.playerName; 
//     Char1speech.text = "on parle et parlotte toujours";
//     primeInt++;
// }
// else if (primeInt == 227){
//     EndDialogue();
// }




        // //rond5
        //         if (primeInt == 499)
        // {
        //     Char1name.text = GameHandler.playerName; 
        //     Char1speech.text = "Je suis déjà passé par là.";
        //     primeInt++;
        // }
        // else if (primeInt == 500)
        // {
        //     Char1name.text = GameHandler.playerName; 
        //     Char1speech.text = "Je ne vais pas perdre mon temps ici.";
        //     primeInt++;
        // }
        // else if (primeInt == 501)
        // {
        //     EndDialogue();
        // }







//EN BAS DES AUTRES PUBLIC VOID 

// public void Rond5_d()//si vous avez changé le nom bah changez le ici
// {
//     if (!hasStartedRond5) // Le nom de la variable que vous avez mis
//     {
//         hasStartedRond5 = true;
//         primeInt = 210; //Reliez ça au bon dialogue 

        
//         Rond1.SetActive(false);
//         Rond2.SetActive(false);
//         Rond3.SetActive(false);
//         Rond4.SetActive(false);
        // Rond5.SetActive(false);

//         // Active le dialogue et les contrôles
//         DialogueDisplay.SetActive(true);
//         nextButton.SetActive(true);
//         allowSpace = true;
//         Next(); 
//     }
//     else if (hasStartedRond5) // Si déjà visité
//     {
//         primeInt = 499; 

//         Rond1.SetActive(false);
//         Rond2.SetActive(false);
//         Rond3.SetActive(false);
//         Rond4.SetActive(false);
//         Rond5.SetActive(false);
//         DialogueDisplay.SetActive(true);
//         nextButton.SetActive(true);
//         allowSpace = true;
//         Next(); 
//     }
// }




// public void Choice3aFunct(){
//     primeInt = 214;  <- Vous vérifier que ça emmène au bon endroit
//     Choice3a.SetActive(false);// pareil pour désactiver la vue des choix après que ça a été fait
//     Choice3b.SetActive(false);
//     nextButton.SetActive(true);
//     allowSpace = true;
// }

// public void Choice3bFunct(){
//     primeInt = 224;  <- Vous vérifier que ça emmène au bon endroit
//     Choice3a.SetActive(false);
//     Choice3b.SetActive(false);
//     nextButton.SetActive(true);
//     allowSpace = true;
// }