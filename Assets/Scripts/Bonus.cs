using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus
{
    private string text;
    private int points;

    public enum BonusType
    {
        target,
        penalty,
        missingParts,
        stolenParts,
        matchingParts
    }

    public Bonus(BonusType bonusType, int amount) { 
        switch (bonusType)
        {
            case BonusType.target:
                points = 2 * amount;
                text = "Target Animal Bonus: " + points;
                break;
            case BonusType.penalty:
                points = -2 * amount;
                text = "Penalty Animal Penalty: " + points;
                break;
            case BonusType.missingParts:
                points = -3 * amount;
                text = "Missing Parts Penalty: " + points;
                break;
            case BonusType.stolenParts:
                points = 1 * amount;
                text = "Stolen Parts Bonus: " + points;
                break;
            case BonusType.matchingParts:
                if (amount == 3)
                {
                    points = 3;
                }
                else if (amount == 4)
                {
                    points = 6;
                }
                else  //Matched all parts
                {
                    points = 10;
                }

                text = "Matching Parts Bonus: " + points;
                break;
        }
    }

    public string GetText()
    {
        return text;
    }

    public int GetPoints()
    {
        return points;
    }


}
