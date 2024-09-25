using System;
using Reflex.Attributes;
using UnityEngine;

public class RecordsView : MonoBehaviour
{
    [SerializeField] private RecordElementUI _prefab;
    [SerializeField] private Transform _conteiner;

    [Inject] private IRecordStorage _storage;

    private void Awake()
    {
        Initialize();
    }

    private void OnValidate()
    {
        if (_prefab == null)
            throw new ArgumentNullException(nameof(_prefab));

        if (_conteiner == null)
            throw new ArgumentNullException(nameof(_conteiner));
    }

    private void Initialize()
    {
        RecordModel[] records = _storage.GetRecords();
        Array.Sort(records);

        for (int i = 0; i < records.Length; i++)
        {
            RecordElementUI recordUI = Instantiate(_prefab, _conteiner);
            recordUI.Init((i+1).ToString(), records[i].Data, records[i].Score.ToString());
        }
    }
}
