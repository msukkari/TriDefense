﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public Vector3 reqs;
    public GameObject unit;
}

public class UnitGenerator : MonoBehaviour {

    // these are split up so they can be changed in the editor
    public List<Vector3> m_reqList;
    public List<GameObject> m_unitList;
	public Dictionary<Vector3, GameObject> m_recipeMap;

    public GameObject m_spawnPoint;
    public Vector3 m_curResources; // [metal, oil, rubber]

    public GameObject m_interactArea;
    public IInteractable m_ugInteract;

	public SpriteRenderer m_spriteRenderer;

	// Use this for initialization
	void Start () {
        if (m_reqList.Count != m_unitList.Count) Debug.Log("Requirment list is not the same size as unit list!");

        // Build recipe map
        m_recipeMap = new Dictionary<Vector3, GameObject>();
        for(int i = 0; i < m_reqList.Count; i++)
        {
            m_recipeMap[m_reqList[i]] = m_unitList[i];
        }

        m_curResources = Vector3.zero;
		m_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void Update()
	{
		Animator anim = this.GetComponent<Animator> ();
		if (anim != null)
		{
			anim.SetInteger ("State",(int)( m_curResources.x + m_curResources.y + m_curResources.z));
		}
	}
}
