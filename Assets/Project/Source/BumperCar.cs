using UnityEngine;
using System.Collections;

public class BumperCar : MonoBehaviour {

	[SerializeField]
	private string carName;
	[SerializeField]
	private string playerName;

	[SerializeField]
	private float maxVelocity;
	[SerializeField]
	private float maxTorque;
	[SerializeField]
	private float maxDurability;
	[SerializeField]
	private float currentDurability;
	private float xp;

	[SerializeField]
	private int coins;
	private int level;
	private int hitsGiven;
	private int hitsTaken;

	public int getHitsGiven() {
		return hitsGiven;
	}

	public int getHitsTaken() {
		return hitsTaken;
	}

	public void gaveHit() {
		hitsGiven++;
	}

	public void takeHit() {
		hitsTaken++;
	}

	public int getLevel() {
		return level;
	}

	public int getCoins(int value) {
		return coins;
	}

	public int addCoins(int value) {
		coins += value;
		return coins;
	}

	public int removeCoins(int value) {
		if (value >= coins) {
			coins = 0;
			return coins;
		}
		coins -= value;
		return coins;
	}

	public float increaseXp(float value) {
		xp += value;
		return xp;
	}

	public float getXp() {
		return xp;
	}

	public float getMaxTorque() {
		return maxTorque;
	}

	public float setMaxTorque(float value) {
		maxTorque = value;
		return maxTorque;
	}

	public float getHeight() {
		return gameObject.transform.localScale.y;
	}

	public string getCarName() {
		return carName;
	}

	public string setCarName(string name) {
		carName = name;
		return carName;
	}

	public string getPlayerName() {
		return playerName;
	}
	
	public string setPlayerName(string name) {
		playerName = name;
		return playerName;
	}

	public float getMaxDurability() {
		return maxDurability;
	}

	public float setMaxDurability(float value) {
		maxDurability = value;
		return maxDurability;
	}

	public float getCurrentDurability() {
		return (currentDurability <= 0 ? 0 : currentDurability);
	}

	public float setCurrentDurability(float value) {
		currentDurability = value;
		return currentDurability;
	}

	public bool isUseless() {
		return getCurrentDurability() <= 0;
	}

	public float dealDamage(float damage) {
		if (damage >= currentDurability) {
			currentDurability = 0;
			return damage;
		}
		currentDurability -= damage;
		return damage;
	}


	public void heal(float aumont) {
		if (getCurrentDurability() < maxDurability && !isUseless()) {
			currentDurability += aumont;
			if (currentDurability > maxDurability) {
				currentDurability = maxDurability;
			}
		}
	}
}