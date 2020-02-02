using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealScript : MonoBehaviour
{
    [SerializeField] GameObject backLeftLeg, frontLeftLeg, body, head, backRightLeg, frontRightLeg;
    [SerializeField] Sprite frogBackLeg, frogFrontLeg, frogHead;
    [SerializeField] Sprite catBackLeg, catFrontLeg, catHead;
    [SerializeField] Sprite chameleonLeg, chameleonHead;
    [SerializeField] Sprite cowBackLeg, cowFrontLeg, cowHead;
    [SerializeField] Sprite giraffeBackLeg, giraffeFrontLeg, giraffeHead;
    [SerializeField] Sprite koalaBackLeg, koalaFrontLeg, koalaHead;
    [SerializeField] Sprite octopusBackLeg, octopusFrontLeg, octopusHead;
    [SerializeField] Sprite toucanFoot, toucanWing, toucanHead;


    // Start is called before the first frame update
    void Start()    //We would pass 5 body parts here and do logic to sort them semi-appropriately
    {
        setBackLeftLeg("giraffeLeg");
        setBackRightLeg("toucanLeg");
        setFrontLeftLeg("octopusLeg");
        setFrontRightLeg("toucanLeg");
        setHead("cowHead");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

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
                sprite = toucanFoot;
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
                sprite = toucanWing;
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
}
