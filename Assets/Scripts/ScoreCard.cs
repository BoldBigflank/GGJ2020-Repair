using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCard : MonoBehaviour
{
    LinkedList<Bonus> bonuses = new LinkedList<Bonus>();
    private int bonusSize;
    private int totalScore;

    void Start()
    {

    }

    public void CalculateBonuses(LinkedList<BodyPart> bodyParts, AnimalType targetAnimal,
                          AnimalType penaltyAnimal)
    {
        int targetMatches = 0;
        int penaltyMatches = 0;
        int stolenParts = 0;
        int totalParts = 0;
        foreach (BodyPart bodyPart in bodyParts)
        {
            if (bodyPart.animalType == targetAnimal)
            {
                targetMatches++;
            }
            else if (bodyPart.animalType == penaltyAnimal)
            {
                penaltyMatches++;
            }
            if (bodyPart.GetIsStolen())
            {
                stolenParts++;
            }
            totalParts++;
        }
        if (targetMatches > 0)
        {
            Bonus targetBonus = new Bonus(Bonus.BonusType.target, targetMatches);
            bonuses.AddLast(targetBonus);
        }
        if (penaltyMatches > 0)
        {
            Bonus penaltyBonus = new Bonus(Bonus.BonusType.penalty, penaltyMatches);
            bonuses.AddLast(penaltyBonus);
        }
        if (stolenParts > 0)
        {
            Bonus stolenBonus = new Bonus(Bonus.BonusType.stolenParts, stolenParts);
            bonuses.AddLast(stolenBonus);
        }
        if (totalParts < 5)
        {
            Bonus missingPenalty = new Bonus(Bonus.BonusType.missingParts, 5 - totalParts);
            bonuses.AddLast(missingPenalty);
        }
        bonusSize = bonuses.Count;
        totalScore = 0;
        foreach (Bonus bonus in bonuses)
        {
            totalScore += bonus.GetPoints();
        }
    }

    public LinkedList<Bonus> GetBonuses()
    {
        return bonuses;
    }

    public int GetBonusSize()
    {
        return bonusSize;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }
}
