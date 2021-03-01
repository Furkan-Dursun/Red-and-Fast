using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altinAnim : MonoBehaviour
{
    public Sprite[] animasyonKareleri;
    SpriteRenderer SpriteRenderer;

    float zaman = 0;
    int animasyonKareleriSayac = 0;

   
    void Start()
    {       
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        zaman += Time.deltaTime;
        if (zaman > 0.04f)
        {

            SpriteRenderer.sprite = animasyonKareleri[animasyonKareleriSayac++];
            if (animasyonKareleri.Length == animasyonKareleriSayac)
            {
                animasyonKareleriSayac = 0; // basa don
            }
            zaman = 0;
        }
    }
}
