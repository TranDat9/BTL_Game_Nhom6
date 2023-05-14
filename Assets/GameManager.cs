using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    private tinhtrang tinhtrang;
    public TMP_Text ScoreText;
    public static int score =0 ;
    public static int highScore;
   /* public TMP_Text wintext;
    public TMP_Text overtext;*/
    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }
    public void TinhTrangGame(tinhtrang game)
    {
        switch (game)
        {
            case tinhtrang.Playing:
                Time.timeScale = 1f; // set timescale v? 1 ?? ch?i trò ch?i
                break;
            case tinhtrang.Gameover:
               
                Debug.Log("Game Over");
                Time.timeScale = 0f; // set timescale v? 0 ?? d?ng trò ch?i
                Destroy(gameObject);
                break;
            case tinhtrang.Gamewin:
                Debug.Log("Game win");
                Time.timeScale = 0f; // set timescale v? 0 ?? d?ng trò ch?i
                Destroy(gameObject);
                ScoreText.text = "Score : " + score;
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score : " + score + "\nHightscore: " + highScore;
        
    }
}
    public enum tinhtrang
    {
        Playing,
        Gameover,
        Gamewin
    }
