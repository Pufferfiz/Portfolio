using UnityEngine;
using System.Collections.Generic;

public class Spellhandeler
{

    #region members
    List<SpellProjectile> myProjectiles = new List<SpellProjectile>();
    private Vector3 myPosition;
    internal int timesHit = 0;
    #endregion members


    /// <summary>
    /// defualt constructor
    /// </summary>
    public Spellhandeler()
    {
    }

    /// <summary>
    /// Main update loop that is called by unity automaticly
    /// </summary>
    /// 
    public void Update()
    {
        
        foreach (SpellProjectile aSpell in myProjectiles.ToArray())
        {
            aSpell.Update();
            if (aSpell.Hit == true)
            {
                timesHit++;
                
                myProjectiles.Remove(aSpell);
                aSpell.kill();
            }
        }
    }
    /// <summary>
    /// Updates just the postion of the handler to where the angel is. 
    /// </summary>
    /// <param name="inpos"></param>
    public void UpdatePosition(Vector3 inpos)
    {
        this.myPosition = inpos;
    }

    /// <summary>
    /// Fires a spell projectile 
    /// </summary>
    /// <param name="inPos"></param>
    public void Fire(Vector3 inPos)
    {
        SpellProjectile temp;
        temp = (NetworkView.Instantiate(Resources.Load("SpellShot"),this.myPosition,Quaternion.identity) as GameObject).GetComponent<SpellProjectile>();
        temp.Fire(inPos);
        myProjectiles.Add(temp);
    }
}

