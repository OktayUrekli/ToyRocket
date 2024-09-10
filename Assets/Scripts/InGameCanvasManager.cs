using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;

    void Start()
    {
        PausePanel.SetActive(false);
    }

    public void PauseGameButton()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void ContinueButton()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void ReturnMenuButton()
    {
        SceneManager.LoadScene(0);
    }


}
