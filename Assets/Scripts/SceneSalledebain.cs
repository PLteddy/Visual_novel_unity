using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneSalledebain : MonoBehaviour //Vous changez le nom template en fonction du nom de votre scène
{
    //ça c pour déclarer les variables que vous allez utilisez dans le script 
    //Donc c ici que vous gérez les ajouts d'objets interactif ou de choix 
    public int primeInt = 1;        
    public TMP_Text Char1name;//C le nom du perso principal !ne pas touchez!
    public TMP_Text Char1speech;//C le texte du perso principal !ne pas touchez!
    public GameObject DialogueDisplay;//C les bulles de dialogues !ne pas touchez!
    public GameObject ArtChar1a;//C la photo du perso principal !ne pas touchez!
    public GameObject ArtBG1;
    public GameObject ArtBG2;//C l'arrière plan !ne pas touchez!
    public GameObject Rond1; //c le bouton qui permet de lancer un dialogue relié à rond1 il faut copier et coller pour en rajouter
    public GameObject Rond2;
    public GameObject Rond3;
    public GameObject Rond5;
    public GameObject Rond6;
    public GameObject Choice1a;//c les boutons qui permettent de choisir les choix il faut copier et coller pour en rajouter
    public GameObject Choice1b;
    public GameObject Choice2a;
    public GameObject Choice2b;
    public GameObject Choice3a;
    public GameObject Choice3b;
    public GameObject nextButton;


    private bool allowSpace = true;// !ne pas touchez!




    //Variable pour vérifier que le joueur est déjà passé par là
    //a chaque fois que vous rajouter un dialogue + un bouton genre rond 5 vous devez mettre une variable pour vérifier
    private bool hasStartedDialogue = false;
    private bool hasStartedRond2 = false;
    private bool hasStartedRond3 = false;
    private bool hasStartedRond5 = false;
    private bool hasStartedRond6 = false;
    void Start()
{
    //pour tester le premier passage à chaque fois :
    //!toucher seulement le nom de la variable ou me demander pour savoir si on retire le truc en bas! 
    DialogueDisplay.SetActive(false);//cache la bulle de dialogue
    ArtChar1a.SetActive(false);//cache l'image du personnage 
    ArtBG1.SetActive(true); //affiche l'arrière plan
    ArtBG2.SetActive(false);
    Rond1.SetActive(false); //cache les endroits cliquables
    Rond2.SetActive(false);
    Rond3.SetActive(false);
    Rond5.SetActive(false);
    Rond6.SetActive(false);
    Choice1a.SetActive(false);//cache les boutons de choix
    Choice1b.SetActive(false);
    Choice2a.SetActive(false);
    Choice2b.SetActive(false);
    Choice3a.SetActive(false);
    Choice3b.SetActive(false);
    nextButton.SetActive(true); //ça permet de faire next dans le dialogue d'introduction de la salle

int visiteSDB = PlayerPrefs.GetInt("SceneSDBFirstTime", 1);

if (visiteSDB == 1) // Si c'est la première fois
    {
        primeInt = 1;
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
        Next();
        
        PlayerPrefs.SetInt("SceneSDBFirstTime", 2); // Marque la salle comme visitée
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
            Char1speech.text = "Je suis dans une salle....d'opération ?"; //là c les dialogues
            primeInt++; //pour que ça incrémente le dialogue 
        }
        else if (primeInt == 2)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Yerk c'est quoi cette odeur infâme ?";
            primeInt++;
        }
        else if (primeInt == 3)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Il a dû s'y passer des choses horribles ici...";
            primeInt++;
        }
        else if (primeInt == 4)
        {
            EndDialogue(); //emmène à la clôture du dialogue
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
        Char1speech.text = "Cette commode ne me dit rien qui vaille";
        primeInt++;
    }
    else if (primeInt == 41)
    {
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "Je vais quand même jeter un oeil";
        primeInt++;
    }
    else if (primeInt == 42)
    {
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "Ah c'est vide mais ça empeste le fer...";
        primeInt++;
    }
    else if (primeInt == 43)
    {
        EndDialogue();
    }
