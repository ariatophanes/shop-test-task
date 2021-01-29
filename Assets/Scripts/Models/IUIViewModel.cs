using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

public interface IUIViewModel : IParentableModel
{ 
    ReactiveProperty<bool> Visible { get; set; }
}
