using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataTest : MonoBehaviour//, ISaveable //we have to inherit from ISaveable
//we're going to see if these floats can be saved to and read from our save file
{
    public float healthFloat, maxHealthFloat;

    public object SaveState() //save method
    {
        return new SaveData()
        {
            healthFloat = this.healthFloat,
            maxHealthFloat = this.maxHealthFloat
        };
    }

    public void LoadState(object state) //load method
    {
        var saveData = (SaveData) state;
        healthFloat = saveData.healthFloat;
        maxHealthFloat = saveData.maxHealthFloat;
    }

    [Serializable]
    private struct SaveData //SaveData struct to hold the values we want to save in our save file
    {
        public float healthFloat;
        public float maxHealthFloat;
    }
}
