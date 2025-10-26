namespace Spil;

public class Player
{
    //laver en variabel ved navn liv inde for objektet Player
    private int _liv = 20;

    public int Liv
    {
        get { return this._liv; }
        set { this._liv = value; }
    }

    //laver en variabel ved navn energi inde for objektet Player
    private int _energi = 10;

    public int Energi
    {
        get { return this._energi; }
        set { this._energi = value; }
    }

    //laver en rnd som vil give mig muligheden for at bruge en random number generator inde for mine metoder
    Random rnd = new Random();

    //laver en metode ved navn light som er et angreb for playeren
    public (int damage, bool crit) light()
    {
        int attack = rnd.Next(1, 2);

        //kalder frem metoden crit og tjekker om metoden giver værdien true
        bool trueorfalse = crit();
        if (trueorfalse = true)
        {
            attack = (int)Math.Round(attack * 1.5);
        }

        _energi -= 1;

        //returner værdien for attack samt også om crit var true eller false for at kunne skrive det i konsolen tilbage i program.cs
        return (attack, trueorfalse);
    }

    public (int damage, bool crit) medium()
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

    public (int damage, bool crit) heavy()
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

    //metode ved navn block som er WIP
    public int block()
    {
        int blocked = rnd.Next(1, 3);
        _energi--;
        return blocked;
        
    }
    public void rest()
    {
        int energi = rnd.Next(1, 3);
        _energi += energi;
    }
    public bool crit()
    {
        //tager et tal mellem 1 og 4 og hvis tallet er 1 vil den retunere true hvis ikke giver den false
        int Crit = rnd.Next(1, 5);
        if (Crit == 1)
        {
            return true;
        }

        return false;
    }
}