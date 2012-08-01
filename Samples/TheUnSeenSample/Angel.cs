using UnityEngine;
using System.Collections.Generic;

public class Angel : MonoBehaviour 
{
	#region members
	public float maxHealth = 100000;
	[HideInInspector] public float currentHealth;
	[HideInInspector] public int playerNumber;
	
	private JBSpellHandler mySpellHandler;
	
	//Cooldowns in seconds for recasting
	public float cooldown_Spell = 30.0f;
	public float cooldown_FireBullet = 3.0f;
	public float cooldown_Stealth = 60.0f;
	public float cooldown_Stun = 120.0f;

	
	//Current times that increment for cooldown
	[HideInInspector] public float time_Spell = 0.0f;
	[HideInInspector] public float time_FireBullet = 0.0f;
	[HideInInspector] public float time_Stealth = 0.0f;
	[HideInInspector] public float time_Stun = 0.0f;

	
	//Duration of stealth
	public float duration_Stealth = 5.0f;
    public float duraction_Stun = 10.0f;
	
	//Are these on cooldown?
	[HideInInspector] public bool spellOnCooldown = false;
	[HideInInspector] public bool fireOnCooldown = false;
	[HideInInspector] public bool stealthOnCooldown = false;
	[HideInInspector] public bool stunOnCooldown = false;

	
	[HideInInspector] public bool breakStealth = false;
	
    //variables needed for mouse panning up and down
    [HideInInspector] public Vector2 oldMousePosition;
    [HideInInspector] public Vector2 currentMousePosition;
    [HideInInspector] public Vector2 mouseMovementDelta;

    //variable needed for speed boost
    [HideInInspector]public float speedBoost = 1.0f;

    //variables needed for acceleration
    public Vector3 velocity;
    float speed = 0.0f;
    float slideTowardDesiredVectorHalfLife = 0.25f;
	
    [HideInInspector] public bool opponentSelected = false;
	[HideInInspector] public GameObject opponent;
	[HideInInspector] public Angel opponentScript;

    //Minion varibles
    public List<Minion> myMinions = new List<Minion>();
    private List<Minion> myStunnedMinons = new List<Minion>();
    public bool minionsAreStunned = false;


    internal bool gameisOver = false;
    private Texture gameOverScreen;
	#endregion
	
	void Start()
	{
		currentHealth = maxHealth;
		gameObject.AddComponent<JBSpellHandler>();
		mySpellHandler = gameObject.GetComponent<JBSpellHandler>() as JBSpellHandler;
	}

