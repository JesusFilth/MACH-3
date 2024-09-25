using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LinkButton : ButtonView
{
    [SerializeField] private string _url;

    protected override void OnClick() => Application.OpenURL(_url);
}
