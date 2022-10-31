using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelAnimation : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene(3);
    }
}
