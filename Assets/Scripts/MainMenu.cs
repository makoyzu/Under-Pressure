using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void StartGame()
    {
        Invoke("LoadGame", 0.8f);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();

        Debug.Log("game quit");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

            Debug.Log("esc");
        }
    }
}
