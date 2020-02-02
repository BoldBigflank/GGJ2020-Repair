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

    public GameObject bodyPartFeetToucanWing;


        public Transform lowerConveyorSpawn;
        public Transform upperConveyorSpawn;
        public float timeBetweenSpawn = 2.0f;
        private float elapsedTime = 0.0f;
        private int randomStartingPoint;




    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= timeBetweenSpawn)
        {
                randomStartingPoint = Random.Range(0, 2);
                if(randomStartingPoint == 0)
                {
                        CreateRandomBodyPart(lowerConveyorSpawn.position, false);
                }
                else
                {
                        CreateRandomBodyPart(upperConveyorSpawn.position, true);
                }
                
                elapsedTime = 0.0f;
        }
    }

    public GameObject CreateRandomBodyPart(Vector3 startingPosition, bool spawnUpper)
    {
        int randomValue = Random.Range(0, 29);
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
                temp =  Instantiate(bodyPartHeadOctopus, startingPosition, Quaternion.identity);
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

                case 19:
                temp =  Instantiate(bodyPartFeetOctopusBack, startingPosition, Quaternion.identity);
                break;

                case 20:
                temp =  Instantiate(bodyPartFeetOctopusFront, startingPosition, Quaternion.identity);
                break;

                case 21:
                temp =  Instantiate(bodyPartFeetToucanBack, startingPosition, Quaternion.identity);
                break;

                case 22:
                temp =  Instantiate(bodyPartFeetToucanBack, startingPosition, Quaternion.identity);
                break;

                case 23:
                temp =  Instantiate(bodyPartFeetOctopusBack, startingPosition, Quaternion.identity);
                break;

                case 24:
                temp =  Instantiate(bodyPartFeetGiraffeBack, startingPosition, Quaternion.identity);
                break;

                case 25:
                temp =  Instantiate(bodyPartFeetGiraffeFront, startingPosition, Quaternion.identity);
                break;

                case 26:
                temp =  Instantiate(bodyPartFeetKoalaFront, startingPosition, Quaternion.identity);
                break;

                case 27:
                temp =  Instantiate(bodyPartFeetKoalaBack, startingPosition, Quaternion.identity);
                break;

                case 28:
                temp =  Instantiate(bodyPartFeetToucanWing, startingPosition, Quaternion.identity);
                break;

                default:
                temp =  Instantiate(bodyPartFeetToucanFront, startingPosition, Quaternion.identity);
                break;
        }

        if(spawnUpper)
        {
                temp.GetComponent<SpriteRenderer>().sortingOrder = 7;
                temp.GetComponent<PathFinder>().SetNextPoint(35);
        }
        

        return temp;
    }
}
