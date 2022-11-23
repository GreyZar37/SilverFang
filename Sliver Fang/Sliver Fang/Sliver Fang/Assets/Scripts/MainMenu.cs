using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator fadeAnim;
    [SerializeField] Button playButton;

    private void Start()
    {
        playButton.onClick.AddListener(() => StartCoroutine(startGame()));
    }
    public IEnumerator startGame()
    {
        fadeAnim.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}