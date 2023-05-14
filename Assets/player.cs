using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private Transform pezSprite;
    float tocdo = 3;
    private float size = 1;
    private int anca = 0;
    GameManager gameManager;

    AudioSource Audio;
    public AudioClip dead;
    public TMP_Text wintext;
    public TMP_Text overtext;
    public TextMeshProUGUI myText;
    // Start is called before the first frame update
    void Start()
    {
        size = transform.localScale.x;
        Audio = GetComponent<AudioSource>();
        myText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //di chuy?n
        float inputVertical = Input.GetAxis("Vertical")  * Time.deltaTime * tocdo;
        float inputHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * tocdo;

        transform.position =transform.position +  new Vector3(inputHorizontal, inputVertical, 0);

        //tránh thoát kh?i màn hình
        float tilemanhinh = 0.99f;
        float distanceFromCamera = 0.5f; // kho?ng cách gi?a nhân v?t và Camera
        float tilekhungnhin = Camera.main.aspect; // t? l? khung hình c?a Camera

        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * tilekhungnhin;

        Vector2 limitesCa = new Vector2(cameraWidth * tilemanhinh / 2 - distanceFromCamera, cameraHeight * tilemanhinh / 2 - distanceFromCamera);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -limitesCa.x, limitesCa.x),
            Mathf.Clamp(transform.position.y, -limitesCa.y, limitesCa.y),
            0);
               
        //xoay 
        if (inputHorizontal == 0) return;
        if(inputHorizontal < 0)
        {
            pezSprite.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            pezSprite.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pez"))
        {
         caclone caAI = collision.gameObject.GetComponent<caclone>();
            Audio.PlayOneShot(dead);
            if (size >= caAI.GetTamano())
            {
                anca++;
                GameManager.score++;
                if (GameManager.score >= GameManager.highScore)
                {
                    GameManager.highScore = GameManager.score;
                    PlayerPrefs.SetInt("HighScore", GameManager.score);
                }
                transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);
                size = transform.localScale.x;
                Destroy(collision.gameObject);
                if(anca >= 15)
                {
                    myText.enabled = true;
                    wintext.text = "CHUC MUNG BAN WIN" + "scrore: " + GameManager.highScore;
                    GameManager.instance.TinhTrangGame(tinhtrang.Gamewin);
                    tocdo = 0;
                }
            }
            else
            {
                AudioListener.pause = true;
               myText.enabled = true;
                overtext.text = "NO!!!!" + "Score: " + GameManager.score;
                GameManager.instance.TinhTrangGame(tinhtrang.Gameover);
                Destroy(gameObject);
            }
        }
    }
    
    
}
