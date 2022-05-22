using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement   ;

using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void Load(int index)
    {
       SceneManager.LoadScene(index);
        return ;

    }
}
