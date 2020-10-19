using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCheckScript : MonoBehaviour
{
    public DiceScript dice;
	public int num = 0;
	
	Vector3 diceVelocity;
	
	void Start() {
		diceVelocity = dice.diceVelocity;
	}
	
	void OnTriggerStay(Collider col) {
		if (diceVelocity.x == 0f && diceVelocity.y == 0f &&
		diceVelocity.z == 0f) {
			dice.isRolling = false;
			if (col.gameObject.name == "DiceCheckZone")
				dice.rolledNumber = num;
		}
	}
}
