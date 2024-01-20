using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject optionPannel;

    [SerializeField]
    private GameObject commingSoonButton;

    [SerializeField]
    private Text levelToLaunch;

    [SerializeField]
    private bool isInCurrentGame = false;

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

    public void SwitchMainSong()
    {
        AudioScript.Instance.SwitchToMainSong();
    }

    public void UpdateLevelText()
    {
        if(levelToLaunch != null)
        {
            levelToLaunch.text = (GameManager.Instance.CurrentLevel + 1).ToString();
            
        }

        if(commingSoonButton != null)
        {
            if (GameManager.Instance.AllLevelFinished(isInCurrentGame))
            {
                commingSoonButton.SetActive(true);
            }
            else
            {
                commingSoonButton.SetActive(false);
            }
        }
        
    }
}