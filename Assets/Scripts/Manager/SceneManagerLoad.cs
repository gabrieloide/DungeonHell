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
    public IEnumerator LoadScene(int scene)
    {
        animator.SetBool(TransitionString, true);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }
}
