using System;
using Reflex.Core;
using UnityEngine;

public class ProjectDI : MonoBehaviour, IInstaller
{
    [SerializeField] private TextAsset _defaultRecordSVG;

    private void OnValidate()
    {
        if (_defaultRecordSVG == null)
            throw new ArgumentNullException(nameof(_defaultRecordSVG));
    }

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(new UserStorage(_defaultRecordSVG), typeof(IRecordStorage));
    }
}
