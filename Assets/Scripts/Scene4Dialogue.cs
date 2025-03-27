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
    public GameObject ArtBG2;
    public GameObject ArtBG3;
    public GameObject ArtBG4;
    public GameObject ArtBG5;
    public GameObject Rond1; //c le bouton qui permet de lancer un dialogue relié à rond1 il faut copier et coller pour en rajouter
    public GameObject Rond2;
    public GameObject Rond3;
    public GameObject Rond4;
    public GameObject Choice1aForce;
    public GameObject Choice1bIntelligence;
    public GameObject Choice2aOuvrirArmoire;
    public GameObject Choice3aPiedBiche;//c les boutons qui permettent de choisir les choix il faut copier et coller pour en rajouter
    public GameObject Choice3bAutreSolution;
    public GameObject Choice4aArranger;
    public GameObject Choice4bPeter;
    public GameObject Choice5aSauter;
    public GameObject Choice5bPasSauter;
    public GameObject Choice6aTable;
    public GameObject Choice7aTapis;
    public GameObject Choice8aTrappe;
    public GameObject Choice8bAutreSolution;
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
    private bool hasStartedRond4 = false;
    private bool piedDeBiche = false;

    void Start()
{
    //pour tester le premier passage à chaque fois :
    
    DialogueDisplay.SetActive(false);//cache la bulle de dialogue
    ArtChar1a.SetActive(false);//cache l'image du personnage 
    ArtBG1.SetActive(true);
    ArtBG2.SetActive(false);
    ArtBG3.SetActive(false);
    ArtBG4.SetActive(false);
    ArtBG5.SetActive(false);
    Rond1.SetActive(false); //cache les endroits cliquables
    Rond2.SetActive(false);
    Rond3.SetActive(false);
    Rond4.SetActive(false);
    Choice1aForce.SetActive(false);//cache les boutons de choix
    Choice1bIntelligence.SetActive(false);
    Choice2aOuvrirArmoire.SetActive(false);
    Choice3bAutreSolution.SetActive(false);
    Choice3aPiedBiche.SetActive(false);
    Choice4aArranger.SetActive(false);
    Choice4bPeter.SetActive(false);
    Choice5aSauter.SetActive(false);
    Choice5bPasSauter.SetActive(false);
    Choice6aTable.SetActive(false);
    Choice7aTapis.SetActive(false);
    Choice8aTrappe.SetActive(false);
    Choice8bAutreSolution.SetActive(false);

    namePrompt.SetActive(false); // Cache la saisie de nom au départ
    validateNameButton.gameObject.SetActive(false); 
    nameInputField.gameObject.SetActive(false);


    //pas toucher à part pour changer le nom de la variable 
    firstTime = PlayerPrefs.GetInt("SceneGrenierFirstTime", 0) == 0;

    if (firstTime)// si c la première fois ça fait appraître un dialogue pour la découverte de la salle
    {
        primeInt = 1;// Prime int est définit à 1
        DialogueDisplay.SetActive(true); // la bulle de dialogue apparaît

        Next(); //Quand vous voyez ça veut dire que ça emmène dans Next donc vérifier le primeInt pour voir dans quel dialogue ça emmène
        PlayerPrefs.SetInt("SceneGrenierFirstTime", 1);//Transforme le booléen en 1 au lieu de 0 pour dire qu'on est passé
    }
    else //sinon ça fait un autre dialogue en mode g déjà vu ça
    {
        DialogueDisplay.SetActive(true);// la bulle de dialogue apparaît

        primeInt = 899; // Prime int est définit à 99
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

if (primeInt == 899)
{
    ArtBG1.SetActive(false);
    ArtBG2.SetActive(true);
    primeInt = 30;
}


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
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Je me souviens de tout maintenant !";
    primeInt++;
}
else if (primeInt == 7)
{
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Je rentrais de l'école quand un homme m'a frappé à la tête par derrière avec une batte. Ça m'a direct mis KO.";
    primeInt++;
}
else if (primeInt == 8)
{
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "La dernière chose dont je me souviens c'est le bruit d'une voiture allant à toute vitesse.";
    primeInt++;
}
else if (primeInt == 9)
{
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Il a dû me mettre dans le coffre de sa voiture et m'emmener… je ne sais pas où… ";
    primeInt++;
}
else if (primeInt == 10)
{
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Je ne comprend même pas pourquoi cet homme m'a kidnappé, ça me fait peur...";
    primeInt++;
}
else if (primeInt == 11)
{
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Allez ressaisis-toi! ce n'est pas comme ça que je pourrais sortir de là surtout qu'il peut revenir!";
    primeInt++;
}
else if (primeInt == 12)
{
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Il faut que je me tire de là mais comment me défaire de ces cordes?";
    primeInt++;
}
//Premier choix du joueur
else if (primeInt == 13){  //C'est pour les choix faites attention ici où ça va pas marcher
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Je pourrais…";
    allowSpace = false;// N'autorise pas pas le passage au dialogue suivant avec la barre espace
    Choice1aForce.SetActive(true);//active les choix possibles
    Choice1bIntelligence.SetActive(true);//active les choix possibles
    
}

// après le choix 2a Où on utilise la force
else if (primeInt == 15){

    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Bon comment je vais faire? Avec la force de mes bras j'essaye de tirer sur la corde mais sans espoir, ça me fait si mal. ";
    primeInt++;
}
else if (primeInt == 16)
{
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Je commence à m'essouffler à essayer de tirer cette corde avec mes mains, mes bras, mes pieds, mes dents...";
    primeInt++;
}
else if (primeInt == 17)
{
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "tout ce qui pourrait m'aider à créer suffisamment d'espace pour que je puisse m'échapper. Mais rien n'y fait… ";
    primeInt++;
}
else if (primeInt == 18)
{
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Même ronger la corde avec mes dents ne change rien, il n'y a que dans les films que ça marche.";
    primeInt++;
}
else if (primeInt == 19)
{
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "En désespoir de cause, je me bascule de gauche à droite sur la chaise pour me faire tomber. Aller un peu de nerfs !";
    primeInt++;
}
else if (primeInt == 20)
{
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Avec de l'acharnement, je prends de la vitesse, la chaise tombe avec moi.";
    primeInt++;
}
else if (primeInt == 21)
{
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Outch... ça fais mal à la tête (- 1 de vie), je n'avais pas pensé au fait que je n'aurais pas mes mains pour me réceptionner";
    GameHandler.playerHealth -= 1;//perte de vie 
    primeInt++;
}
else if (primeInt == 22)
{
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "mais la technique a quand même été efficace ! ";
    primeInt++;
}
else if (primeInt == 23)
{
    ArtBG2.SetActive(false);
    ArtBG2.SetActive(true);
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "En tombant la pauvre chaise en bois s'est cassé, ça a créer assez d'espace pour que je m'extirpe de là.";
    primeInt=30;
}


// après le choix 1b Où on utilise l'intelligence
else if (primeInt == 25){

    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Comment c'était déjà dans les vidéos de comment se défaire de ces liens, ça va m'être utile finalement !";
    primeInt++;
}
else if (primeInt == 26){

    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Ah oui, il faut que je fasse passer la corde qui me retient à la chaise à l'intérieur du bout de corde qui sert mon poignet";
    primeInt++;
}
else if (primeInt == 27){

    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "comme ça, ça créer un espace pour que je puisse retirer la corde qui me ligote à cette foutue chaise et voilà !";
    primeInt++;
}
else if (primeInt == 28){

    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Pfiou moi qui pensais que j'étais parano à regarder ce genre de vidéo.";
    primeInt = 24;
}
else if (primeInt == 24)
{
    ArtBG1.SetActive(false);
    ArtBG2.SetActive(true);
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "Maintenant je peux accéder au reste de la pièce, il faut que je l'inspecte pour trouver une sortie.";
    primeInt = 30;
}
else if (primeInt == 30) //mettre quand le numéro du dialogue qui se finit
{

    EndDialogue();//emmène à la clôture du dialogue
}

        

//rond1Porte
    if (primeInt == 40)
    {        

        ArtChar1a.SetActive(true);
        Char1name.text = GameHandler.playerName; 
        Char1speech.text = "Est-ce que je pourrais simplement passer par la porte ?";

        primeInt++;
    }
    else if (primeInt == 41)
    {
        SceneManager.LoadScene("ScenePorte");
    }

//rond2Armoire
    else if (primeInt == 50){  //C'est pour les choix faites attention ici où ça va pas marcher
        Char1name.text = GameHandler.playerName; 
        Char1speech.text = "Cette armoire à l'air bancale, que devrais-je faire ?";
        allowSpace = false;// N'autorise pas pas le passage au dialogue suivant avec la barre espace
        Choice2aOuvrirArmoire.SetActive(true);//active les choix possibles
        
        
    
    }
    else if (primeInt == 51)
    {

    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "J'ai toujours eu peur d'ouvrir les armoires sans savoir ce qu'il y a à l'intérieur...";
    primeInt++;
    }
    else if (primeInt == 52)
    {

    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "J'ouvre précautionneusement l'armoire pour y découvrir... un pied-de-biche usagé sur le coin de l'armoire.";
    primeInt++;
    }
    else if (primeInt == 53)
    {
    
    Char1name.text = GameHandler.playerName; 
    Char1speech.text = "J'ai pris le pied-de-biche, on ne sait jamais s'il peut me servir à quelque chose.";
    piedDeBiche = true;
    primeInt++;
    }
    else if (primeInt == 54)
    {
        EndDialogue();
    }
    else if (primeInt == 55) // Cas du "je suis déjà passé"
        {
           
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "...";

            allowSpace = false;// N'autorise pas pas le passage au dialogue suivant avec la barre espace
            Choice3aPiedBiche.SetActive(true);//active les choix possibles
            Choice3bAutreSolution.SetActive(true);
        }
        else if (primeInt == 56)
        {
            EndDialogue();//emmène à la clôture du dialogue
        }
        //Quand on revient sur le bouton de l'armoire pour la bouger
        else if (primeInt == 58)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Avec le pied-de-biche que j'ai récupéré je peux bouger cette armoire.";
            primeInt++;
        }
        else if (primeInt == 59)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je place mon outil sur le côté droit de l'armoire pour faire un levier.";
            primeInt++;
        }
        else if (primeInt == 60)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "À la une !";
            primeInt++;
        }
        
        else if (primeInt == 60)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "À la deux ! À la trois !";
            primeInt++;
        }
        else if (primeInt == 61)
        {
            ArtBG2.SetActive(false);
            ArtBG3.SetActive(true);
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "En poussant sur mon levier improvisé de fortune de toutes mes forces, l'armoire tombe à la renverse sur le côté,";
            primeInt++;
        }
        else if (primeInt == 62)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "me laissant apercevoir une bouche d'aération derrière celle-ci !";
            primeInt++;
        }
        else if (primeInt == 63)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Par contre, le pied-de-biche n'a pas tenu le coup, je ne pourrais plus l'utiliser.";
            primeInt++;
        }
        else if (primeInt == 64)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Ce n'est pas grave, je vois enfin une possibilité de sortir de cette pièce !";
            primeInt++;
        }
        else if (primeInt == 65)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je m'infiltre dans le conduit d'aération… ";
            primeInt++;
        }
        else if (primeInt == 66)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Il fait noir, je sens la canalisation grincer, elle pourrait s'effondrer à tout moment ! ";
            primeInt++;
        }
        else if (primeInt == 67)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Comme si quelqu'un m'avait entendu le sol s'effondre sous moi et je tombe dans les abysses.";
            primeInt++;
        }
        else if (primeInt == 68)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "HHHHHHHHAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            primeInt++;
        }
        else if (primeInt == 69)
        {
            SceneManager.LoadScene("SceneSalledebain");
        }



