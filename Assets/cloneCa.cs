using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloneCa : MonoBehaviour
{
   [SerializeField] private GameObject caClone;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = spawnTime - Time.deltaTime;
        if(spawnTime <= 0)
        {
            Instantiate(caClone,vitriclone(),Quaternion.identity);
            spawnTime = 1.5f;
        }    
    }
    private Vector3 vitriclone()
    {
        Vector2 limitesPatalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
        float aleatorioVertical = Random.Range(-limitesPatalla.y, limitesPatalla.y);
        return new Vector3(0,aleatorioVertical,0);
    }

}
