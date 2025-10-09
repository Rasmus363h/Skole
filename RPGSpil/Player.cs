namespace RPGSpil;

public class Player
{
    private int _liv;
    public int Liv                        
    {                                     
        get { return this._liv; }         
        set { this._liv = value; }        
    }                                     
    private int _energi;
    public int Energi
    {
        get { return this._energi; }
        set { this._energi = value; }
    }
    
    Random rnd = new Random();     
    public int light()
    {
        int attack = rnd.Next(2, 3);
        bool trueorfalse = crit();
        if (trueorfalse = true)
        {
           // attack = Convert.ToDouble(attack) * 1.33);
        }
        return 1;
    }
    public int medium()
    {
        int attack = rnd.Next(1, 3);     
        return 1;
    }                       
    public int heavy()
    {
        int attack = rnd.Next(1, 3);     
        return 1;
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