using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kursunKontrol : MonoBehaviour
{
    dusmanKontrol dusman;
    Rigidbody2D fizik;
    GameObject kursun;

    void Start()
    {
        kursun = GameObject.FindGameObjectWithTag("kursun");
        ; dusman = GameObject.FindGameObjectWithTag("dusman").GetComponent<dusmanKontrol>();
        fizik = GetComponent<Rigidbody2D>();
        fizik.AddForce(dusman.getYon() * 1000); // adforce vektor2 aliyor // dusman kontrol scriptinden getYonun vektorunu aldik, kursunun karaktere dogru gelmesini sagla
    }

}
