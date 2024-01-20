using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    [SerializeField]
    private GameObject optionPannel;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1;
    }

    public void OpenOptionPannel()
    {
        optionPannel?.SetActive(true);
    }

    public void CloseOptionPannel()
    {
        optionPannel?.SetActive(false);
    }

    public void RemoveSave()
    {
        GameManager.Instance.ResetSave();
    }
}