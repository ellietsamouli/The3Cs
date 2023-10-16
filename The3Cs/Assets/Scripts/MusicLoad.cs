using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoad : MonoBehaviour
{
    private static MusicLoad instance;

    void Start()
    {
        // Check if an instance of AudioManager already exists.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // This line keeps the object alive between scenes.
        }
        else
        {
            // If an instance already exists, destroy this object.
            Destroy(gameObject);
        }
    }


}
