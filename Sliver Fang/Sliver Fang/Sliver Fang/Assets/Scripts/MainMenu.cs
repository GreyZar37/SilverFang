using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator fadeAnim;
    [SerializeField] Button playButton, quitButton;
    [SerializeField] AudioClip SpecialClick, normalClick;

    private void Start()
    {
        playButton.onClick.AddListener(() => StartCoroutine(startGame()));
        quitButton.onClick.AddListener(() => StartCoroutine(QuitGame()));

    }
    public IEnumerator startGame()
    {
        AudioManager.playSound(SpecialClick, 1f);

        fadeAnim.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
    public IEnumerator QuitGame()
    {
        AudioManager.playSound(normalClick,1f);
        fadeAnim.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}