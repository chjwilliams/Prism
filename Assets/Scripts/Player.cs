﻿using UnityEngine;
using System.Collections;

/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	Player: Communicates current state to PlayerController								*/
/*																						*/
/*		Internal Classes:																*/
/*			PlayerStats																	*/
/*		Functions:																		*/
/*			Start ()																	*/
/*			DamagePlayer (int damage)													*/
/*			OnCollisionEnter2D(Collision2D collision)									*/
/*			Update ()																	*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class Player : MonoBehaviour
{
	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	[CLASS]																				*/
	/*	PlayerStats: Stores player's internal stats											*/
	/*																						*/
	///*--------------------------------------------------------------------------------------*/
	[System.Serializable]
	public class PlayerStats
	{
		//	Public Variables
		public int Health = 10;
	}

	public int yLowerLimit = -20;							//	How far the player can go down without dying
	public float flinchTimer = 2f;							//	How long in seconds the player flinches for
	public float springForce = 400f;						//	For implementation of a spring
	public PlayerStats playerStats = new PlayerStats();		//	Reference to player stats

	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	Start: Runs once at the begining of the game. Initalizes variables.					*/
	/*																						*/
	///*--------------------------------------------------------------------------------------*/
	void Start () 
	{
	}

	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	DamagePlayer: Called when player should take damage									*/
	/*		param: int damage - how much damage the player should take						*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	public void DamagePlayer(int damage)
	{
		playerStats.Health -= damage;
		if (playerStats.Health <= 0)
		{
			GameMaster.KillPlayer (this);
			Debug.Log ("Player is dead");
		}
		else
		{
			PlayerController.INSTANCE.TriggerDamage (flinchTimer);
		}
	}

	/*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	OnCollisionEnter2D: Called when player collides with a 2D collider					*/
	/*		param: Collision2D collision - what the player collided with					*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	void OnCollisionEnter2D(Collision2D collision)
	{
		/*
		BasicEnemy enemy = collision.collider.GetComponent<BasicEnemy> ();
		if (enemy != null)
		{
			foreach (ContactPoint2D point in collision.contacts)
			{
				if (point.normal.y >= 0.9f)
				{
					if (collision.gameObject.tag == "Non-DamageEnemy")
					{
						PlayerController.INSTANCE.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, springForce));
						enemy.DamageEnemy (0);
					}

				}
			}
			if (collision.gameObject.tag != "Non-DamageEnemy")
				DamagePlayer (1);
		}
		*/
	}

	//*--------------------------------------------------------------------------------------*/
	/*																						*/
	/*	Update: Called once per frame														*/
	/*																						*/
	/*--------------------------------------------------------------------------------------*/
	void Update () 
	{
		if (transform.position.y <= yLowerLimit)
		{
			DamagePlayer (999999);
		}
	}
}