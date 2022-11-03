using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCredits : MonoBehaviour
{
    void Start()
    {
        Invoke("exitcredit", 9.25f);
    }

    private void exitcredit()
    {
        SceneManager.LoadScene(0);
    }
}
