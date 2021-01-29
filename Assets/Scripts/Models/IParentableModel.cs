using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IParentableModel
{
    ReactiveProperty<Transform> Parent { get; set; }
}