//Rond3Fenêtre

        if (primeInt == 70)
        {
            ArtChar1a.SetActive(true);
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Oh je pourrais m'échapper par la fenêtre, non ?";
            primeInt++;
        }
        else if (primeInt == 71)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "J'essaye de l'ouvrir mais je n'y arrive pas, elle a l'air bloqué,";
            primeInt++;
        }
        else if (primeInt == 72)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "elle n'est pas toute jeune et ce n'est même pas du double vitrage…";
            primeInt++;
        }
        else if (primeInt == 73)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Mais bien sûr comme si ça pouvait être simple…";
            primeInt++;
        }

        else if (primeInt == 74){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Est-ce que je pourrais…";
            allowSpace = false;
            Choice4aArranger.SetActive(true);
            Choice4bPeter.SetActive(true);
        }

        // après choix 4a d'arranger la fenêtre
        else if (primeInt == 75){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Si j'arrange la fenêtre en comprenant pourquoi elle ne s'ouvre pas, je devrai pouvoir ouvrir cette foutue fenêtre. ";
            primeInt++;
        }
        else if (primeInt == 76){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "J'inspecte la fenêtre de tous les angles en espérant trouver quelque chose qui explique son entêtement… ";
            primeInt++;
        }
        else if (primeInt == 77){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "On dirait que la poignée de la fenêtre est coincée par un bout de métal qui passe de part et d'autre de la poignée.";
            primeInt++;
        }
        else if (primeInt == 78){
            ArtBG2.SetActive(false);
            ArtBG4.SetActive(true);
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "En l'enlevant délicatement, je peux maintenant ouvrir la fenêtre !";
            primeInt = 84;
        }

        //après choix 4b de péter la fenêtre
        else if (primeInt == 79){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Aller, je n'ai pas de temps à perdre, je dois vite sortir de là. ";
            primeInt++;
        }
        else if (primeInt == 80){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je m'éloigne de la fenêtre et je cours dans sa direction pour défoncer la fenêtre avec mon épaule";
            primeInt++;
        }
        else if (primeInt == 81){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "comme pour enfoncer une porte.";
            primeInt++;
        }
        else if (primeInt == 82){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "J'aurais dû le voir venir, un bout de verre s'est planté dans mon bras… (-2 de vie)";

            GameHandler.playerHealth -= 2;//perte de vie 

            primeInt++;
        }
        else if (primeInt == 83){
            ArtBG2.SetActive(false);
            ArtBG4.SetActive(true);
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Aïe Aïe Aïe, ça fait un mal de chien, mais au moins, je peux passer par la fenêtre mais voyons d'abord ce qu'il y a en dessous.";
            primeInt++;
        }
        //Les choix se rejoigne ici
        else if (primeInt == 84){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je suis au deuxième ou troisième étage peut-être, en dessous de moi il y a le jardin.";
            primeInt++;
        }
        else if (primeInt == 85){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Si je descends, j'atterrirai dans de l'herbe,";
            primeInt++;
        }
        else if (primeInt == 86){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "ce n'est pas du goudron heureusement, mais je ne sais pas si ce n'est pas trop haut pour moi.";
            primeInt++;
        }
        else if (primeInt == 87){  //C'est pour les choix faites attention ici où ça va pas marcher
        Char1name.text = GameHandler.playerName; 
        Char1speech.text = "Que devrais-je faire ?";
        allowSpace = false;// N'autorise pas pas le passage au dialogue suivant avec la barre espace
        Choice5aSauter.SetActive(true);//active les choix possibles
        Choice5bPasSauter.SetActive(true);
        
        }
        // Après le choix de sauter
        else if (primeInt == 90){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Il faut vraiment que je sorte de là au plus vite avant que l'autre taré ne revienne… ";
            primeInt++;
        }
        else if (primeInt == 91){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je prends mon courage à deux mains et je passe par la fenêtre que j'ai brisé,";
            primeInt++;
        }
        else if (primeInt == 92){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "m'accroupissant sur le rebord de la fenêtre, je saute ! ";
            primeInt++;
        }
        else if (primeInt == 93){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Quand mes pieds se réceptionnent sur le sol, j'entends mes os craquer. ARRRRRGHH, je n'ai jamais senti une douleur aussi intense !";
            primeInt++;
        }
        else if (primeInt == 94){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "À cause de la douleur, je suis tombé à la renverse. Je suis maintenant allongé sur le sol incapable de bouger… ";
            primeInt++;
        }
        else if (primeInt == 95){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je sens que ma vision se brouille, je me sens partir, j'ai froid, est ce que c'est la fin ?";
            primeInt=588;
        }
        else if (primeInt == 588){
            SceneManager.LoadScene("SceneLoose");
        }

        //Ne pas sauter
        else if (primeInt == 96){
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "C'est trop risqué, je vais voir ailleurs pour trouver une autre solution.";
            primeInt++;
        }
        else if (primeInt == 97){
            EndDialogue();
        }



