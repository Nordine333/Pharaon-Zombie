using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class buyWeaponPlayer : MonoBehaviour
{
	//viseur
	private Ray ray;
	private RaycastHit hit;
	
	//animation 
	public Animator handAnimator;
	
	//argent 
	private argentPlayer playerArgent;
		
    // Start is called before the first frame update
    void Start()
    {
		playerArgent = GetComponent<argentPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnBuyWeapon()
    {
		ray = GetComponent<attaquePlayer>().cameraActif.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f,0.5f));
		if(Physics.Raycast(ray, out hit))
		{	
			//gerer detection arme au murs et l'achat
			if(hit.transform.tag == "Weapon")
			{
				Arme weaponToBuy = hit.transform.gameObject.GetComponent<Arme>();
				if(playerArgent.getArgent() >= weaponToBuy.getPrixWeapon())
				{
					GetComponent<attaquePlayer>().GetArme().EraseWeapon();
					GetComponent<attaquePlayer>().SetArme(weaponToBuy);
					weaponToBuy.GetComponent<ParentConstraint>().enabled = true;
					switch (weaponToBuy.getTypeArme()) 
					{
						case "Pistol": 
							handAnimator.SetTrigger("pistolet");
							break;
						case "AssautRiffle": 
							handAnimator.SetTrigger("ar");
							break;
						case "Shotgun": 
							handAnimator.SetTrigger("shotgun");
							break;
					}
					weaponToBuy.GetComponent<showTextBuy>().setAlreadyBuy(true);
					playerArgent.setArgent(-weaponToBuy.getPrixWeapon()); //retire l'argent de l'achat				
				}
			}
		}
	}
}
