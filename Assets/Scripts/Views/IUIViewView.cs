using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IUIViewView : IParentableView
{
    void SetVisibility(bool visible);
}