//rond4 Table
        if (primeInt == 100)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je suis sûr qu'il y a quelque chose sous la table. ";
            primeInt++;
        }
        else if (primeInt == 101)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je regarde sous la table en espérant un indice comme dans l'escape game que j'avais fait avec ma famille…";
            primeInt++;
        }
        else if (primeInt == 102)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Mais le seul truc que j'ai trouvé, c'est la nostalgie d'être loin de ma famille pendant que moi, je suis dans cet endroit sordide…";
            primeInt++;
        }
        else if (primeInt == 103){  //C'est pour les choix faites attention ici où ça va pas marcher
        Char1name.text = GameHandler.playerName; 
        Char1speech.text = "Je me demande ce que je peux faire d'autre?";
        allowSpace = false;// N'autorise pas pas le passage au dialogue suivant avec la barre espace
        Choice6aTable.SetActive(true);//active les choix possibles
        
        }
        else if (primeInt == 104)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Je peux bouger la table mais rien ne se passe…";
            primeInt++;
        }
        else if (primeInt == 105){  //C'est pour les choix faites attention ici où ça va pas marcher
        Char1name.text = GameHandler.playerName; 
        Char1speech.text = "Je me demande ce que je peux faire d'autre?";
        allowSpace = false;// N'autorise pas pas le passage au dialogue suivant avec la barre espace
        Choice7aTapis.SetActive(true);
        
        }
        else if (primeInt == 106)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Et sous le tapis ? Il n'y aurait pas quelque chose?";
            primeInt++;
        }
        else if (primeInt == 107)
        {
            ArtBG2.SetActive(false);
            ArtBG5.SetActive(true);
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Bingo une trappe ! Mais elle est bloqué et il n'y a pas l'air d'avoir de clé, est ce qu'il y aurait quelque chose qui pourrait m'aider ?";
            primeInt++;
        }
        else if (primeInt == 108){  //C'est pour les choix faites attention ici où ça va pas marcher
            if (piedDeBiche)
            {
                Char1name.text = GameHandler.playerName; 
                Char1speech.text = "Je me demande ce que je peux faire d'autre?";
                allowSpace = false; // N'autorise pas le passage au dialogue suivant avec la barre espace
                Choice8aTrappe.SetActive(true); // active les choix possibles
                primeInt = 110;
            }
            else
            {
                Char1name.text = GameHandler.playerName;
                Char1speech.text = "Il me manque quelque chose, je reviendrai plus tard.";
                primeInt++;
            }
        
        }
        else if(primeInt == 109){
            EndDialogue();
        }
        else if(primeInt == 110){
            Char1speech.text = "En imbriquant le pied de biche dans la fente de la trappe, je pousse de toutes mes forces pour faire un effet de levier.";
            primeInt++;
        }
          
        
        else if (primeInt == 111)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Après quelques efforts, j'arrive à ouvrir la trappe.";
            primeInt++;
        }
        else if (primeInt == 112)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Par contre, le pied de biche n'a pas tenu le coup, je ne pourrais plus l'utiliser.";
            primeInt++;
        }
        else if (primeInt == 113)
        {
            Char1name.text = GameHandler.playerName; 
            Char1speech.text = "Une échelle descends vers le bas et je la descends prudemment.";
            primeInt++;
        }
        else if (primeInt == 114)
        {
            SceneManager.LoadScene("SceneSalledebain");
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
        Rond4.SetActive(false);

        // Active le dialogue et les contrôles
        DialogueDisplay.SetActive(true);
        allowSpace = true;
        Next(); 
    }
    else if (hasStartedRond2) // Si déjà visité
    {
        primeInt = 55; 

        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond4.SetActive(false);
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
        primeInt = 70;

       
        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond4.SetActive(false);

       
        DialogueDisplay.SetActive(true);
        allowSpace = true;
        Next(); 
    }
    else if (hasStartedRond3) // Si déjà visité
    {
        primeInt = 87; 

        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond4.SetActive(false);
        DialogueDisplay.SetActive(true);
        allowSpace = true;
        Next(); 
    }
}

