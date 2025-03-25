using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

// Ce script gère l'état du jeu, y compris la pause, le volume, la gestion du temps et la transition entre les scènes importante.
// On ne modifie pas ce script sans raison valable. Les modifications autorisées sont :

// 1. L'ajout de variables nécessaires pour de nouvelles fonctionnalités (ex : nouvelles stats du joueur).
// 2. L'ajout de méthodes pour gérer des mécaniques liées aux systèmes existants (ex : gestion avancée du son).
// 3. L'amélioration des performances sans modifier le comportement du jeu (ex : optimisation de la gestion du temps).
// 4. La correction de bugs existants.

public class GameHandler : MonoBehaviour {

    // Variables globales de gestion du jeu
    public static int playerStat1; // Une statistique du joueur (peut-être un score ou une compétence ?)
    public static bool GameisPaused = false; // Indique si le jeu est en pause
    public GameObject pauseMenuUI; // Référence à l'UI du menu pause
    public AudioMixer mixer; // Gestion du volume sonore
    public static float volumeLevel = 1.0f; // Niveau du volume global
    private Slider sliderVolumeCtrl; // Contrôle du volume dans l'UI
    public static int playerHealth = 10; // Points de vie du joueur
    public static float timeRemaining = 3600f; // Temps restant avant la fin (1 heure)
    public static bool timerIsRunning = true; // Indique si le timer est en cours
    public TextMeshProUGUI timerText; // Texte affichant le temps restant

    public static bool hasKey = false;
    public static bool isElectricityOff = false; // Indique si le compteur électrique est éteint

    

    public static string playerName = "You"; // Valeur par défaut



    public static void SetPlayerName(string name)
    {
        playerName = name; // Stocke le nom saisi
    }

    void Awake(){
        // Initialise le volume et lie le slider du menu pause
        SetLevel(volumeLevel);
        GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
        if (sliderTemp != null){
            sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
            sliderVolumeCtrl.value = volumeLevel;
        }
         DontDestroyOnLoad(gameObject);
    }

    void Start(){
        // Au lancement, désactive le menu pause et indique que le jeu n'est pas en pause
        pauseMenuUI.SetActive(false);
        GameisPaused = false;
    }

    void Update(){
        // Gestion de la pause avec la touche Échap
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameisPaused){ Resume(); }
            else{ Pause(); }
        }

        // Gestion du temps si le jeu n'est pas en pause
        if (timerIsRunning && !GameisPaused){
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);

            if (timeRemaining <= 0){
                timeRemaining = 0;
                timerIsRunning = false;
                SceneManager.LoadScene("SceneLoose"); // Charge la scène de défaite si le temps expire
            }
        }

        // Si la vie du joueur tombe à 0, il perd la partie  je n'ai pas testé faudra donc voir si ça marche
        if (playerHealth <= 0){
            SceneManager.LoadScene("SceneLoose");
        }

        // Debugging possible (désactivé)
        // if (Input.GetKey("p")){
        //     Debug.Log("Player Stat = " + playerStat1);
        // }
    }

    // Met le jeu en pause
    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Arrête le temps du jeu
        GameisPaused = true;
    }

    // Reprend le jeu après une pause
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    // Ajuste le volume de la musique
    public void SetLevel(float sliderValue){
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        volumeLevel = sliderValue;
    }

    // Charge la scène du jeu principal on changera le nom en fonction de c quelle scène
    public void StartGame(){
        SceneManager.LoadScene("SceneGrenier");
    }

    // Charge la scène des crédits
    public void OpenCredits(){
        SceneManager.LoadScene("Credits");
    }

    // Redémarre le jeu et réinitialise les variables  ici il faut rajouter les variables que vous avez ajouté
    public void RestartGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

        // Réinitialisation des variables statiques pour une nouvelle partie
        playerHealth = 10;
        timeRemaining = 3600f;
        timerIsRunning = true;
        GameHandler.playerName = ""; // Réinitialisation du nom
        hasKey = false;
        isElectricityOff = false;
    }

    // Affiche le temps restant sous format "MM:SS" à voir si on change ça plus tard 
    void DisplayTime(float timeToDisplay){
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Quitte le jeu, que ce soit dans l'éditeur ou l'application standalone
    public void QuitGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}

