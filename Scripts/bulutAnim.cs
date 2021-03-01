using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulutAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -13.0f)
        {
            //float y_deger = Random.Range(4.5f, 0.5f);
            transform.position = new Vector3(12.0f, transform.position.y, transform.position.z); // bulut ekrandan ciktiginda basklangic 3.80 yap, rastgele yukseklik ata ve z'yi degistirme
        }
        transform.Translate(-0.7f * Time.deltaTime, 0, 0);
    }
}
