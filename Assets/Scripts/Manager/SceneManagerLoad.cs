using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagerLoad : MonoBehaviour
{
    public static SceneManagerLoad instance;
    Animator animator;

    string TransitionString = "Transition";
    public float transitionTime;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        animator = GetComponent<Animator>();
    }

    public void startGame()
    {
        StartCoroutine(LoadScene(6));
    }
    public void mainMenu()
    {
        StartCoroutine(LoadScene(0));
    }
    public void credits()
    {
        StartCoroutine(LoadScene(5));
    }
    public void exit()
    {
        Application.Quit();
    }
    public void resetScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 0));
    }

    public IEnumerator LoadScene(int scene)
    {
        animator.SetTrigger(TransitionString);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }
}
