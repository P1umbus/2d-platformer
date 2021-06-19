using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private UIManager _uIManager;

    private int _numberCoins;
    private int _allNumberCoins;

    private void Start()
    {
        var foundObjects = Object.FindObjectsOfType<Coin>();
        _allNumberCoins = foundObjects.Length;
        if (_allNumberCoins <= 0)
        {
            _allNumberCoins = 1;
            Debug.LogWarning("На уровне нет ни одной монетки!");
        }
    }

    public void AddCoin()
    {
        _numberCoins++;
        _text.text = _numberCoins.ToString();
        if (_numberCoins >= _allNumberCoins)
            _uIManager.Victory();
    }

    public void Die()
    {
        _uIManager.Defeat();
    }
}
