using UnityEngine.Scripting;

[System.Serializable]
public class UserModel
{
    [field: Preserve] public RecordModel[] Records;

    public RecordModel[] GetRecordPrototype()
    {
        RecordModel[] protitype = new RecordModel[Records.Length];

        for (int i = 0; i < Records.Length; i++)
        {
            protitype[i] = Records[i];
        }

        return protitype;
    }
}