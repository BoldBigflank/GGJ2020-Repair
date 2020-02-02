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
    [SerializeField] Sprite trashBody, toiletBody, tigerBody, dinoBody, wormBody;
    private bool isVertical;
    private bool hidden;
    private float countdown;


    void Start()    //We would pass 5 body parts here and do logic to sort them semi-appropriately
    {
        string bodyType = "worm";
        switch (bodyType)
        {
            case "trash":
                body.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
                body.transform.GetComponent<SpriteRenderer>().sprite = trashBody;
                SetHorizontalBodyPartAnchors();
                break;
            case "worm":
                body.transform.position = new Vector3(-.71f, .22f, 0f);
                body.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -16.75f));
                body.transform.GetComponent<SpriteRenderer>().sprite = wormBody;
                SetHorizontalBodyPartAnchors();
                break;
            case "dino":
                body.transform.position = new Vector3(-.09f, .06f, 0f);
                body.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -10.94f));
                body.transform.localScale = new Vector3(.25f, .25f, 0f);
                body.transform.GetComponent<SpriteRenderer>().sprite = dinoBody;
                SetHorizontalBodyPartAnchors();
                break;
            case "toilet":
                body.transform.position = new Vector3(0f, 0.13f, 0f);
                body.transform.GetComponent<SpriteRenderer>().sprite = toiletBody;
                SetVerticalBodyPartAnchors();
                break;
            case "tiger":
                body.transform.position = new Vector3(0f, 0.13f, 0f);
                body.transform.GetComponent<SpriteRenderer>().sprite = tigerBody;
                SetVerticalBodyPartAnchors();
                break;

        }
        setBackLeftLeg("frogLeg");
        setBackRightLeg("frogLeg");
        setFrontLeftLeg("frogLeg");
        setFrontRightLeg("frogLeg");
        setHead("chameleonHead");

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

    private void setBackLeftLeg(string part)
    {

        Sprite sprite = null;
        switch (part)
        {
            case "frogLeg":
                sprite = frogBackLeg;
                break;
            case "catLeg":
                sprite = catBackLeg;
                break;
            case "chameleonLeg":
                sprite = chameleonLeg;
                break;
            case "cowLeg":
                sprite = cowBackLeg;
                break;
            case "giraffeLeg":
                sprite = giraffeBackLeg;
                break;
            case "koalaLeg":
                sprite = koalaBackLeg;
                break;
            case "octopusLeg":
                sprite = octopusBackLeg;
                break;
            case "toucanLeg":
                sprite = toucanFoot;
                break;
        }
        backLeftLeg.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void setBackRightLeg(string part)
    {

        Sprite sprite = null;
        switch (part)
        {
            case "frogLeg":
                sprite = frogFrontLeg;
                break;
            case "catLeg":
                sprite = catFrontLeg;
                break;
            case "chameleonLeg":
                sprite = chameleonLeg;
                break;
            case "cowLeg":
                sprite = cowFrontLeg;
                break;
            case "giraffeLeg":
                sprite = giraffeFrontLeg;
                break;
            case "koalaLeg":
                sprite = koalaFrontLeg;
                break;
            case "octopusLeg":
                sprite = octopusFrontLeg;
                break;
            case "toucanLeg":
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

    private void setFrontLeftLeg(string part)
    {
        Sprite sprite = null;
        switch (part)
        {
            case "frogLeg":
                sprite = frogBackLeg;
                break;
            case "catLeg":
                sprite = catBackLeg;
                break;
            case "chameleonLeg":
                sprite = chameleonLeg;
                break;
            case "cowLeg":
                sprite = cowBackLeg;
                break;
            case "giraffeLeg":
                sprite = giraffeBackLeg;
                break;
            case "koalaLeg":
                sprite = koalaBackLeg;
                break;
            case "octopusLeg":
                sprite = octopusBackLeg;
                break;
            case "toucanLeg":
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

    private void setFrontRightLeg(string part)
    {
        Sprite sprite = null;
        switch (part)
        {
            case "frogLeg":
                sprite = frogFrontLeg;
                break;
            case "catLeg":
                sprite = catFrontLeg;
                break;
            case "chameleonLeg":
                sprite = chameleonLeg;
                break;
            case "cowLeg":
                sprite = cowFrontLeg;
                break;
            case "giraffeLeg":
                sprite = giraffeFrontLeg;
                break;
            case "koalaLeg":
                sprite = koalaFrontLeg;
                break;
            case "octopusLeg":
                sprite = octopusFrontLeg;
                break;
            case "toucanLeg":
                if (isVertical)
                {
                    frontRightLeg.GetComponent<SpriteRenderer>().flipX = true;
                }
                sprite = toucanWing;
                break;
        }
        frontRightLeg.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void setHead(string part)
    {

        Sprite sprite = null;
        switch (part)
        {
            case "frogHead":
                sprite = frogHead;
                break;
            case "catHead":
                sprite = catHead;
                break;
            case "chameleonHead":
                sprite = chameleonHead;
                break;
            case "cowHead":
                sprite = cowHead;
                break;
            case "giraffeHead":
                sprite = giraffeHead;
                break;
            case "koalaHead":
                sprite = koalaHead;
                break;
            case "octopusHead":
                sprite = octopusHead;
                break;
            case "toucanHead":
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