public void Rond4_d()
{
    if (!hasStartedRond4)// Si non visité
    {
        hasStartedRond4 = true;
        primeInt = 100;

       
        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond4.SetActive(false);

       
        DialogueDisplay.SetActive(true);
        allowSpace = true;
        Next(); 
    }
    else if (hasStartedRond4) // Si déjà visité
    {
        primeInt = 108; 

        Rond1.SetActive(false);
        Rond2.SetActive(false);
        Rond3.SetActive(false);
        Rond4.SetActive(false);
        DialogueDisplay.SetActive(true);
        allowSpace = true;
        Next(); 
    }
}



// FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and SceneChanges)
//ça c pour que ça sache sur quel bouton on a cliqué et donc sur quel dialogue on va déboucher


public void Choice1aForceFunct(){
    primeInt = 15;
    Choice1aForce.SetActive(false); //pour désactiver la vue des choix après que ça a été fait 
    Choice1bIntelligence.SetActive(false);
    allowSpace = true;
}
public void Choice1bIntelligenceFunct(){
    primeInt = 25;
    Choice1aForce.SetActive(false); //pour désactiver la vue des choix après que ça a été fait 
    Choice1bIntelligence.SetActive(false);
    allowSpace = true;
}
public void Choice2aOuvrirArmoireFunct(){
    primeInt = 51;
    Choice2aOuvrirArmoire.SetActive(false); //pour désactiver la vue des choix après que ça a été fait 
    allowSpace = true;
}
public void Choice3aPiedBicheFunct(){
    primeInt = 58;
    Choice3aPiedBiche.SetActive(false); //pour désactiver la vue des choix après que ça a été fait 
    Choice3bAutreSolution.SetActive(false);
    allowSpace = true;
}
public void Choice3bAutreSolutionFunct(){
    primeInt = 56;
    Choice3aPiedBiche.SetActive(false);
    Choice3bAutreSolution.SetActive(false);
    allowSpace = true;
}

