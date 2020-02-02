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
    public GameObject bodyPartFeetCatFront;
    public GameObject bodyPartFeetCatBack;

    public GameObject bodyPartFeetChameleon;

    public GameObject bodyPartFeetCowBack;
    public GameObject bodyPartFeetCowFront;

    public GameObject bodyPartFeetFrogBack;
    public GameObject bodyPartFeetFrogFront;

    public GameObject bodyPartFeetLemurFront;

    public GameObject bodyPartFeetLemurBack;





    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CreateRandomBodyPart()
    {
        int randomValue = Random.Range(0, 19);
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

                case 9:
                temp =  Instantiate(bodyPartFeetCatFront);
                break;

                case 10:
                temp =  Instantiate(bodyPartHeadToucan);
                break;

                case 11:
                temp =  Instantiate(bodyPartFeetCatBack);
                break;

                case 12:
                temp =  Instantiate(bodyPartFeetChameleon);
                break;

                case 13:
                temp =  Instantiate(bodyPartFeetCowBack);
                break;

                case 14:
                temp =  Instantiate(bodyPartFeetCowFront);
                break;

                case 15:
                temp =  Instantiate(bodyPartFeetFrogBack);
                break;

                case 16:
                temp =  Instantiate(bodyPartFeetFrogFront);
                break;

                case 17:
                temp =  Instantiate(bodyPartFeetLemurFront);
                break;

                case 18:
                temp =  Instantiate(bodyPartFeetLemurBack);
                break;

                default:
                temp =  Instantiate(bodyPartHeadCat);
                break;
        }
        return temp;
    }
}
