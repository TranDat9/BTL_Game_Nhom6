using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caclone : MonoBehaviour
{
    [SerializeField] private Transform pezSprite;
    private int dir = 1;
    private float tamato;
    Vector2 limitesPatalla;
    [SerializeField] private float speed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
        limitesPatalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // Ch?n ng?u nhiên h??ng ?i ban ??u c?a nhân v?t (trái ho?c ph?i)
        dir = Random.value < 0.5f ? -1 : 1;

        // Xoay sprite c?a nhân v?t t??ng ?ng v?i h??ng ?i ban ??u
        if (dir == 1)
        {
            pezSprite.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            pezSprite.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        // Thi?t l?p giá tr? scale c?a nhân v?t ng?u nhiên
        float random = Random.Range(0.5f, 2.5f);
        tamato = random;
        transform.localScale = new Vector3(random, random, random);

        // Thi?t l?p v? trí ban ??u c?a nhân v?t ng?u nhiên
        float startX = dir == 1 ? -limitesPatalla.x - 2 : limitesPatalla.x + 2;
        transform.position = new Vector3(startX, Random.Range(-limitesPatalla.y, limitesPatalla.y), 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * dir * Time.deltaTime * speed);
        /*if (transform.position.x > 10 || transform.position.x < -10)
        {
            Destroy(gameObject);
        }*/
        

        if (transform.position.x <= - limitesPatalla.x -2 || transform.position.x > limitesPatalla.x +2)
        {
            Destroy(gameObject);
        }
    }
    public float GetTamano()
    {
        return tamato;
    }
    
}
