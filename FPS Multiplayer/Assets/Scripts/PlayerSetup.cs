﻿using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    private Behaviour[] componentsToDisable;

    private Camera sceneCamera;

    //Obligatorio en el Start para que funcione
    private void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}