//rond2_d
    if (primeInt == 50)
    {
        ArtChar1a.SetActive(true);
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "Cette table d'opération a dû être le théâtre de choses si sordides.";
        primeInt++;
    }
    else if (primeInt == 51)
    {
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "Brrr...je ne veux pas savoir ce qui s'est passé ici.";
        primeInt++;
    }
    else if (primeInt == 52)
    {
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "Rien que d'y penser j'en ai des frissons.";
        primeInt++;
    }
    else if (primeInt == 53)
    {
        EndDialogue();
    }

//rond3_d
        if (primeInt == 80)
        {
            ArtChar1a.SetActive(true);
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Une lampe ..?";
            primeInt++;
        }
else if (primeInt == 81){  //C'est pour les choix faites attention ici où ça va pas marcher
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Je pourrais l'éteindre ?";
    nextButton.SetActive(false);//ça fait en sorte qu'on ne puisse pas passer le dialogue 
    allowSpace = false;// N'autorise pas pas le passage au dialogue suivant avec la barre espace
    Choice1a.SetActive(true);//active les choix possibles
    Choice1b.SetActive(true);//active les choix possibles
}

// après le choix 1a
else if (primeInt == 82){
    ArtBG1.SetActive(false); //affiche l'arrière plan
    ArtBG2.SetActive(true);
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Il fait si sombre...";
    primeInt = 83; 
}
else if (primeInt == 83){
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Mais c'est quoi ces trucs ? Qui est le fou qui a écrit ça ?";
    primeInt++;
}
else if (primeInt == 84){
    EndDialogue();
}

// après le choix 1b
else if (primeInt == 94){
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Finalement laissons la lumière allumée.";
    primeInt = 95; 
}
else if (primeInt == 95){
    EndDialogue();
}


//Rond5_d

        if (primeInt == 120)
        {
            ArtChar1a.SetActive(true);
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Un frigo ? Dans une salle d'opération ?";
            primeInt++;
        }
        else if (primeInt == 121)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Je me demande ce qu'il y a dedans...";
            primeInt++;
        }
        else if (primeInt == 122)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = $"Peut-être que...? Non {GameHandler.playerName}, tu t'imagines trop de choses.";
            primeInt++;
        }

                else if (primeInt == 123)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Toute façon on est dans la vraie vie ici, pas dans un film. Y aura forcément des cannettes, des restes de repas ou des médocs.";
            primeInt++;
        }

else if (primeInt == 124){
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Rien de plus...";
    nextButton.SetActive(false);
    allowSpace = false;
    Choice2a.SetActive(true);
    Choice2b.SetActive(true);
}

// après choix 2a - changement de scène
        else if (primeInt == 125) {  
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Je vais voir ce qu'il y a là dedans.";
            primeInt = 126;
        }
        else if (primeInt == 126) {  
            SceneManager.LoadScene("SceneFrigo"); // Remplace par le nom de la scène suivante
        }

// après choix 2b
else if (primeInt == 144){
    Char1name.text = GameHandler.playerName;
    Char1speech.text = "Toute façon ça ne m'intéresse pas.";
    primeInt = 145; 
}
else if (primeInt == 145){
    EndDialogue();
}
   //rond6_d
       if (primeInt == 160) 
        {
            ArtChar1a.SetActive(true);
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Une porte ? Je me demande ce qu'il y a derrière."; //je vais pas vous apprendre à changer les dialogues
            primeInt++;
        }
        else if (primeInt == 161){
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "Et si j'essayais de l'ouvrir ?";
        nextButton.SetActive(false);
        allowSpace = false;
        Choice3a.SetActive(true);
        Choice3b.SetActive(true);
        }
        // Si le joueur choisit d'ouvrir la porte
        else if (primeInt == 162) {  
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Je vais tenter ma chance.";
            primeInt = 163;
        }
        else if (primeInt == 163) {  
            SceneManager.LoadScene("SceneCouloir"); // Remplace par le nom de la scène suivante
        }
        //si le joueur choisit de pas ouvrir la porte
        else if (primeInt == 164) {  
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Non, mieux vaut ne pas prendre de risques.";
            primeInt++;
        }
        else if (primeInt == 165) {  
            EndDialogue(); // Fin du dialogue, retour au gameplay normal
        }


// Dialogue lorsqu'on on rappuie sur les boutons 

