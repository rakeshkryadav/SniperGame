using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public bool gamePause = false;
    [SerializeField] private GameObject pauseUI;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!gamePause){
                //pause it
                Pause();
            }
            else{
                // resume it
                Resume();
            }
        }
    }

    public void Resume(){
        pauseUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        gamePause = false;
        Time.timeScale = 1f;
    }

    void Pause(){
        pauseUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        gamePause = true;
        Time.timeScale = 0f;
    }
    public void LoadMainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
    public void LoadGameMap(){
        SceneManager.LoadScene("GameMap");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
