﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawResourceInteract : MonoBehaviour, IInteractable {

    public Resource m_r;

	void Start () {
        m_r.m_rrInteractable = this;
        m_r.m_interactArea.GetComponent<InteractArea>().m_linkedInteract = this;
    }

	public void onTriggerEnter()
	{

	}

	public void onTriggerExit()
	{

	}

	public void Interact(GameObject player, Button button)
    {   
		if(button == Button.A)
		{
	        if (!m_r.linkedResource)
	        {
	            Debug.Log("ERROR: linked resource was not attached to resource");
	            return;
	        }


	        GameObject fr = Instantiate(m_r.linkedResource);
	        fr.transform.position = m_r.transform.position;
            m_r.m_resourceManager.numSpawnedRRs--;
            m_r.m_spawnPoint.OnCollected();
            Destroy(m_r.gameObject);
		}

	}
}
