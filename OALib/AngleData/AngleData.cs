namespace OALib.AngleData;

public class AngleData
{
    
    public static float AngleUniformity(float angle)
    {
        float result = angle;
        if (result > 360 || result < -360)
        {
            result = angle % 360;
        }
        if (result < 0)
        {
            result += 360;
        }
        return result;
    }

    public static float[] CalculateAngleData(float[] angleData)
    {
        int a = 0;
        float[] result = new float[angleData.Length];
        while (a < angleData.Length)
        {
            int midspin = 0;
            //是否为中旋
            if (angleData[a] == 999)
            { 
                result[a] = 0;
            }
            //判断前几个为中旋
            else
            {
                while (a - 1 - midspin >= 0 && angleData[a - 1 - midspin] == 999)
                    midspin += 1;
                if (a - 1 - midspin < 0)
                {
                    result[a] = 180 - angleData[a];
                }
                else
                {
                    result[a] = angleData[a - 1 - midspin] - angleData[a];
                    if (midspin % 2 == 0)
                    {
                        result[a] += 180;
                    }
                }
            }
            result[a] = AngleUniformity(result[a]);
            a += 1;
        }
        return result;
    }
}