using UnityEngine.UI;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    public PlayerMovement PlayerColor;

    [Space]
    public Image panelGameOver;
    public Image PlayerRedention;
    public float speedAlpha;
    public Text GameOverText;

    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void GameOverScreen()
    {
        PlayerRedention.gameObject.SetActive(true);

        var oldColor = new Color(255, 255, 255, 0);
        var newColor = new Color(255, 255, 255, 255);

        PlayerRedention.color = Color.Lerp(oldColor, newColor, speedAlpha * Time.deltaTime);
        panelGameOver.gameObject.SetActive(true);
    }
}
