using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    [SerializeField] Animator screenFade;

    bool fading;

    public void Play()
    {
        if (fading) return;
        fading = true;

        screenFade.Play("FadeOut");
        Invoke(nameof(LoadWorld), 1f);
    }

    public void Settings()
    {
        Debug.Log("Settings Pressed");
    }

    void LoadWorld()
    {
        SceneManager.LoadScene("World");
    }

    public void Exit()
    {
        if (fading) return;
        fading = true;

        screenFade.Play("FadeOut");
        Invoke(nameof(QuitGame), 1f);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
