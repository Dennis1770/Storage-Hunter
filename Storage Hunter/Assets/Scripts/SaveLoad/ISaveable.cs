using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
//This save load system was taken from the following video: https://youtu.be/yIsoAuOOG7Q
{
    object SaveState(); //return an object when you save the game
    void LoadState(Object state); //pass in the object when you load the game
}
