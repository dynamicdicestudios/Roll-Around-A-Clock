using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
	public AudioClip[] music;
	
	public GameObject dice;
	
	public GameObject begin;
	public GameObject winner;
	public GameObject loser;
	
    public Text time;		
	public Text winningNumbers;
    public Text winCount;
    public Text loseCount;
	
	public DiceScript diceA;
	public DiceScript diceB;
	public DiceScript diceC;
	
	public static bool hasBegun;
	public static bool roundOngoing;
	
	int roll = 0;
	int wins = 0;
	int losses = 0;
	
	int point;
	
	int diceNumber;
	
	int numA;
	int numB;
	int numC;
	
	bool rollingA;
	bool rollingB;
	bool rollingC;
	bool finished;
		
	// Start is called before the first frame update
    void Start()
    {
		audioSource.clip = music[0];
		audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
		rollingA = diceA.isRolling;
		rollingB = diceB.isRolling;
		rollingC = diceC.isRolling;
		
		numA = diceA.rolledNumber;
		numB = diceB.rolledNumber;
		numC = diceC.rolledNumber;
		
		diceNumber = DiceNumberTextScript.diceNumber;
		
		if (roll == 1)
			StartCoroutine(FirstCheck());
		else if (roll == 2)
			StartCoroutine(SecondCheck());
		else if (roll == 3)
			StartCoroutine(ThirdCheck());
		else if (roll == 4)
			StartCoroutine(FourthCheck());
		else if (roll == 5)
			StartCoroutine(FifthCheck());
		else if (roll == 6)
			StartCoroutine(SixthCheck());
		else if (roll == 7)
			StartCoroutine(SeventhCheck());
		else if (roll == 8)
			StartCoroutine(EighthCheck());
		else if (roll == 9)
			StartCoroutine(NinthCheck());
		else if (roll == 10)
			StartCoroutine(TenthCheck());
		else if (roll == 11)
			StartCoroutine(EleventhCheck());
		else if (roll == 12)
			StartCoroutine(TwelthCheck());
    }
	
	public void NextRoll() {
		point = 1;
		
		audioSource.clip = music[3];
		audioSource.Play();
		ResetRoll();
	}
	
	void Finish(){
		if (finished)
			return;
		finished = true;
		if (wins >= 6) {
			audioSource.clip = music[1];
			audioSource.Play();
			winner.SetActive(true);
		} else {
			audioSource.clip = music[2];
			audioSource.Play();
			loser.SetActive(true);
		}
	}
	
	IEnumerator InfoReset() {
		hasBegun = false;
		yield return new WaitForSeconds(3f);
		if (begin.activeSelf && hasBegun) {
		
		} else {
			audioSource.clip = music[0];
			audioSource.Play();
			
			begin.SetActive(true);
			if (roll == 1) {
				time.text = "It is two o'clock";
				winningNumbers.text = "Here are the winning numbers:\nAll even numbers";
			} else if (roll == 2) {
				time.text = "It is three o'clock";
				winningNumbers.text = "Here are the winning numbers:\n3, 6, 9, 12, 15, 18";
			} else if (roll == 3) {
				time.text = "It is four o'clock";
				winningNumbers.text = "Here are the winning numbers:\n4, 8, 12, 16";
			} else if (roll == 4) {
				time.text = "It is five o'clock";
				winningNumbers.text = "Here are the winning numbers:\n5, 10, 15";
			} else if (roll == 5) {
				time.text = "It is six o'clock";
				winningNumbers.text = "Here are the winning numbers:\n6, 12, 18";
			} else if (roll == 6) {
				time.text = "It is seven o'clock";
				winningNumbers.text = "Here are the winning numbers:\n7, 14";
			} else if (roll == 7) {
				time.text = "It is eight o'clock";
				winningNumbers.text = "Here are the winning numbers:\n8, 16";
			} else if (roll == 8) {
				time.text = "It is nine o'clock";
				winningNumbers.text = "Here are the winning numbers:\n9, 18";
			} else if (roll == 9) {
				time.text = "It is ten o'clock";
				winningNumbers.text = "Here is the winning number:\n10";
			} else if (roll == 10) {
				time.text = "It is eleven o'clock";
				winningNumbers.text = "Here is the winning number:\n11";
			} else if (roll == 11) {
				time.text = "It is twelve o'clock";
				winningNumbers.text = "Here is the winning number:\n12";
			}
		}
	}
	
	void ResetRoll() {
		begin.SetActive(false);
		hasBegun = true;
		roll += 1;
		DiceNumberTextScript.diceNumber = 0;
	}
	
	IEnumerator FirstCheck() {
		if (!roundOngoing || numA == 0 || numB == 0 || numC == 0) {
			yield break;
		} else {
			yield return new WaitForSeconds(3.5f);
			if (!rollingA && !rollingB && !rollingC) {
				if (diceNumber % 1 == 0 && diceNumber > 0)  {
					roundOngoing = false;
					wins += point;
					point = 0;
					winCount.text = "Wins\n" + wins.ToString();
				} else if (diceNumber > 0) {
					roundOngoing = false;
					losses += point;
					point = 0;
					loseCount.text = "Losses\n" + losses.ToString();
				}
				if (hasBegun)
					StartCoroutine(InfoReset());
			}
		}
	}
	
	IEnumerator SecondCheck() {
		if (!roundOngoing || numA == 0 || numB == 0 || numC == 0) {
			yield break;
		} else {
			yield return new WaitForSeconds(3.5f);
			if (!rollingA && !rollingB && !rollingC) {
				if (diceNumber % 2 == 0 && diceNumber > 0)  {
					roundOngoing = false;
					wins += point;
					point = 0;
					winCount.text = "Wins\n" + wins.ToString();
				} else if (diceNumber > 0) {
					roundOngoing = false;
					losses += point;
					point = 0;
					loseCount.text = "Losses\n" + losses.ToString();
				}
				if (hasBegun)
					StartCoroutine(InfoReset());
			}
		}
	}
	
	IEnumerator ThirdCheck() {
		if (!roundOngoing || numA == 0 || numB == 0 || numC == 0) {
			yield break;
		} else {
			yield return new WaitForSeconds(3.5f);
			if (!rollingA && !rollingB && !rollingC) {
				if (diceNumber % 3 == 0 && diceNumber > 0)  {
					roundOngoing = false;
					wins += point;
					point = 0;
					winCount.text = "Wins\n" + wins.ToString();
				} else if (diceNumber > 0) {
					roundOngoing = false;
					losses += point;
					point = 0;
					loseCount.text = "Losses\n" + losses.ToString();
				}
				if (hasBegun)
					StartCoroutine(InfoReset());
			}
		}
	}
	
	IEnumerator FourthCheck() {
		if (!roundOngoing || numA == 0 || numB == 0 || numC == 0) {
			yield break;
		} else {
			yield return new WaitForSeconds(3.5f);
			if (!rollingA && !rollingB && !rollingC) {
				if (diceNumber % 4 == 0 && diceNumber > 0)  {
					roundOngoing = false;
					wins += point;
					point = 0;
					winCount.text = "Wins\n" + wins.ToString();
				} else if (diceNumber > 0) {
					roundOngoing = false;
					losses += point;
					point = 0;
					loseCount.text = "Losses\n" + losses.ToString();
				}
				if (hasBegun)
					StartCoroutine(InfoReset());
			}
		}
	}
	
	IEnumerator FifthCheck() {
		if (!roundOngoing || numA == 0 || numB == 0 || numC == 0) {
			yield break;
		} else {
			yield return new WaitForSeconds(3.5f);
			if (!rollingA && !rollingB && !rollingC) {
				if (diceNumber % 5 == 0 && diceNumber > 0)  {
					roundOngoing = false;
					wins += point;
					point = 0;
					winCount.text = "Wins\n" + wins.ToString();
				} else if (diceNumber > 0) {
					roundOngoing = false;
					losses += point;
					point = 0;
					loseCount.text = "Losses\n" + losses.ToString();
				}
				if (hasBegun)
					StartCoroutine(InfoReset());
			}
		}
	}
	
	IEnumerator SixthCheck() {
		if (!roundOngoing || numA == 0 || numB == 0 || numC == 0) {
			yield break;
		} else {
			yield return new WaitForSeconds(3.5f);
			if (!rollingA && !rollingB && !rollingC) {
				if (diceNumber % 6 == 0 && diceNumber > 0)  {
					roundOngoing = false;
					wins += point;
					point = 0;
					winCount.text = "Wins\n" + wins.ToString();
				} else if (diceNumber > 0) {
					roundOngoing = false;
					losses += point;
					point = 0;
					loseCount.text = "Losses\n" + losses.ToString();
				}
				if (hasBegun)
					StartCoroutine(InfoReset());
			}
		}
	}
	
	IEnumerator SeventhCheck() {
		if (!roundOngoing || numA == 0 || numB == 0 || numC == 0) {
			yield break;
		} else {
			yield return new WaitForSeconds(3.5f);
			if (!rollingA && !rollingB && !rollingC) {
				if (diceNumber % 7 == 0 && diceNumber > 0)  {
					roundOngoing = false;
					wins += point;
					point = 0;
					winCount.text = "Wins\n" + wins.ToString();
				} else if (diceNumber > 0) {
					roundOngoing = false;
					losses += point;
					point = 0;
					loseCount.text = "Losses\n" + losses.ToString();
				}
				if (hasBegun)
					StartCoroutine(InfoReset());
			}
		}
	}
	
	IEnumerator EighthCheck() {
		if (!roundOngoing || numA == 0 || numB == 0 || numC == 0) {
			yield break;
		} else {
			yield return new WaitForSeconds(3.5f);
			if (!rollingA && !rollingB && !rollingC) {
				if (diceNumber % 8 == 0 && diceNumber > 0)  {
					roundOngoing = false;
					wins += point;
					point = 0;
					winCount.text = "Wins\n" + wins.ToString();
				} else if (diceNumber > 0) {
					roundOngoing = false;
					losses += point;
					point = 0;
					loseCount.text = "Losses\n" + losses.ToString();
				}
				if (hasBegun)
					StartCoroutine(InfoReset());
			}
		}
	}
	
	IEnumerator NinthCheck() {
		if (!roundOngoing || numA == 0 || numB == 0 || numC == 0) {
			yield break;
		} else {
			yield return new WaitForSeconds(3.5f);
			if (!rollingA && !rollingB && !rollingC) {
				if (diceNumber % 9 == 0 && diceNumber > 0)  {
					roundOngoing = false;
					wins += point;
					point = 0;
					winCount.text = "Wins\n" + wins.ToString();
				} else if (diceNumber > 0) {
					roundOngoing = false;
					losses += point;
					point = 0;
					loseCount.text = "Losses\n" + losses.ToString();
				}
				if (hasBegun)
					StartCoroutine(InfoReset());
			}
		}
	}
	
	IEnumerator TenthCheck() {
		if (!roundOngoing || numA == 0 || numB == 0 || numC == 0) {
			yield break;
		} else {
			yield return new WaitForSeconds(3.5f);
			if (!rollingA && !rollingB && !rollingC) {
				if (diceNumber % 10 == 0 && diceNumber > 0)  {
					roundOngoing = false;
					wins += point;
					point = 0;
					winCount.text = "Wins\n" + wins.ToString();
				} else if (diceNumber > 0) {
					roundOngoing = false;
					losses += point;
					point = 0;
					loseCount.text = "Losses\n" + losses.ToString();
				}
				if (hasBegun)
					StartCoroutine(InfoReset());
			}
		}
	}
	
	IEnumerator EleventhCheck() {
		if (!roundOngoing || numA == 0 || numB == 0 || numC == 0) {
			yield break;
		} else {
			yield return new WaitForSeconds(3.5f);
			if (!rollingA && !rollingB && !rollingC) {
				if (diceNumber % 11 == 0 && diceNumber > 0)  {
					roundOngoing = false;
					wins += point;
					point = 0;
					winCount.text = "Wins\n" + wins.ToString();
				} else if (diceNumber > 0) {
					roundOngoing = false;
					losses += point;
					point = 0;
					loseCount.text = "Losses\n" + losses.ToString();
				}
				if (hasBegun)
					StartCoroutine(InfoReset());
			}
		}
	}
	
	IEnumerator TwelthCheck() {
		if (!roundOngoing || numA == 0 || numB == 0 || numC == 0) {
			yield break;
		} else {
			yield return new WaitForSeconds(3.5f);
			if (!rollingA && !rollingB && !rollingC) {
				if (diceNumber % 12 == 0 && diceNumber > 0)  {
					roundOngoing = false;
					wins += point;
					point = 0;
					winCount.text = "Wins\n" + wins.ToString();
					
					if (wins >= 6) {
						audioSource.clip = music[1];
						audioSource.Play();
						winner.SetActive(true);
					} else {
						audioSource.clip = music[2];
						audioSource.Play();
						loser.SetActive(true);
					}
				} else if (diceNumber > 0) {
					roundOngoing = false;
					losses += point;
					point = 0;
					loseCount.text = "Losses\n" + losses.ToString();
					
					Finish();
				}
			}
		}
	}
}
