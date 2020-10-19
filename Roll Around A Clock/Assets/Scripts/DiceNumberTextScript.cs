using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberTextScript : MonoBehaviour
{
    Text text;
	
	public DiceScript diceA;
	public DiceScript diceB;
	public DiceScript diceC;
	public static int diceNumber;
	
	public static bool finished;
	
	int numA, numB, numC, check;
	
	// Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		bool rollingA = diceA.isRolling;
		bool rollingB = diceB.isRolling;
		bool rollingC = diceC.isRolling;
		
		if (rollingA || rollingB || rollingC)
			return;
		
		numA = diceA.rolledNumber;
		numB = diceB.rolledNumber;
		numC = diceC.rolledNumber;
		
        diceNumber =  numA + numB + numC;
		/*if (diceNumber == check)
			finished = true;
		else
			finished = false;*/
		
		check = diceNumber;
		text.text = diceNumber.ToString();
    }
}
