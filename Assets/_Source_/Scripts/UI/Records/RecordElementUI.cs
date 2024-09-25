using System;
using TMPro;
using UnityEngine;

public class RecordElementUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _number;
    [SerializeField] private TMP_Text _date;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        try
        {
            Validate();
        }
        catch (ArgumentNullException ex)
        {
            enabled = false;
            throw ex;
        }
    }

    public void Init(string number, string date, string score)
    {
        _number.text = number;
        _date.text = date;
        _score.text = score;
    }

    private void Validate()
    {
        if (_number == null)
            throw new ArgumentNullException(nameof(_number));

        if (_date == null)
            throw new ArgumentNullException(nameof(_date));

        if (_score == null)
            throw new ArgumentNullException(nameof(_score));
    }
}
