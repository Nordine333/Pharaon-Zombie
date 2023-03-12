using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundGestion : MonoBehaviour
{
	//Point d'apparition des mobs
	public List<Transform> mobSpawner;
	
	//Mob Prefab
	public GameObject zombiePrefab;
	public GameObject chienPrefab;
	
	//Canvas
	public Text textManche;
	public Text textZombieRestant;
	
	//Info round actuel
	const int nbZombieDefault = 3;
	private int nbZombies;
	private int numManche = 0;
	private float multZombieHealth;
	private float multZombieForce;
	
    // Start is called before the first frame update
    void Start()
    {
		nbZombies = nbZombieDefault;
        ProchaineManche(); // initialise manche 1
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void GenereMob(GameObject mob)
    {
		for(int i=0; i<nbZombies; i=i+1)
		{
			int indexRand = Random.Range(0, mobSpawner.Count - 1); //obtient un index de MobSpawner aleatoire
			Instantiate(mob, mobSpawner[indexRand].position, Quaternion.identity); //fait spawn un ennemi sur un mobSpawner random
		}
	}
    
    void ProchaineManche()
    {
		//possible implementation musique debut manche
		numManche +=1;                                                                       // (=8)
		nbZombies = nbZombieDefault + 2*numManche; // le nombre de zombie pour manche n = nbZombieDefault + 2n
		if(numManche%5==0) // tout les 5 rounds c'est une manche speciale
		{
			GenereMob(chienPrefab); 
		}
		else
		{
			GenereMob(zombiePrefab);
		}
		textZombieRestant.text = nbZombies.ToString();
		textManche.text = numManche.ToString();
		// activr multZombie health et force
	}
	
	
	public void SignalEnnemiMort()
	{
		nbZombies -=1;
		textZombieRestant.text = nbZombies.ToString();
		if(nbZombies == 0) Invoke("ProchaineManche", 7.5f); // fin de la manche
	}
}
