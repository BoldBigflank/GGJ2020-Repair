using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCard
{
    LinkedList<Bonus> bonuses;
    private int bonusSize;
    private int totalScore;

    void Start()
    {

    }

    public void CalculateBonuses(LinkedList<BodyPart> bodyParts, AnimalType targetAnimal,
                          AnimalType penaltyAnimal)
    {
        bonuses = new LinkedList<Bonus>();
        int targetMatches = 0;
        int penaltyMatches = 0;
        int stolenParts = 0;
        int totalParts = 0;
        int[] animalCount = new int[30];    //Will grow if more than 30 animals are added
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
            animalCount[(int)bodyPart.animalType]++;
        }
        if (totalParts < 5)
        {
            Bonus missingPenalty = new Bonus(Bonus.BonusType.missingParts, 5 - totalParts);
            bonuses.AddLast(missingPenalty);
            bonusSize++;
        }
        if (penaltyMatches > 0)
        {
            Bonus penaltyBonus = new Bonus(Bonus.BonusType.penalty, penaltyMatches);
            bonuses.AddLast(penaltyBonus);
            bonusSize++;
        }
        if (targetMatches > 0)
        {
            Bonus targetBonus = new Bonus(Bonus.BonusType.target, targetMatches);
            bonuses.AddLast(targetBonus);
            bonusSize++;
        }
        for (int i = 0; i < 30; i++)
        {
            if (animalCount[i] >= 3)
            {
                Bonus matchingBonus = new Bonus(Bonus.BonusType.matchingParts, animalCount[i]);
                bonuses.AddLast(matchingBonus);
                bonusSize++;
                break;
            }
        }
        if (stolenParts > 0)
        {
            Bonus stolenBonus = new Bonus(Bonus.BonusType.stolenParts, stolenParts);
            bonuses.AddLast(stolenBonus);
            bonusSize++;
        }
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