//rond1
        if (primeInt == 199)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Cette commode est toujours aussi vide.";
            primeInt++;
        }
        else if (primeInt == 200)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "En plus elle pue, pauvre commode.";
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
            Char1speech.text = "Cette table d'opération est toujours aussi effrayante.";
            primeInt++;
        }
        else if (primeInt == 300)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Même un peu trop propre à mon goût.";
            primeInt++;
        }
        else if (primeInt == 301)
        {
            EndDialogue();
        }


        //rond3
            if (primeInt == 399)
        {
        ArtBG1.SetActive(false); //affiche l'arrière plan
        ArtBG2.SetActive(true);
        Char1name.text = GameHandler.playerName;
        Char1speech.text = "Il fait si sombre...";
        primeInt++;
        }
        else if (primeInt == 400)
        {
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Mais c'est quoi ces trucs ? Qui est le fou qui a écrit ça ?";
            primeInt++;
        }
        else if (primeInt == 401)
        {
            EndDialogue();
        }

        //rond5
        else if (primeInt == 499) {  
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Je vais voir ce qu'il y a là dedans.";
            primeInt = 500;
        }
        else if (primeInt == 500) {  
            SceneManager.LoadScene("SceneFrigo"); // Remplace par le nom de la scène suivante
        }

        //rond6
        else if (primeInt == 599) {  
            Char1name.text = GameHandler.playerName;
            Char1speech.text = "Je vais tenter ma chance.";
            primeInt = 600;
        }
        else if (primeInt == 600) {  
            SceneManager.LoadScene("SceneCouloir"); // Remplace par le nom de la scène suivante
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
        Rond5.SetActive(true);
        Rond6.SetActive(true);
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
        Rond5.SetActive(false);
        Rond6.SetActive(false);
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
        Rond5.SetActive(false);
        Rond6.SetActive(false);
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
        primeInt = 50;

        
        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond5.SetActive(false);
        Rond6.SetActive(false);
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
        Rond5.SetActive(false);
        Rond6.SetActive(false);
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
        primeInt = 80;

       
        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond5.SetActive(false);
        Rond6.SetActive(false);
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
        Rond5.SetActive(false);
        Rond6.SetActive(false);
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
        allowSpace = true;
        Next(); 
    }
}

public void Rond5_d() //pareil que rond1
{
    if (!hasStartedRond5)// Si non visité
    {
        hasStartedRond5 = true;
        primeInt = 120;

       
        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond5.SetActive(false);
        Rond6.SetActive(false);
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
        allowSpace = true;
        Next(); 
    }
    else if (hasStartedRond5) // Si déjà visité
    {
        primeInt = 499; 

        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond5.SetActive(false);
        Rond6.SetActive(false);
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
        allowSpace = true;
        Next(); 
    }
}

public void Rond6_d() //pareil que rond1
{
    if (!hasStartedRond6)// Si non visité
    {
        hasStartedRond6 = true;
        primeInt = 160;

       
        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond5.SetActive(false);
        Rond6.SetActive(false);
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
        allowSpace = true;
        Next(); 
    }
    else // Si déjà visité
    {
        primeInt = 599; 

        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond5.SetActive(false);
        Rond6.SetActive(false);
        DialogueDisplay.SetActive(true);
        nextButton.SetActive(true);
        allowSpace = true;
        Next(); 
    }
}



// FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and SceneChanges)
//ça c pour que ça sache sur quel bouton on a cliqué et donc sur quel dialogue on va déboucher
public void Choice1aFunct(){
    primeInt = 82;
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
    primeInt = 125;
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
public void Choice3aFunct(){
    primeInt = 162;
    Choice3a.SetActive(false);// pareil pour désactiver la vue des choix après que ça a été fait
    Choice3b.SetActive(false);
    nextButton.SetActive(true);
    allowSpace = true;
}

public void Choice3bFunct(){
    primeInt = 164;
    Choice3a.SetActive(false);
    Choice3b.SetActive(false);
    nextButton.SetActive(true);
    allowSpace = true;
}
//ATTENTION POUR LES RAJOUTS DES CHOIX IL FAUT BIEN FAIRE EN SORTE QUE VOUS AVEZ RAJOUTE DES BOUTONS EN HAUT DU FICHIER 
// ET QUE VOUS AVEZ BIEN ACTIVE LE ONCLIK DANS L'INSPECTEUR ET RELIE A LA BONNE FONCTION SI VOUS Y ARRIVEZ PAS DEMANDEZ MOI. 

}
    









