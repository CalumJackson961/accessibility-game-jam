using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("lOADING LEVEL 1");
    }
    public void OnExitButtonClicked()
    {
        Application.Quit();
        Debug.Log("QUITITNG");
    }
    public void OnOptionsButtonClicked()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
        Debug.Log("Options button clicked");
    }
    public void OnOptionBackButtonClicked()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        Debug.Log("Options back button clicked");
    }
}