public void Choice4aArrangerFunct(){
    primeInt = 75;
    Choice4aArranger.SetActive(false);// pareil pour désactiver la vue des choix après que ça a été fait
    Choice4bPeter.SetActive(false);
    allowSpace = true;
}

public void Choice4bPeterFunct(){
    primeInt = 79;
    Choice4aArranger.SetActive(false);
    Choice4bPeter.SetActive(false);
    allowSpace = true;
}
public void Choice5aSauterFunct(){
    primeInt = 90;
    Choice5aSauter.SetActive(false);
    Choice5bPasSauter.SetActive(false);
    allowSpace = true;
}
public void Choice5bPasSauterFunct(){
    primeInt = 96;
    Choice5aSauter.SetActive(false);
    Choice5bPasSauter.SetActive(false);
    allowSpace = true;
}
public void Choice6aTableFunct(){
    primeInt = 104;
    Choice6aTable.SetActive(false);
    allowSpace = true;
}
public void Choice7aTapisFunct(){
    primeInt = 106;
    Choice7aTapis.SetActive(false);
    allowSpace = true;
}
public void Choice8aTrappeFunct(){
    primeInt = 110;
    Choice8aTrappe.SetActive(false);
    allowSpace = true;
}
public void Choice8bAutreSolutionFunct(){
    primeInt = 109;
    Choice8bAutreSolution.SetActive(false);
    Choice8aTrappe.SetActive(false);
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