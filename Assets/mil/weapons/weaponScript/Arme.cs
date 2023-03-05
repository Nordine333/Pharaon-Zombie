using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Arme : MonoBehaviour
{
	//attribut de la classe arme
    public string nom;
    public string typeArme;
    public int prix_weapon;
    public int prix_ammo;
    public int degats;
    public float portee;
    public float delaiAtk;
    public int nbMunitionsTotal;
    public int nbMunitionsChargeurMax;
    public int nbMunitionsChargeurCurrent; 
	public ParticleSystem tirParticle;
	
	//position de l'arme avant achat
    private Vector3 startPosition;
    private Quaternion startRotation;
	
	 // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public string affichageAchatArme() 
    {
        return "Hold E to buy " + nom + " [Cost: " + prix_weapon + "]";
    }
    
    public string affichageAchatAmmo() 
    {
        return "Hold E to buy ammo [Cost: " + prix_ammo + "]";
    }
    
    public void rechargeArme()
    {
		if(nbMunitionsTotal !=0)
		{
			nbMunitionsChargeurCurrent = nbMunitionsChargeurMax;
			nbMunitionsTotal -= nbMunitionsChargeurMax - nbMunitionsChargeurCurrent; //peut recharger sans que son chargeur soit vide
			//possible implementation bruit et animation de rechargement
		}
		else ; //possible implementation bruit arme vide 
	}
    
    public void armeTir()
    {		
		if(nbMunitionsChargeurCurrent == 0)
		{
			rechargeArme();
		}
		else 
		{			
			nbMunitionsChargeurCurrent -= 1;
			nbMunitionsTotal -= 1;
			
			//particule de tir
			tirParticle.Play();
			
			//possible implementation bruit arme
		}
	}
	
	public void EraseWeapon()
	{
		GetComponent<ParentConstraint>().enabled = false;
		transform.position = startPosition;
		transform.rotation = startRotation;
		GetComponent<showTextBuy>().setAlreadyBuy(false);
	}
	
	public int getDegats()
	{
		return degats;
	}
	
	public float getDelaiAtk()
	{
		return delaiAtk;
	}
	
	public string getTypeArme()
	{
		return typeArme;
	}
	
	public int getPrixWeapon()
	{
		return prix_weapon;
	}
	
	public int getPrixAmmo()
	{
		return prix_ammo;
	}
}
