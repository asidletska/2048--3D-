using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CubeNumbers")]
class CubeNumbers : ScriptableObject
{
    [SerializeField] private int _base = 2;
    //[SerializeField] private int _startPower = 1;
    //[SerializeField] private int _endPower = 6;

    public int Generate()
    {
        int rand = Random.Range(0, 100);

        int power;
        if (rand < 75)
            power = 1; 
        else
            power = 2; 

        return GetNumber(power);
    }
    public int GenerateNext(int number)
    {
        var power = GetNextPower(number);
        return GetNumber(power);
    }

    public int GetIndex(int number)
    {
        var power = GetPower(number);
        var index = power - 1;

        return index;
    }
    public int GetNextPower(int number)
    {
        return GetPower(number) + 1;
    }
    public int GetPower(int number)
    {
        return (int)Mathf.Log(number, _base);
    }
    public int GetNumber(int power)
    {
        return (int)Mathf.Pow(_base, power);
    }
}

