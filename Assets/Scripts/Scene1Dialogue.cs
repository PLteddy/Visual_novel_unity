// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.UI;
// using TMPro;
// using UnityEngine.SceneManagement;
// using UnityEngine.Audio;

// public class Scene1Dialogue : MonoBehaviour {
// // These are the script variables.
// // For more character images / buttons, copy & renumber the variables:
//         public int primeInt = 1;        // This integer drives game progress!
//         public TMP_Text Char1name;
//         public TMP_Text Char1speech;
//         public TMP_Text Char2name;
//         public TMP_Text Char2speech;
//        //public TMP_Text Char3name;
//        //public TMP_Text Char3speech;
//         public GameObject DialogueDisplay;
//         public GameObject ArtChar1a;
//        //public GameObject ArtChar1b;
//        //public GameObject ArtChar1c;
//        //public GameObject ArtChar2;
//         public GameObject ArtBG1;
//         public GameObject Choice1a;
//         public GameObject Choice1b;
//         public GameObject NextScene1Button;
//         public GameObject NextScene2Button;
//         public GameObject nextButton;
//        //public AudioSource audioSource1;
//         private bool allowSpace = true;

// // Set initial visibility. Added images or buttons need to also be SetActive(false);
//         void Start(){  
//              DialogueDisplay.SetActive(false);
//              ArtChar1a.SetActive(false);
//              ArtBG1.SetActive(true);
//              Choice1a.SetActive(false);
//              Choice1b.SetActive(false);
//              NextScene1Button.SetActive(false);
//              NextScene2Button.SetActive(false);
//              nextButton.SetActive(true);
//         }

// // Use the spacebar as a faster "Next" button:
//         void Update(){        
//              if (allowSpace == true){
//                  if (Input.GetKeyDown("space")){
//                       Next();
//                  }

//                  // secret debug code: go back 1 Story Unit, if NEXT is visible
//                  if (Input.GetKeyDown("p")) {
//                       primeInt -= 2;
//                       Next();
//                  }
//              }
//         }

// //Story Units! The main story function.
// //Players hit [NEXT] to progress to the next primeInt:
// public void Next(){
//         primeInt += 1;
//         if (primeInt == 1){
//                 // audioSource1.Play();
//         }
//         else if (primeInt == 2){
//                 ArtChar1a.SetActive(true);
//                 DialogueDisplay.SetActive(true);
//                 Char1name.text = "";
//                 Char1speech.text = "";
//                 Char2name.text = "Jeda";
//                 Char2speech.text = "Lève toi esclave";
//         }
//        else if (primeInt ==3){
//                 Char1name.text = "YOU";
//                 Char1speech.text = "Hein ? Où suis-je ?";
//                 Char2name.text = "";
//                 Char2speech.text = "";
//                 //gameHandler.AddPlayerStat(1);
//         }
//        else if (primeInt == 4){
//                 Char1name.text = "";
//                 Char1speech.text = "";
//                 Char2name.text = "Jeda";
//                 Char2speech.text = "Tu ne le sais pas ?";
//         }
//        else if (primeInt == 5){
//                 Char1name.text = "YOU";
//                 Char1speech.text = "Non, je devrais ?";
//                 Char2name.text = "";
//                 Char2speech.text = "";
//         }
//        else if (primeInt == 6){
//                 Char1name.text = "";
//                 Char1speech.text = "";
//                 Char2name.text = "Jeda";
//                 Char2speech.text = "Oui c'est à cause de toi si nous sommes là.";
//         }
//        else if (primeInt ==7){
//                 Char1name.text = "YOU";
//                 Char1speech.text = "Quoi ? Impossible...";
//                 Char2name.text = "";
//                 Char2speech.text = "";
//         }
//        else if (primeInt == 8){
//                 Char1name.text = "";
//                 Char1speech.text = "";
//                 Char2name.text = "Jeda";
//                 Char2speech.text = "Tu nous mets dans ce merdier et tu fais semblant d'avoir tout oublié ?";
//                 // Turn off the "Next" button, turn on "Choice" buttons
//                 nextButton.SetActive(false);
//                 allowSpace = false;
//                 Choice1a.SetActive(true); // function Choice1aFunct()
//                 Choice1b.SetActive(true); // function Choice1bFunct()
//         }

//        // after choice 1a
//        else if (primeInt == 20){
//                 //gameHandler.AddPlayerStat(1);
//                 Char1name.text = "";
//                 Char1speech.text = "";
//                 Char2name.text = "Jeda";
//                 Char2speech.text = "Je vais te tuer.";
//         }
//        else if (primeInt == 21){
//                 Char1name.text = "";
//                 Char1speech.text = "";
//                 Char2name.text = "Jeda";
//                 Char2speech.text = "Reviens là!";
//                 // Turn off the "Next" button, turn on "Scene" button/s
//                 nextButton.SetActive(false);
//                 allowSpace = false;
//                 NextScene1Button.SetActive(true);
//         }

//        // after choice 1b
//        else if (primeInt == 30){
//                 Char1name.text = "";
//                 Char1speech.text = "";
//                 Char2name.text = "Jeda";
//                 Char2speech.text = "Arrête de me prendre pour un idiot";
//         }
//        else if (primeInt == 31){
//                 Char1name.text = "YOU";
//                 Char1speech.text = "Je t'assure que je ne vois pas de quoi tu parles.";
//                 Char2name.text = "";
//                 Char2speech.text = "";
//                 // Turn off the "Next" button, turn on "Scene" button/s
//                 nextButton.SetActive(false);
//                 allowSpace = false;
//                 NextScene2Button.SetActive(true);
//         }

//       //Please do NOT delete this final bracket that ends the Next() function:
//      }

// // FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and SceneChanges)
//         public void Choice1aFunct(){
//                 Char1name.text = "YOU";
//                 Char1speech.text = "Ta gueule !";
//                 Char2name.text = "";
//                 Char2speech.text = "";
//                 primeInt = 19; // so hitting "NEXT" goes to primeInt==20!
//                 Choice1a.SetActive(false);
//                 Choice1b.SetActive(false);
//                 nextButton.SetActive(true);
//                 allowSpace = true;
//         }
//         public void Choice1bFunct(){
//                 Char1name.text = "YOU";
//                 Char1speech.text = "Je vais te buter.";
//                 Char2name.text = "";
//                 Char2speech.text = "";
//                 primeInt = 29; // so hitting "NEXT" goes to primeInt==30!
//                 Choice1a.SetActive(false);
//                 Choice1b.SetActive(false);
//                 nextButton.SetActive(true);
//                 allowSpace = true;
//         }

//         public void SceneChange1(){
//                SceneManager.LoadScene("Scene2a");
//         }
//         public void SceneChange2(){
//                 SceneManager.LoadScene("Scene2b");
//         }
// }