using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour {

        public static int playerStat1;

        public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
        public AudioMixer mixer;
        public static float volumeLevel = 1.0f;
        private Slider sliderVolumeCtrl;
        public static int playerHealth = 10;
        public static float timeRemaining = 3600f; // 1 heure = 3600 secondes
        public static bool timerIsRunning = true;
        public TextMeshProUGUI timerText;



        void Awake(){
                SetLevel (volumeLevel);
                GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                if (sliderTemp != null){
                        sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                        sliderVolumeCtrl.value = volumeLevel;
                }
        }

        void Start(){
                pauseMenuUI.SetActive(false);
                GameisPaused = false;
        }

void Update(){
    if (Input.GetKeyDown(KeyCode.Escape)){
        if (GameisPaused){ Resume(); }
        else{ Pause(); }
    }

    if (timerIsRunning && !GameisPaused){
        timeRemaining -= Time.deltaTime;
        DisplayTime(timeRemaining);

        if (timeRemaining <= 0){
            timeRemaining = 0;
            timerIsRunning = false;
            SceneManager.LoadScene("SceneLose");
        }
    }

    if (playerHealth <= 0){
        SceneManager.LoadScene("SceneLose");
    }

    // Exemple debug
    // if (Input.GetKey("p")){
    //     Debug.Log("Player Stat = " + playerStat1);
    // }
}

        public void Pause(){
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                GameisPaused = true;
        }

        public void Resume(){
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GameisPaused = false;
        }

        public void SetLevel (float sliderValue){
                mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
                volumeLevel = sliderValue;
        }

        public void StartGame(){
                SceneManager.LoadScene("Scene1");
        }

        public void OpenCredits(){
                SceneManager.LoadScene("Credits");
        }

        public void RestartGame(){
                Time.timeScale = 1f;
                SceneManager.LoadScene("MainMenu");
                // Please also reset all static variables here, for new games!
                    // Reset les stats pour une nouvelle partie
    playerHealth = 10;
    timeRemaining = 3600f;
    timerIsRunning = true;
        }
        void DisplayTime(float timeToDisplay){
    timeToDisplay += 1;
    float minutes = Mathf.FloorToInt(timeToDisplay / 60);
    float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
}


        public void QuitGame(){
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
        }
}