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

    public GameObject bodyPartHeadOctopus;
    public GameObject bodyPartHeadToucan;
    
    public GameObject bodyPartFeetCatFront;
    public GameObject bodyPartFeetCatBack;

    public GameObject bodyPartFeetChameleon;

    public GameObject bodyPartFeetCowBack;
    public GameObject bodyPartFeetCowFront;

    public GameObject bodyPartFeetFrogBack;
    public GameObject bodyPartFeetFrogFront;

    public GameObject bodyPartFeetGiraffeBack;
    public GameObject bodyPartFeetGiraffeFront;

    public GameObject bodyPartFeetKoalaBack;
    public GameObject bodyPartFeetKoalaFront;

    public GameObject bodyPartFeetLemurFront;

    public GameObject bodyPartFeetLemurBack;

    public GameObject bodyPartFeetOctopusBack;
    public GameObject bodyPartFeetOctopusFront;

    public GameObject bodyPartFeetToucanBack;
    public GameObject bodyPartFeetToucanFront;


        private float elapsedTime = 0.0f;
        private float timeBetweenSpawn = 2.0f;


    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= timeBetweenSpawn)
        {
                CreateRandomBodyPart(new Vector3(0.0f, 0.0f, 0.0f));
                elapsedTime = 0.0f;
        }
    }

    public GameObject CreateRandomBodyPart(Vector3 startingPosition)
    {
        int randomValue = Random.Range(0, 19);
        GameObject temp;

        switch(randomValue)
        {
                case 0:
                temp =  Instantiate(bodyPartHeadCat, startingPosition, Quaternion.identity);
                break;
                
                case 1:
                temp =  Instantiate(bodyPartHeadChameleon, startingPosition, Quaternion.identity);
                break;

                case 2:
                temp =  Instantiate(bodyPartHeadCow, startingPosition, Quaternion.identity);
                break;

                case 3:
                temp =  Instantiate(bodyPartHeadDog, startingPosition, Quaternion.identity);
                break;

                case 4:
                temp =  Instantiate(bodyPartHeadFrog, startingPosition, Quaternion.identity);
                break;

                case 5:
                temp =  Instantiate(bodyPartHeadGirraffe, startingPosition, Quaternion.identity);
                break;

                case 6:
                temp =  Instantiate(bodyPartHeadHamster, startingPosition, Quaternion.identity);
                break;

                case 7:
                temp =  Instantiate(bodyPartHeadKoala, startingPosition, Quaternion.identity);
                break;

                case 8:
                temp =  Instantiate(bodyPartHeadToucan, startingPosition, Quaternion.identity);
                break;

                case 9:
                temp =  Instantiate(bodyPartFeetCatFront, startingPosition, Quaternion.identity);
                break;

                case 10:
                temp =  Instantiate(bodyPartHeadToucan, startingPosition, Quaternion.identity);
                break;

                case 11:
                temp =  Instantiate(bodyPartFeetCatBack, startingPosition, Quaternion.identity);
                break;

                case 12:
                temp =  Instantiate(bodyPartFeetChameleon, startingPosition, Quaternion.identity);
                break;

                case 13:
                temp =  Instantiate(bodyPartFeetCowBack, startingPosition, Quaternion.identity);
                break;

                case 14:
                temp =  Instantiate(bodyPartFeetCowFront, startingPosition, Quaternion.identity);
                break;

                case 15:
                temp =  Instantiate(bodyPartFeetFrogBack, startingPosition, Quaternion.identity);
                break;

                case 16:
                temp =  Instantiate(bodyPartFeetFrogFront, startingPosition, Quaternion.identity);
                break;

                case 17:
                temp =  Instantiate(bodyPartFeetLemurFront, startingPosition, Quaternion.identity);
                break;

                case 18:
                temp =  Instantiate(bodyPartFeetLemurBack, startingPosition, Quaternion.identity);
                break;

                default:
                temp =  Instantiate(bodyPartHeadCat, startingPosition, Quaternion.identity);
                break;
        }
        return temp;
    }
}
