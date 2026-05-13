using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Instructions()
    { 
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Credits()
    {
        SceneManager.LoadScene(2);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void StartCutScene()
    {
        SceneManager.LoadScene(3);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void GameScene()
    {
        SceneManager.LoadScene(4);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void CaptureCutScene()
    {
        SceneManager.LoadScene(5);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void MouseTrapCutScene()
    {
        SceneManager.LoadScene(6);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void SuccessCutScene()
    {
        SceneManager.LoadScene(7);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
