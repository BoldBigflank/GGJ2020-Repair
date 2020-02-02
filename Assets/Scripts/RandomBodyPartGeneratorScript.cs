using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBodyPartGeneratorScript : MonoBehaviour
{
    public GameObject bodyPartHeadCat;
    public GameObject bodyPartHeadChameleon;
    public GameObject bodyPartHeadCow;

    public GameObject bodyPartHeadDog;

    public GameObject bodyPartHeadFrog;
    public GameObject bodyPartHeadGirraffe;
    public GameObject bodyPartHeadHamster;
    public GameObject bodyPartHeadKoala;
    public GameObject bodyPartHeadToucan;



    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CreateRandomBodyPart()
    {
        int randomValue = Random.Range(0, 2);
        GameObject temp;

        switch(randomValue)
        {
                case 0:
                temp =  Instantiate(bodyPartHeadCat);
                break;
                
                case 1:
                temp =  Instantiate(bodyPartHeadChameleon);
                break;

                case 2:
                temp =  Instantiate(bodyPartHeadCow);
                break;

                case 3:
                temp =  Instantiate(bodyPartHeadDog);
                break;

                case 4:
                temp =  Instantiate(bodyPartHeadFrog);
                break;

                case 5:
                temp =  Instantiate(bodyPartHeadGirraffe);
                break;

                case 6:
                temp =  Instantiate(bodyPartHeadHamster);
                break;

                case 7:
                temp =  Instantiate(bodyPartHeadKoala);
                break;

                case 8:
                temp =  Instantiate(bodyPartHeadToucan);
                break;
                
                default:
                temp =  Instantiate(bodyPartHeadCat);
                break;
        }
        return temp;
    }
}
