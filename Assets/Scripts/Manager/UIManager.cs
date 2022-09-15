using UnityEngine.UI;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    public PlayerMovement PlayerColor;
    public Image ColorRed, ColorBlue;
    public Text enemyRemaining;

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

    void Update()
    {
        enemyRemaining.text = GameManager.instance.enemyRemaining.ToString() + "/100";
        //Change the type of the projectile on the screen
        if (PlayerColor.PlayerCurrentColor == PlayerColorState.PlayerRed)
        {
            ColorRed.gameObject.SetActive(true);
        }
        else
        {
            ColorRed.gameObject.SetActive(false);
        }
        if (PlayerColor.PlayerCurrentColor == PlayerColorState.PlayerBlue)
        {
            ColorBlue.gameObject.SetActive(true);
        }
        else
        {
            ColorBlue.gameObject.SetActive(false);
        }
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
