using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float _style;
    public float style => _style;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void AddStyle(float amountOfStyle)
    {
        _style += amountOfStyle; UpdateStyle();
    }

    public void DecreaseStyle(float amountOfStyle)
    {
        _style -= amountOfStyle; UpdateStyle();
        if(_style <= 0f) { ResetStyle(); }
    }


    public void ResetStyle()
    {
        _style = 0; UpdateStyle();
    }

    private void UpdateStyle()
    {
        if(_style == 0)
        {
            UIManager.UpdateStyle("");
        }
        else if (_style < 5)
        {
            UIManager.UpdateStyle("D");
        }
        else if (_style < 10)
        {
            UIManager.UpdateStyle("C");
        }
        else if (_style < 20)
        {
            UIManager.UpdateStyle("B");
        }
        else
        {
            UIManager.UpdateStyle("A");
        }
    }

}
