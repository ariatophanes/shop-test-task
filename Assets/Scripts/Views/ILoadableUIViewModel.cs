using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public interface ILoadableUIViewModel : IUIViewModel
{
    UniTask Load(IDataLoader dataLoader);
}
