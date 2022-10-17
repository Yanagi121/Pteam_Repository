using UniRx;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TitleModel : MonoBehaviour
{
    private BoolReactiveProperty _flag = new BoolReactiveProperty(false);
    public IReactiveProperty<bool> Flag => _flag;

    public void ValueUpdate(bool flag)
    {
        _flag.Value = flag;
    }
}
