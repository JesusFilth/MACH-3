using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserStorage : IRecordStorage
{
    private const string UserKey = "User";

    private readonly TextAsset _defaultRecordSvg;

    private UserModel _user = new();

    public UserStorage(TextAsset defaultRecordSvg)
    {
        if (defaultRecordSvg == null)
            throw new ArgumentNullException(nameof(defaultRecordSvg));

        _defaultRecordSvg = defaultRecordSvg;

        Initialaze();
    }

    public RecordModel[] GetRecords()
    {
        return _user.GetRecordPrototype();
    }

    public int GetHightRecord()
    {
        const int FirstElementIndex = 0;

        Array.Sort(_user.Records);
        return _user.Records[FirstElementIndex].Score;
    }

    public void AddNewRecord(RecordModel record)
    {
        Array.Resize(ref _user.Records, _user.Records.Length + 1);
        _user.Records[_user.Records.Length - 1] = record;

        Save();
    }

    private void Initialaze()
    {
        if (PlayerPrefs.HasKey(UserKey))
            Load();
        else
        {
            LoadFromSVG();
            Save();
        }
    }

    private void Load()
    {
        try
        {
            string json = PlayerPrefs.GetString(UserKey);
            _user = JsonUtility.FromJson<UserModel>(json);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(_user);
        PlayerPrefs.SetString(UserKey, json);
    }

    private void LoadFromSVG()
    {
        StringReader reader = new StringReader(_defaultRecordSvg.text);
        List<RecordModel> _records = new();

        string line = string.Empty;

        while ((line = reader.ReadLine()) != null)
        {
            string[] values = line.Split(';');

            RecordModel record = new RecordModel
            {
                Data = values[0].Trim(),
                Score = int.Parse(values[1].Trim())
            };

            _records.Add(record);
        }

        _user.Records = new RecordModel[_records.Count];

        for (int i = 0; i < _records.Count; i++)
        {
            _user.Records[i] = _records[i];
        }
    }
}