using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelChapterSO", menuName = "Create LevelChapterSO")]

public class LevelChapterSO : ScriptableObject
{
    [SerializeField] private Level[] _levels;

    public Level getLevel(int levelNumber)
    {
        return _levels[levelNumber];
    }
}




// TODO: Put all of these in separate classes!


// All the characteristics of the level
[System.Serializable]
public class Level
{
    public string name;
    public string description;
    public int gridWidth;
    public int gridHeight;

    public List<Vector2> disabledNodeCoordinatesList;
    public List<LineAreaObjective> lineAreaObjectiveList;
    public List<LineCoordinates> barrierLineCoordinatesList;
    public List<PatternVectors> objectivePatternList;
}


// The coordinates of the points delimiting an area, and the number of lines that the player must trace in it
[System.Serializable]
public class LineAreaObjective
{
    public int lineCountObjective;
    public List<Vector2> areaCoordinates;
}

// The coordinates of the start and end points of a line
[System.Serializable]
public class LineCoordinates
{
    public Vector2 startCoordinates;
    public Vector2 endCoordinates;
}

// Patterns that the player must reproduce in the game
// The patterns are stored as vectors, since they can be placed at any coordinates in the grid
[System.Serializable]
public class PatternVectors
{
    public List<Vector2> patternVectorList;
}
