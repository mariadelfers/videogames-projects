using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour {

	public void PlayButtonPressed()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }
}