    void OnGUI()
    {
        if (gameisOver)
        {
            if (this.transform.tag == "Player1")
            {
                if (this.currentHealth <= 0)
                {
                    gameOverScreen = (Resources.Load("Win Screen/Red Lose Screen") as Texture);
                    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameOverScreen);
                }
                else
                {
                    gameOverScreen = (Resources.Load("Win Screen/Red Win Screen") as Texture);
                    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameOverScreen);
                }
            }
            if (this.transform.tag == "Player2")
            {
                if (this.currentHealth <= 0)
                {
                    gameOverScreen = (Resources.Load("Win Screen/Purple Lose Screen") as Texture);
                    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameOverScreen);
                }
                else
                {
                    gameOverScreen = (Resources.Load("Win Screen/Purple Win Screen") as Texture);
                    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameOverScreen);
                }
            }

            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 , 100, 100), "Quit Game"))
            {
                Application.Quit();
            }

        }
    }

    void CheckGameover()
    {
        
        
            if (this.currentHealth <= 0)
            {
                gameisOver = true;
            }
            if (this.tag == "Player1")
            {
                Angel someangle = (GameObject.FindGameObjectWithTag("Player2").GetComponent<Angel>());
                if (someangle.currentHealth <= 0)
                {
                    gameisOver = true;
                }
            }
            else
            {
                Angel someangle = (GameObject.FindGameObjectWithTag("Player1").GetComponent<Angel>());
                if (someangle.currentHealth <= 0)
                {
                    gameisOver = true;
                }
            }
        
    }
	void Update () 
	{
		
		//Set opponent - Can't do it in start because your opponent might not be in the game yet
		if(opponent == null)
		{
			if(gameObject.tag == "Player1")
			{
				opponent = GameObject.FindGameObjectWithTag("Player2");
				if(opponent != null)
					opponentScript = opponent.GetComponent<Angel>() as Angel;
			}
			else if (gameObject.tag == "Player2")
			{
				opponent = GameObject.FindGameObjectWithTag("Player1");
				if(opponent != null)
					opponentScript = opponent.GetComponent<Angel>() as Angel;
			}
		}
		
		if(networkView.isMine)
		{		
			//Input
			SpellInput();
			Vector3 oldPosition = transform.position;
			FlightInput();
			HandleCollision(oldPosition);
			MouseInput();
            CheckGameover();
			//Spell Cooldowns
			HandleCooldowns();
			
			//Firing projectiles
		    mySpellHandler.UpdateSpells();
		
	        if (stealthOnCooldown && time_Stealth < duration_Stealth && !breakStealth)
				networkView.RPC("Stealth", RPCMode.All, networkView.viewID);
			else
				networkView.RPC("Unstealth", RPCMode.All, networkView.viewID);

            //Debug.Log("Stun on cool down " + stunOnCooldown.ToString() + " miunions stunned " + minionsAreStunned.ToString());
            if (stunOnCooldown && time_Stun > duraction_Stun)
            {
                networkView.RPC("AwakeMinions", RPCMode.All, opponent.networkView.viewID);
            }
		}
	}
	
    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.collider.enabled = false;
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(Camera.mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
				if(hit.collider.gameObject == opponent)
					opponentSelected = true;
            }
            this.collider.enabled = true;
        }
    }
	
	private void SpellInput()
	{
		//1 - Fire
		if(Input.GetKeyDown(KeyCode.Alpha1) && fireOnCooldown == false && opponentSelected)
		{
            mySpellHandler.Fire(opponent);
			fireOnCooldown = true;
			breakStealth = true;		
		}
		
		//2 - Spawn minion
		if(Input.GetKeyDown(KeyCode.Alpha2) && spellOnCooldown == false)
		{
			//Implement: Spawn minion
            if (SpawnMinion())
            {
                spellOnCooldown = true;
                breakStealth = true;
            }
		}
		
		//3 - Stun minions
		if(Input.GetKeyDown(KeyCode.Alpha3) && stunOnCooldown == false)
		{
			//Implement: Stun minions
            networkView.RPC("StunMinions", RPCMode.All, opponent.networkView.viewID);
			stunOnCooldown = true;
			breakStealth = true;
		}
		
		//4 - Stealth
		if(Input.GetKeyDown(KeyCode.Alpha4) && stealthOnCooldown == false)
		{
			breakStealth = false;
			stealthOnCooldown = true;
		}
	}
	
	void HandleCooldowns()
	{
		UpdateTime(ref time_Spell, ref spellOnCooldown, cooldown_Spell);
		UpdateTime(ref time_FireBullet, ref fireOnCooldown, cooldown_FireBullet);
		UpdateTime(ref time_Stealth, ref stealthOnCooldown, cooldown_Stealth);
		UpdateTime(ref time_Stun, ref stunOnCooldown, cooldown_Stun);
        
        
	}
	
	void UpdateTime(ref float time, ref bool onCooldown, float cooldownTime)
	{
		if(onCooldown)
		{
			time += Time.deltaTime;
		}
		
		if(time > cooldownTime)
		{
			time = 0;
			onCooldown = false;
		}
	}

	#region Flight and Movement
    private void FlightInput()
    {
		transform.position += velocity * Time.deltaTime;
		
        //currently only used to boost the rate at which the player turns around
        if (Input.GetKey(KeyCode.Space))
        {
            speedBoost = 2.0f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            speedBoost = 1.0f;
        }

        Quaternion currentOrientation = transform.rotation;

        //first time the right mouse button is clicked, this gets the mouses position
        if (Input.GetMouseButtonDown(1))
        {
            oldMousePosition = Input.mousePosition;
        }

        //while user holds the right mouse button down, this determines if the user has moved the mouse up or down		
        if (Input.GetMouseButton(1))
        {
            currentMousePosition = Input.mousePosition;
            mouseMovementDelta.y = currentMousePosition.y - oldMousePosition.y;

            if (mouseMovementDelta.y > 50.0f * Time.deltaTime)
            {
                Quaternion adjustment = Quaternion.AngleAxis(-40.0f * Time.deltaTime, new Vector3(1.0f, 0.0f, 0.0f));
                currentOrientation = currentOrientation * adjustment;
                oldMousePosition = currentMousePosition;
            }
            else if (mouseMovementDelta.y < -50.0f * Time.deltaTime)
            {
                Quaternion adjustment = Quaternion.AngleAxis(40.0f * Time.deltaTime, new Vector3(1.0f, 0.0f, 0.0f));
                currentOrientation = currentOrientation * adjustment;
                oldMousePosition = currentMousePosition;
            }
        }

        //player moves forward
        if (Input.GetKey(KeyCode.W))
        {
            speed += 50.0f * Time.deltaTime;
        }

        //puts the brakes on to rapidly stop the player
        if (Input.GetKey(KeyCode.S))
        {
            speed *= 1.0f - 0.9f * Time.fixedDeltaTime;
        }

        //player moves backwards at half speed
        if (Input.GetKey(KeyCode.X))
        {
            speed -= 25.0f * Time.deltaTime;
        }

        //turns player around smoothly
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion adjustment1 = Quaternion.AngleAxis(30.0f * speedBoost * Time.deltaTime, new Vector3(0.0f, 0.0f, 1.0f));
            Quaternion adjustment2 = Quaternion.AngleAxis(-30.0f * speedBoost * Time.deltaTime, new Vector3(0.0f, 1.0f, 0.0f));
            currentOrientation = currentOrientation * adjustment1 * adjustment2;
        }

        //turns player around smoothly
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion adjustment1 = Quaternion.AngleAxis(-30.0f * speedBoost * Time.deltaTime, new Vector3(0.0f, 0.0f, 1.0f));
            Quaternion adjustment2 = Quaternion.AngleAxis(30.0f * speedBoost * Time.deltaTime, new Vector3(0.0f, 1.0f, 0.0f));
            currentOrientation = currentOrientation * adjustment1 * adjustment2;
        }

        //player moves right and tilts
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += transform.right * 20.0f * Time.deltaTime;
            Quaternion adjustment = Quaternion.AngleAxis(-5.0f * Time.deltaTime, new Vector3(0.0f, 1.0f, 0.0f));
            currentOrientation = currentOrientation * adjustment;
        }

        //player moves left and tilts
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position -= transform.right * 20.0f * Time.deltaTime;
            Quaternion adjustment = Quaternion.AngleAxis(5.0f * Time.deltaTime, new Vector3(0.0f, 1.0f, 0.0f));
            currentOrientation = currentOrientation * adjustment;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion adjustment = Quaternion.AngleAxis(30.0f * Time.deltaTime, new Vector3(0.0f, 1.0f, 0.0f));
            currentOrientation = currentOrientation * adjustment;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion adjustment = Quaternion.AngleAxis(-30.0f * Time.deltaTime, new Vector3(0.0f, 1.0f, 0.0f));
            currentOrientation = currentOrientation * adjustment;
        }

        transform.rotation = currentOrientation;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += 10.0f * Time.deltaTime;
        }
		
        if (Input.GetKey(KeyCode.DownArrow))
        {
            speed *= 1.0f - 0.9f * Time.fixedDeltaTime;
        }

        //player slows down gradually
        speed *= 1.0f - 0.1f * Time.fixedDeltaTime;
        speed = Mathf.Min(speed, 100.0f);
		
		SlideTowardDesiredSpeed();
        ///glides left and right
        //not currently implemented because it looks like shit
        ///if (Input.GetKey (KeyCode.R))
        ///{
        ///	transform.position += transform.right * 30.0f * Time.deltaTime;
        ///}
        ///
        ///if (Input.GetKey (KeyCode.T))
        ///{
        ///	transform.position -= transform.right * 30.0f * Time.deltaTime;
        ///}

    }

    private void SlideTowardDesiredSpeed()
    {
        //this should be between 0 (my current velocity) and 1 (my desired velocity)
        float interpConstant = 1.0f - Mathf.Pow(0.5f, Time.deltaTime / slideTowardDesiredVectorHalfLife);
        Vector3 desiredVelocity = speed * (transform.up + transform.forward) / 2.0f;
        velocity = Vector3.Lerp(velocity, desiredVelocity, interpConstant);
    }
	#endregion

    public void HurtMe(int damage)
    {
        this.currentHealth -= damage;
    }
    /// <summary>
    /// Spawns a minion on a random spawner location
    /// </summary>
    private bool SpawnMinion()
    {
        if (this.transform.tag == "Player1")
        {
            GameObject[] mySpawners = GameObject.FindGameObjectsWithTag("MinSpawnP1");
            List<MinionSpawner> minionspawnlist = new List<MinionSpawner>();
            foreach (GameObject a in mySpawners)
            {
                MinionSpawner b = a.GetComponent<MinionSpawner>();
                if (b.hasAMinion == false)
                {
                    minionspawnlist.Add(b);
                }
            }
            if (minionspawnlist.Count > 0)
            {

                int rand = Random.Range(0, minionspawnlist.Count);
                mySpawners[rand].GetComponent<MinionSpawner>().hasAMinion = true;
                Minion temp = (Network.Instantiate(Resources.Load("MinionP1"), mySpawners[rand].transform.position, mySpawners[rand].transform.rotation, 0) as GameObject).GetComponent<Minion>();
                this.myMinions.Add(temp);

            }
            else
            {
                return false;
            }
        }
        if (this.transform.tag == "Player2")
        {
            GameObject[] mySpawners = GameObject.FindGameObjectsWithTag("MinSpawnP2");
            List<MinionSpawner> minionspawnlist = new List<MinionSpawner>();
            foreach (GameObject a in mySpawners)
            {
                MinionSpawner b = a.GetComponent<MinionSpawner>();
                if (b.hasAMinion == false)
                {
                    minionspawnlist.Add(b);
                }
            }
            if (minionspawnlist.Count > 0)
            {

                int rand = Random.Range(0, minionspawnlist.Count);
                mySpawners[rand].GetComponent<MinionSpawner>().hasAMinion = true;
                Minion temp = (Network.Instantiate(Resources.Load("MinionP2"), mySpawners[rand].transform.position, mySpawners[rand].transform.rotation, 0) as GameObject).GetComponent<Minion>();
                this.myMinions.Add(temp);

            }
            else
            {
                return false;
            }
        }
       
        return true;
    }

    /// <summary>
    /// Stuns all your minions
    /// </summary>
    [RPC]
    public void StunMinions(NetworkViewID angelID)
    {
        GameObject SomeGuy = NetworkView.Find(angelID).observed.gameObject;
        Angel asd = (SomeGuy.GetComponent<Angel>() as Angel);
        if (SomeGuy.transform.tag == "Player1")
        {
            GameObject[] myMinions = GameObject.FindGameObjectsWithTag("MinionP1");
            asd.stunstun();
            Debug.Log("Stunned minions on player 1, I am " + gameObject.name);
        }
        if (SomeGuy.transform.tag == "Player2")
        {
            GameObject[] myMinions = GameObject.FindGameObjectsWithTag("MinionP2");
            asd.stunstun();
            Debug.Log("Stunned minions on player 2, I am " + gameObject.name);
        }
    }

    public void stunstun()
    {
        this.myStunnedMinons = this.myMinions;
        this.myMinions.Clear();
        this.minionsAreStunned = true;

        
    }

    /// <summary>
    /// Awakes my minions
    /// </summary>
    [RPC]
    void AwakeMinions(NetworkViewID angelID)
    {
		Angel angel = NetworkView.Find(angelID).observed.gameObject.GetComponent<Angel>() as Angel;
		if(angel.transform.tag == "Player1")
		{
			GameObject[] minions = GameObject.FindGameObjectsWithTag("MinionP1");
			angel.myMinions.Clear();
			foreach(GameObject minion in minions)
			{
				Minion minionScript = minion.GetComponent<Minion>() as Minion;
				angel.myMinions.Add(minionScript);
			}
        	//angel.myMinions = GameObject.FindGameObjectsWithTag("MinSpawnP1");
		}
		else if(angel.transform.tag == "Player2")
		{
			GameObject[] minions = GameObject.FindGameObjectsWithTag("MinionP2");
			angel.myMinions.Clear();
			foreach(GameObject minion in minions)
			{
				Minion minionScript = minion.GetComponent<Minion>() as Minion;
				angel.myMinions.Add(minionScript);
			}
		}
        angel.minionsAreStunned = false;

    }
	
	[RPC]
	void Stealth(NetworkViewID angelID)
	{
		GameObject iFoundYouMissNewBooty = NetworkView.Find(angelID).observed.gameObject;
		
		for(int i = 0; i < iFoundYouMissNewBooty.transform.GetChildCount(); ++i)
		{
			if(iFoundYouMissNewBooty.transform.GetChild(i).renderer != null)
			{
				iFoundYouMissNewBooty.transform.GetChild(i).renderer.enabled = false;
			}
		}
		
		(iFoundYouMissNewBooty.GetComponent<Angel>() as Angel).opponentScript.opponentSelected = false;
	}
	
	[RPC]
	void Unstealth(NetworkViewID angelID)
	{
		for(int i = 0; i < NetworkView.Find(angelID).observed.gameObject.transform.GetChildCount(); ++i)
		{
			if(NetworkView.Find(angelID).observed.gameObject.transform.GetChild(i).renderer != null)
			{
				NetworkView.Find(angelID).observed.gameObject.transform.GetChild(i).renderer.enabled = true;
			}
		}
	}
	
	private void HandleCollision(Vector3 oldPosition)
	{
		if (collider is CapsuleCollider)
		{
			CapsuleCollider capCollider = collider as CapsuleCollider;
			float fudgeFactor = 100.0f * transform.localScale.x;
			float radius = capCollider.radius * transform.localScale.x + fudgeFactor;
			float transformedHeight = capCollider.height * transform.localScale.y + fudgeFactor;
			Vector3 transformedCenter = new Vector3(transform.localScale.x * capCollider.center.x,
													transform.localScale.y * capCollider.center.y,
													transform.localScale.z * capCollider.center.z);
			Vector3 point1 = oldPosition + transform.rotation * transformedCenter + transform.up * transformedHeight / 2.0f;
			Vector3 point2 = oldPosition + transform.rotation * transformedCenter - transform.up * transformedHeight / 2.0f;
			Vector3 deltaMove = transform.position - oldPosition;
			
			RaycastHit hitInfo;
			//print("transform.localScale.x = " + transform.localScale.x);
			//print("deltaMove = " + deltaMove + ", oldPosition = " + oldPosition);
			int layerMask = 1 << gameObject.layer;
			layerMask |= 1 << LayerMask.NameToLayer("Ignore Raycast");
			if (Physics.CapsuleCast(point1, point2, radius, deltaMove.normalized, out hitInfo, deltaMove.magnitude, ~layerMask))
			{
				float distanceMoved = hitInfo.distance;
			
				Vector3 actualMoveDelta = deltaMove.normalized * distanceMoved;
				transform.position = actualMoveDelta + oldPosition;
			
				float distanceLeft = deltaMove.magnitude - distanceMoved;
			
				Vector3 newMovementVector = Vector3.Reflect(deltaMove, hitInfo.normal);
				newMovementVector= newMovementVector.normalized * distanceLeft;
				transform.position += newMovementVector;
				velocity = Vector3.Reflect(velocity, hitInfo.normal);
				velocity *= 0.5f;
				speed *= 0.5f;
				//print("hit " + hitInfo.transform.gameObject.name);
			}
		}
	}
}
