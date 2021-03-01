using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
# endif    // burasi koda dahil edilmeyecek ,buildde derlenmeyecek

public class blokKontrol : MonoBehaviour
{
    GameObject[] gidilecekNoktalar;

    bool aradakiMesafeyiBirKereAl = true;
    Vector3 aradakiMesafe;
    int aradakiMesafeSayaci;
    bool ilereimiGerimi = true;
    void Start()
    {
        gidilecekNoktalar = new GameObject[transform.childCount];
        for (int i = 0; i < gidilecekNoktalar.Length; i++)
        {
            gidilecekNoktalar[i] = transform.GetChild(0).gameObject; // her seferinde ilk bastaki elemana esitliyoruz
            gidilecekNoktalar[i].transform.SetParent(transform.parent); // testerede olusan objeleri testereden cikardik testere ile beraber donmesinler diye
        }
    }


    void FixedUpdate()
    {
        
        noktalaraGit();
    }

    void noktalaraGit()
    {
        if (aradakiMesafeyiBirKereAl)
        {
            aradakiMesafe = (gidilecekNoktalar[aradakiMesafeSayaci].transform.position - transform.position).normalized; // burda normalized ile normalini aldik boylece testerenin gidcegi noktalara stabil bir sekilde gitmesini sagladik
            aradakiMesafeyiBirKereAl = false;
        }
        float mesafe = Vector3.Distance(transform.position, gidilecekNoktalar[aradakiMesafeSayaci].transform.position); // iki nokta arasi uzaklik ile testerenin surekli sonsuza kadar ayni yonde gitmesini engelleyip sadece istenilen mesafeyi almasini saglicaz
        transform.position += aradakiMesafe * Time.deltaTime * 8;  //testerenin pozisyonunu aradakimesafeyi ekleyip yeni pozisyonuna gitmesini sagladik

        if (mesafe < 0.5f) // ilk objeye gittikten sonra mesafeyi tekrar hesaplamak icin degiskeni true yaptik ve sonraki objeye gitmesini sagladik
        {
            aradakiMesafeyiBirKereAl = true;
            if (aradakiMesafeSayaci == gidilecekNoktalar.Length - 1) // gidilecek noktlarin sayisina esitse 
            {
                ilereimiGerimi = false;
            }
            else if (aradakiMesafeSayaci == 0)
            {
                ilereimiGerimi = true;
            }
            if (ilereimiGerimi) // true ise mesafeyi arttir degilse azalt bu sayede testere donguye girer ve noktalar arasi gidip gelir
            {
                aradakiMesafeSayaci++;
            }
            else
            {
                aradakiMesafeSayaci--;
            }


        }
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position, 1); // gizmos ile testere benzeri cisimleri cizdirdik
        }

        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position); // cizdirdigimiz sekiller arasi cizgi cektik (birinciobje,ikinciobje)
        }
        // uret butonuna bastikca testerenin seklinde daireler cizecek ve bunlarin arasina cizgi cekecek 
    }
#endif
}




#if UNITY_EDITOR // editor icin gerekenler
[CustomEditor(typeof(blokKontrol))]
[System.Serializable]
class blokKontrolEditor : Editor
{
    public override void OnInspectorGUI()
    {
        blokKontrol script = (blokKontrol)target;
        if (GUILayout.Button("URET", GUILayout.MinWidth(100), GUILayout.Width(100))) // virgulden sonrasi buton boyutu
        {
            GameObject yeniObjem = new GameObject();
            yeniObjem.transform.parent = script.transform; // objeleri testerenin icinde uretecez
            yeniObjem.transform.position = script.transform.position; // testerenin pozisyonuna gelcek
            yeniObjem.name = script.transform.childCount.ToString(); // transform altindaki childlerin sayisini aldik ve 1,2 diye adlandirma sagladik, butona tikladikca 1,2,3,4.. diye objeler olusacak
        }
    }
}
# endif  // burasi koda dahil edilmeyecek, buildde derlenmeyecek

