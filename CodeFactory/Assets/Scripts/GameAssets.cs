using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class GameAssets : MonoBehaviour
{
    // Creates an internal reference
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null)
            {
                _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            }
            return _i;
        }
    }

    public Sprite pog;
    public Sprite bronzePog;
    public Sprite silverPog;
    public Sprite goldPog;
    public Sprite diamondPog;
}
