using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class Level
{
    public string id;
    public int score;
    public int stars;
    public int attrmpts;
}


[System.Serializable]
public class LevelInfo
{
    public string id;
    public string scene;
    public string title;    
}