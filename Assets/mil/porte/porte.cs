using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porte : MonoBehaviour
{
	public int prixPorte;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public string affichageAchatPorte() 
    {
        return "Hold E to open Door [Cost: " + prixPorte + "]";
    }
    
    public void DestructDoor()
    {
		GetComponent<showDoorTextBuy>().eraseText();
		Destroy(gameObject);
	}
	
	public int getPriceDoor()
	{
		return prixPorte;
	}
}
