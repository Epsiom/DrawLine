using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField] private ColorSO _colorPalette;
    [SerializeField] private LevelManager _levelManager;

    // Init this here or in LevelManager? Is LevelManager a component that should be reset each level?
    //[SerializeField] private GridManager _gridManager;
    //[SerializeField] private LineManager _lineManager;

    void Start()
    {
        //TODO: init the LevelManager???
    }
}
