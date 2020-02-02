using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealScript : MonoBehaviour
{
    [SerializeField] GameObject backLeftLeg, frontLeftLeg, body, head, backRightLeg, frontRightLeg;
    [SerializeField] GameObject stage, spotlight;
    [SerializeField] Sprite frogBackLeg, frogFrontLeg, frogHead;
    [SerializeField] Sprite catBackLeg, catFrontLeg, catHead;
    [SerializeField] Sprite chameleonLeg, chameleonHead;
    [SerializeField] Sprite cowBackLeg, cowFrontLeg, cowHead;
    [SerializeField] Sprite giraffeBackLeg, giraffeFrontLeg, giraffeHead;
    [SerializeField] Sprite koalaBackLeg, koalaFrontLeg, koalaHead;
    [SerializeField] Sprite octopusBackLeg, octopusFrontLeg, octopusHead;
    [SerializeField] Sprite toucanFoot, toucanWing, toucanHead;
    [SerializeField] Sprite dogBackLeg, dogFrontLeg, dogHead;
    [SerializeField] Sprite LemurBackLeg, LemurFrontLeg, LemurHead;
    [SerializeField] Sprite trashBody, toiletBody, tigerBody, dinoBody, wormBody;
    private enum BodyType {
        trash,
        worm,
        dino,
        toilet,
        tiger,
        NumberOfTypes
    }

    private bool isVertical;
    private bool hidden;
    private float countdown;
    private int legCount;


    void Start()    //We would pass 5 body parts here and do logic to sort them semi-appropriately
    {
        LinkedList<BodyPart> bodyParts = GameStateManager.GetAssemblyZoneP1().GetBodyParts();
        BodyType bodyType = (BodyType)Random.Range(0, (int)BodyType.NumberOfTypes);
        switch (bodyType)
        {
            case BodyType.trash:
                body.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
                body.transform.GetComponent<SpriteRenderer>().sprite = trashBody;
                SetHorizontalBodyPartAnchors();
                break;
            case BodyType.worm:
                body.transform.position = new Vector3(-.71f, .22f, 0f);
                body.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -16.75f));
                body.transform.GetComponent<SpriteRenderer>().sprite = wormBody;
                SetHorizontalBodyPartAnchors();
                break;
            case BodyType.dino:
                body.transform.position = new Vector3(-.09f, .06f, 0f);
                body.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -10.94f));
                body.transform.localScale = new Vector3(.25f, .25f, 0f);
                body.transform.GetComponent<SpriteRenderer>().sprite = dinoBody;
                SetHorizontalBodyPartAnchors();
                break;
            case BodyType.toilet:
                body.transform.position = new Vector3(0f, 0.13f, 0f);
                body.transform.GetComponent<SpriteRenderer>().sprite = toiletBody;
                SetVerticalBodyPartAnchors();
                break;
            case BodyType.tiger:
                body.transform.position = new Vector3(0f, 0.13f, 0f);
                body.transform.GetComponent<SpriteRenderer>().sprite = tigerBody;
                SetVerticalBodyPartAnchors();
                break;

        }
        legCount = 0;
        foreach (BodyPart bodyPart in bodyParts)
        {
            if (!bodyPart.isHead)
            {
                SetLeg(bodyPart.animalType);
            }
            else
            {
                SetHead(bodyPart.animalType);
            }
        }

        HideParts();
        countdown = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (hidden)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0f)
            {
                ShowParts();
            }
        }
    }

    private void SetHorizontalBodyPartAnchors()
    {
        backLeftLeg.transform.position = new Vector3(-.8f, -.77f, 0f);
        frontLeftLeg.transform.position = new Vector3(1.65f, -.62f, 0f);
        backRightLeg.transform.position = new Vector3(-1.48f, -.77f, 0f);
        frontRightLeg.transform.position = new Vector3(1.09f, -.71f, 0f);
        head.transform.position = new Vector3(1.21f, 1.12f, 0f);
        isVertical = false;
    }

    private void SetVerticalBodyPartAnchors()
    {
        backLeftLeg.transform.position = new Vector3(-.7f, -2.03f, 0f);
        backLeftLeg.GetComponent<SpriteRenderer>().flipX = true;
        frontLeftLeg.transform.position = new Vector3(0.55f, -2.03f, 0f);
        backRightLeg.transform.position = new Vector3(-1.2f, -.06f, 0f);
        backRightLeg.GetComponent<SpriteRenderer>().flipX = true;
        frontRightLeg.transform.position = new Vector3(1.2f, -.06f, 0f);
        head.transform.position = new Vector3(-.36f, 2.09f, 0f);
        isVertical = true;
    }

    private void SetLeg(AnimalType animalType)
    {
        if (legCount == 0)
        {
            SetBackLeftLeg(animalType);
        } 
        else if (legCount == 1)
        {
            SetBackRightLeg(animalType);
        }
        else if (legCount == 2)
        {
            setFrontLeftLeg(animalType);
        }
        else if (legCount == 3)
        {
            SetFrontRightLeg(animalType);
        }
        legCount++;
    }

    private void SetBackLeftLeg(AnimalType animalType)
    {

        Sprite sprite = null;
        switch (animalType)
        {
            case AnimalType.Frog:
                sprite = frogBackLeg;
                break;
            case AnimalType.Cat:
                sprite = catBackLeg;
                break;
            case AnimalType.Chameleon:
                sprite = chameleonLeg;
                break;
            case AnimalType.Cow:
                sprite = cowBackLeg;
                break;
            case AnimalType.Giraffe:
                sprite = giraffeBackLeg;
                break;
            case AnimalType.Koala:
                sprite = koalaBackLeg;
                break;
            case AnimalType.Octopus:
                sprite = octopusBackLeg;
                break;
            case AnimalType.Toucan:
                sprite = toucanFoot;
                break;
        }
        backLeftLeg.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void SetBackRightLeg(AnimalType animalType)
    {

        Sprite sprite = null;
        switch (animalType)
        {
            case AnimalType.Frog:
                sprite = frogFrontLeg;
                break;
            case AnimalType.Cat:
                sprite = catFrontLeg;
                break;
            case AnimalType.Chameleon:
                sprite = chameleonLeg;
                break;
            case AnimalType.Cow:
                sprite = cowFrontLeg;
                break;
            case AnimalType.Giraffe:
                sprite = giraffeFrontLeg;
                break;
            case AnimalType.Koala:
                sprite = koalaFrontLeg;
                break;
            case AnimalType.Octopus:
                sprite = octopusFrontLeg;
                break;
            case AnimalType.Toucan:
                if (isVertical) {
                    backRightLeg.GetComponent<SpriteRenderer>().flipX = false;
                    sprite = toucanWing;
                } else {
                    sprite = toucanFoot;
                }
                break;
        }
        backRightLeg.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void setFrontLeftLeg(AnimalType animalType)
    {
        Sprite sprite = null;
        switch (animalType)
        {
            case AnimalType.Frog:
                sprite = frogBackLeg;
                break;
            case AnimalType.Cat:
                sprite = catBackLeg;
                break;
            case AnimalType.Chameleon:
                sprite = chameleonLeg;
                break;
            case AnimalType.Cow:
                sprite = cowBackLeg;
                break;
            case AnimalType.Giraffe:
                sprite = giraffeBackLeg;
                break;
            case AnimalType.Koala:
                sprite = koalaBackLeg;
                break;
            case AnimalType.Octopus:
                sprite = octopusBackLeg;
                break;
            case AnimalType.Toucan:
                if (isVertical)
                {
                    sprite = toucanFoot;
                } else {
                    sprite = toucanWing;
                }
                break;
        }
        frontLeftLeg.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void SetFrontRightLeg(AnimalType animalType)
    {
        Sprite sprite = null;
        switch (animalType)
        {
            case AnimalType.Frog:
                sprite = frogFrontLeg;
                break;
            case AnimalType.Cat:
                sprite = catFrontLeg;
                break;
            case AnimalType.Chameleon:
                sprite = chameleonLeg;
                break;
            case AnimalType.Cow:
                sprite = cowFrontLeg;
                break;
            case AnimalType.Giraffe:
                sprite = giraffeFrontLeg;
                break;
            case AnimalType.Koala:
                sprite = koalaFrontLeg;
                break;
            case AnimalType.Octopus:
                sprite = octopusFrontLeg;
                break;
            case AnimalType.Toucan:
                if (isVertical)
                {
                    frontRightLeg.GetComponent<SpriteRenderer>().flipX = true;
                }
                sprite = toucanWing;
                break;
        }
        frontRightLeg.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void SetHead(AnimalType animalType)
    {

        Sprite sprite = null;
        switch (animalType)
        {
            case AnimalType.Frog:
                sprite = frogHead;
                break;
            case AnimalType.Cat:
                sprite = catHead;
                break;
            case AnimalType.Chameleon:
                sprite = chameleonHead;
                break;
            case AnimalType.Cow:
                sprite = cowHead;
                break;
            case AnimalType.Giraffe:
                sprite = giraffeHead;
                break;
            case AnimalType.Koala:
                sprite = koalaHead;
                break;
            case AnimalType.Octopus:
                sprite = octopusHead;
                break;
            case AnimalType.Toucan:
                sprite = toucanHead;
                break;
        }
        head.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    void HideParts()
    {
        stage.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        spotlight.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, .0f);
        backLeftLeg.GetComponent<SpriteRenderer>().color = Color.black;
        backRightLeg.GetComponent<SpriteRenderer>().color = Color.black;
        frontLeftLeg.GetComponent<SpriteRenderer>().color = Color.black;
        frontRightLeg.GetComponent<SpriteRenderer>().color = Color.black;
        head.GetComponent<SpriteRenderer>().color = Color.black;
        body.GetComponent<SpriteRenderer>().color = Color.black;

        hidden = true;
    }

    void ShowParts()
    {
        stage.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        spotlight.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, .5f);
        backLeftLeg.GetComponent<SpriteRenderer>().color = Color.white;
        backRightLeg.GetComponent<SpriteRenderer>().color = Color.white;
        frontLeftLeg.GetComponent<SpriteRenderer>().color = Color.white;
        frontRightLeg.GetComponent<SpriteRenderer>().color = Color.white;
        head.GetComponent<SpriteRenderer>().color = Color.white;
        body.GetComponent<SpriteRenderer>().color = Color.white;

        hidden = false;
    }
}
