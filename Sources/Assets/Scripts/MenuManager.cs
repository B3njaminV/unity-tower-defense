using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject optionPannel;

    [SerializeField]
    private Text levelToLaunch;

    private void Start()
    {
        UpdateLevelText();
    }

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
        UpdateLevelText();
    }

    public void UpdateLevelText()
    {
        if(levelToLaunch != null)
        {
            levelToLaunch.text = (GameManager.Instance.CurrentLevel + 1).ToString();
        }
    }
}