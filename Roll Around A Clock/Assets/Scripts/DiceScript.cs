using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    Rigidbody rb;
	
	public GameManager gameManager;
	public Vector3 diceVelocity;
	
	public bool isRolling = false;
	public int rolledNumber;
	
	Vector3 startPos;
	
	// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		diceVelocity = rb.velocity;
		
		if (diceVelocity.x != 0f && diceVelocity.y != 0f &&
		diceVelocity.z != 0f && GameManager.roundOngoing)
			return;
		
		if (Input.GetKeyDown(KeyCode.Space) && !isRolling 
		&& GameManager.hasBegun && !gameManager.begin.activeSelf) {
			GameManager.roundOngoing = true;
			isRolling = true;
			DiceNumberTextScript.diceNumber = 0;
			float dirX = Random.Range(0, 500);
			float dirY = Random.Range(0, 500);
			float dirZ = Random.Range(0, 500);
			transform.position = startPos;
			transform.rotation = Quaternion.identity;
			rb.AddForce(transform.up * 500);
			rb.AddTorque(dirX, dirY, dirZ);
		}
    }
}
