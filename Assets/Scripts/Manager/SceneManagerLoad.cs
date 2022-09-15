using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagerLoad : MonoBehaviour
{
    public float transitionTime;

    public float transitionSpeed;
    public int scene;

    public GameObject Transition;

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.instance.playerAlive == false)
        {
        }
    }

    public IEnumerator LoadScene(int scene)
    {
        Vector2 MaxPanel = new Vector2(1, 1);
        Transition.transform.localScale = Vector2.MoveTowards(Transition.transform.localScale, MaxPanel, transitionSpeed * Time.deltaTime);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }
}
