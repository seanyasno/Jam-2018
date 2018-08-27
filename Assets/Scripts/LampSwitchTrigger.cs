﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LampSwitchTrigger : MonoBehaviour {

    private GameObject pointLight;
    private GameObject lampLightTrigger;
    private NavMeshObstacle navMeshObstacle;

    // Use this for initialization
    void Start () {
        navMeshObstacle = GetComponentInParent<NavMeshObstacle>();
        pointLight = transform.parent.Find("Point Light").gameObject;
        lampLightTrigger = transform.parent.Find("LampLightRangeTriggerSphere").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Collision
    // If player in range trun on the point light, light collision and navmesh obstacle
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();

            // does the player has light source?
            if(player.isHoldingALightSource)
            {
                navMeshObstacle.enabled = true;
                pointLight.SetActive(true);
                lampLightTrigger.SetActive(true);
                player.isHoldingALightSource = false; // light source used
            }
        }
    }
}
