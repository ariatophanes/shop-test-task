using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface ILoadableUIVievFactory
{
    ILoadableUIViewModel CreateProduct(GameObject UI);
}
