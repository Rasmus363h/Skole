namespace RPGSpil;

public class Goblin
{
    private int _liv = 20;
    public int Liv                        
    {                                     
        get { return this._liv; }         
        set { this._liv = value; }        
    }                                     
    private int _energi = 10;
    public int Energi
    {
        get { return this._energi; }
        set { this._energi = value; }
    }
    
    Random rnd = new Random();     
    (int damage, bool crit) light()
    {
        int attack = rnd.Next(1, 2);
        bool trueorfalse = crit();
        if (trueorfalse = true)
        {
            attack = (int)Math.Round(attack * 1.5);
        }
        _energi -= 1;
        return (attack, trueorfalse);
    }
    (int damage, bool crit) medium()
    {
        int attack = rnd.Next(2, 3);
        bool trueorfalse = crit();
        if (trueorfalse = true)
        {
            attack = (int)Math.Round(attack * 1.5);
        }
        _energi -= 2;
        return (attack, trueorfalse);
    }
    (int damage, bool crit) heavy()
    {
        int attack = rnd.Next(3, 4);
        bool trueorfalse = crit();
        if (trueorfalse = true)
        {
            attack = (int)Math.Round(attack * 1.5);
        }
        _energi -= 3;
        return (attack, trueorfalse);
    }
    public int block()
    {
        int blocked = rnd.Next(1, 3);     
        return blocked;
    }

    public bool crit()
    {
        int Crit = rnd.Next(1, 5);
        if (Crit == 1)
        {
            return true;
        }
        return false;
    }
}