using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeScene : MonoBehaviour
{
    public int nextScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SceneManagerLoad.instance.LoadScene(nextScene));
        }
    }

}
