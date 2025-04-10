using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    public void StartGamePressed()
    {
        Debug.Log("Start Button Pressed");
        SceneManager.LoadScene(gameSceneName);
    }
    public void OptionsPressed()
    {
        Debug.Log("Option Button Pressed");
    }
    private string Pressed(string button)
    {
        return button + " Button Pressed";
    }
    public static void QuitPressed()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
