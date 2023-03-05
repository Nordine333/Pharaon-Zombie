using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attaquePlayer : MonoBehaviour
{
	//arme
	public Arme arme;
	
	//compteur de temps
	private float NextFenetreAtk;
	
	//viseur
	private Ray ray;
	private RaycastHit hit;
	
	//animation 
	private Animator animatorPlayer;
	public ParticleSystem tirParticle;
	
	//camera
	public GameObject cameraActif;
	
    // Start is called before the first frame update
    void Start()
    {
        NextFenetreAtk = Time.time;
        animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnLeftAttack()
    {
		
		if(Time.time > NextFenetreAtk) // delai entre 2 attaques écoulé
		{
			//GetComponent<AudioSource>().PlayOneShot(arme.attaqueSound);
			//animatorPlayer.SetTrigger("shotReculAnim");
			arme.armeTir();
			ray = cameraActif.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f,0.5f));
			if(Physics.Raycast(ray, out hit))
			{	
				//gerer detection mob et infliger degats
				if(hit.transform.tag == "Ennemi")
				{
					hit.transform.gameObject.GetComponent<mobStats>().setVie(arme.getDegats());
					Debug.Log("degats infligés "+arme.getDegats());
					// argent gagnée selon l'etat de l'ennemi (possible implementation des parties de corps touchés qui rapporte +)
					int vieEnnemiTouchee = hit.transform.gameObject.GetComponent<mobStats>().getVie();
					if(vieEnnemiTouchee != 0) GetComponent<argentPlayer>().setArgent(10);
					else GetComponent<argentPlayer>().setArgent(100);

				}
			}
			NextFenetreAtk = Time.time + arme.getDelaiAtk(); // calcule prochain fenetre d'atk		
		}
		
	}
	
	public void SetArme(Arme newWeapon)
	{
		arme = newWeapon;
	}
	
	public Arme GetArme()
	{
		return arme;
	}
}
