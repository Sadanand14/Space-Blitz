using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Score : System.IComparable<Score>
{
    public string name1;
    public string score;
    public int minute;
    public int second;
    public int millisecond;
    public Score(string n, string s, int m, int sec, int millesec) { name1 = n; score = s; minute = m; second = sec; millisecond = millesec; }
    public int CompareTo(Score other)
    {
        if (other == null)
            return 0;
        int value = (other.minute * 100000 + other.second * 1000 + other.millisecond )- (this.minute * 100000 + this.second * 1000 + this.millisecond );
        return -value;
    }
    public override string ToString()//debug用
    {
        return name1 + " : " + score.ToString();
    }
}
