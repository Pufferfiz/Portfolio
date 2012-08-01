using System;
using UnityEngine;

public class BuildingDrain
{
	/// <summary>
	/// My stats.
	/// </summary>
	private GameStats myStats;
	/// <summary>
	/// Gets my stats.
	/// </summary>
	/// <value>
	/// My stats.
	/// </value>
	public GameStats MyStats {
		get {
			return myStats;
		}
	}
	/// <summary>
	/// Gets a value indicating whether this <see cref="BuildingDrain"/> draining up. Draining up is for when buildings are created. 
	/// </summary>
	/// <value>
	/// <c>true</c> if draining up; otherwise, <c>false</c>.
	/// </value>
	public bool DrainingUp
	{
		get{

			return goingUp;
		}
	}

	/// <summary>
	/// The stats that will be subtracted each time  
	/// </summary>
	private GameStats numbertoSubtract;
	/// <summary>
	/// Number to divide up the inStats
	/// </summary>
	private int numbertoDivide = 4;
	/// <summary>
	/// The month the building was destroyed.
	/// </summary>
	private string monthDestroyed;
	/// <summary>
	/// Default Constructor.
	/// </summary>
	public BuildingDrain ()
	{

	}

	/// <summary>
	/// If true then the building is getting more stats as time progress, if false the building is losing stats 
	/// </summary>
	private bool goingUp;
	/// <summary>
	/// The max stats of stats that are going up.
	/// </summary>
	private GameStats maxStats;

	/// <summary>
	/// Initializes a new instance of the <see cref="BuildingDrain"/> class.
	/// </summary>
	/// <param name='inStats'>
	/// In stats.
	/// </param>
	/// <param name='upORdown'>
	/// If true the building is going up in stats, if false the building is getting decreaed in stats. 
	/// </para>
	public BuildingDrain(GameStats  inStats, bool upORdown)
	{
		goingUp = upORdown;

		monthDestroyed = GameTime.CurrentMonth.ToString();

		myStats = new GameStats(inStats);

		numbertoSubtract = new GameStats(myStats);

		if (upORdown == true)
		{
			maxStats = new GameStats(myStats);
			myStats = new GameStats();
		}	
		if (numbertoSubtract.Health !=0)
		numbertoSubtract.Health = (Math.Abs( numbertoSubtract.Health)) / numbertoDivide; 
		if(numbertoSubtract.ProductionRate !=0)
		numbertoSubtract.ProductionRate = (Math.Abs( numbertoSubtract.ProductionRate)) / numbertoDivide;
		if(numbertoSubtract.Energy !=0)
		numbertoSubtract.Energy = (Math.Abs( numbertoSubtract.Energy)) / numbertoDivide;
		if(numbertoSubtract.Technology !=0)
		numbertoSubtract.Technology = (Math.Abs( numbertoSubtract.Technology)) / numbertoDivide;

	}

	/// <summary>
	/// Reduces/adds the gamestats by a given ammont *see <see cref="BuildingDrain"/> for Number*
	/// </summary>
	public void Half()
	{
		if (goingUp == false)
		{
			if(myStats.Health != 0)
			myStats.Health = subtract(myStats.Health,numbertoSubtract.Health);
			if(myStats.ProductionRate != 0)
			myStats.ProductionRate = subtract(myStats.ProductionRate,numbertoSubtract.ProductionRate);
			if(myStats.Energy != 0)
			myStats.Energy = subtract(myStats.Energy,numbertoSubtract.Energy);
			if(myStats.Technology != 0)
			myStats.Technology = subtract(myStats.Technology,numbertoSubtract.Technology);
		}
		if (goingUp == true)
		{
			if(myStats.Health != maxStats.Health)
			myStats.Health = add(myStats.Health,numbertoSubtract.Health,maxStats.Health);
			if(myStats.ProductionRate != maxStats.ProductionRate)
			myStats.ProductionRate = add(myStats.ProductionRate,numbertoSubtract.ProductionRate,maxStats.ProductionRate);
			if(myStats.Energy != maxStats.Energy)
			myStats.Energy = add(myStats.Energy,numbertoSubtract.Energy,maxStats.Energy);
			if(myStats.Technology != maxStats.Technology)
			myStats.Technology = add(myStats.Technology,numbertoSubtract.Technology,maxStats.Technology);
		}



	}
	/// <summary>
	/// Adds a number to myStats
	/// </summary>
	/// <param name='number'>
	/// Number.
	/// </param>
	/// <param name='toAdd'>
	/// To add.
	/// </param>
	/// /// <param name='insign'>
	/// sign of the max stats
	/// </param>
	private int add(int number, int toAdd, int insign)
	{
		int sign = 1; // For checking whether or the not the stat is negative or positive and hold this so it can be multiplied later. Default if positive. 
		if (insign <0)
		{
			sign = -1; //means the number given is negative 
		}
		number = Math.Abs(number);
		number += toAdd;
		number *= sign; // change sign. 
		return number;
	}

	/// <summary>
	/// subtrats a number to myStats
	/// </summary>
	/// <param name='number'>
	/// Number.
	/// </param>
	/// <param name='toSubtract'>
	/// To subtract.
	/// </param>
	private int subtract(int number, int toSubtract)
	{

		int sign = 1; // For checking whether or the not the stat is negative or positive and hold this so it can be multiplied later. Default if positive. 
		if (number <=0)
		{
			sign = -1; //means the number given is negative 
		}
		number = Math.Abs(number);
		number -= toSubtract;
		number *= sign; // change sign. 
		return number;
	}

	/// <summary>
	/// Checkis if the gamestats are 0
	/// </summary>
	/// <returns>
	/// If the shard as no more rates to edit.
	/// </returns>
	public bool checkIfZero()
	{

		bool isZero = true; //temp var
		if (goingUp == false)
		{
			if (Math.Abs(myStats.Health) >= 1) //Checks if the health has more then 1
			{
				isZero = false;
			}
			if (Math.Abs(myStats.ProductionRate) >= 1)// check if the production has more then 1
			{
				isZero = false;
			}
			if (Math.Abs(myStats.Technology) >= 1) //Checks if the technology has more then 1
			{
				isZero = false;
			}
			if (Math.Abs(myStats.Energy) >= 1)// check if the energy has more then 1
			{
				isZero = false;
			}
		}

		if (goingUp == true)
		{
			if (maxStats.Health != myStats.Health)
			{
				isZero = false;
			}
			if (maxStats.ProductionRate != myStats.ProductionRate)
			{
				isZero = false;
			}
			if (maxStats.Energy != myStats.Energy)
			{
				isZero = false;
			}
			if (maxStats.Technology != myStats.Technology)
			{
				isZero = false;
			}
		}
		return isZero;
	}


		/// <summary>
	/// Determines whether this building is in anniversary.
	/// </summary>
	/// <returns>
	/// <c>true</c> if this building is on anniversary; otherwise, <c>false</c>.
	/// </returns>
	private bool IsAnniversary()
	{

			if (monthDestroyed == GameTime.CurrentMonth.ToString())
			{
				return true;
			}
			else
				return false;

	}

	/// <summary>
	/// makes it so that there is no draining and the stats are static. NOT TO BE USED anywere but when buildings are created at start. 
	/// </summary>
	internal void noDain()
	{
		this.myStats = this.maxStats;
	}



}
