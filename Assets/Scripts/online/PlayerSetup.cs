using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    private void Start()
    {
        // on désactive les scripts du joueur qui n'héberge pas la partie sur notre insatnce  pour ne pas déplacer 
        // l'autre joueur en même temps que notre personnage
        if (!isLocalPlayer)
        {
            for(int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
    }
}
