using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canVer : MonoBehaviour
{

    public Sprite []animasyonKareleri;
    SpriteRenderer SpriteRenderer;

    AudioSource ses;
    

    float zaman = 0;
    int animasyonKareleriSayac = 0;
    void Start()
    {
        ses = GetComponent<AudioSource>();
        ses.Play();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
        zaman += Time.deltaTime;
        if (zaman>0.1f)
        {
            
            SpriteRenderer.sprite = animasyonKareleri[animasyonKareleriSayac++];
            if (animasyonKareleri.Length==animasyonKareleriSayac)
            {
                
                animasyonKareleriSayac = animasyonKareleri.Length-1; // en sondaki animasyon karesi kalsin
            }
            zaman = 0;
        }
    }
    
}
