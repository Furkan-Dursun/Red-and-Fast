using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anaMenuAnimasyon : MonoBehaviour
{

    public Sprite[] beklemeAnim;
    int beklemeAnimSayac = 0;
    float beklemeAnimZaman = 0;


    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }    

    private void FixedUpdate()
    {
        // bekleme animasyonu
        beklemeAnimZaman += Time.deltaTime;
        if (beklemeAnimZaman > 0.03f)
        {
            spriteRenderer.sprite = beklemeAnim[beklemeAnimSayac++];
            if (beklemeAnimSayac == beklemeAnim.Length)
            {
                beklemeAnimSayac = 0;
            }
            beklemeAnimZaman = 0;
        }
    }
}
