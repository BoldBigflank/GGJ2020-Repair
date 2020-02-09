using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBodyPartGeneratorScript : MonoBehaviour
{
    [SerializeField] GameObject[] bodyParts;
    [SerializeField] GameObject[] heads;

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

    public void CreateRandomBodyPart(Vector3 startingPosition, bool spawnUpper)
    {
        GameObject bodyPartToSpawn;
        if (Random.Range(0, 10) < 3)    // 30% chance of a head spawning
        {
            bodyPartToSpawn = Instantiate(heads[Random.Range(0, heads.Length)], startingPosition, Quaternion.identity);
        }
        else
        {
            bodyPartToSpawn = Instantiate(bodyParts[Random.Range(0, bodyParts.Length)], startingPosition, Quaternion.identity);
        }
        
        if(spawnUpper)
        {
            bodyPartToSpawn.GetComponent<SpriteRenderer>().sortingOrder = 7;
            bodyPartToSpawn.GetComponent<PathFinder>().SetNextPoint(35);
        }
    }
}
