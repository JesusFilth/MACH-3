using System;
using UnityEngine.Scripting;

[System.Serializable]
public class RecordModel : IComparable<RecordModel>
{
    [field: Preserve] public string Data;

    [field: Preserve] public int Score;

    public int CompareTo(RecordModel other)
    {
        return other.Score.CompareTo(Score);
    }
}
