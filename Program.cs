

public struct Tuple
{
    private int low;
    private int high;
    private int sum;

    public Tuple(int low, int high, int sum)
    {
        this.low = low;
        this.high = high;
        this.sum = sum;
    }

    public int getLow()
    {
        return this.low;
    }

    public int getHigh()
    {
        return this.high;
    }

    public int getSum()
    {
        return this.sum;
    }

    public void write()
    {
        Console.WriteLine("Low: " + this.low);
        Console.WriteLine("High: " + this.high);
        Console.WriteLine("Sum: " + this.sum);

    }
}



public static class Program
{

    public static Tuple findMaxCrossingSubarray(int[] A, int low, int mid, int high)
    {
        int left_sum = Int32.MinValue;
        int right_sum = Int32.MinValue;
        int sum = 0;
        int max_left = 0;
        int max_right = 0;

        for (int i = mid; i > low; i--)
        {
            sum = sum + A[i];
            if(sum > left_sum)
            {
                left_sum = sum;
                max_left = i;
            }
        }

        sum = 0;

        for(int j = mid + 1; j < high; j++)
        {
            sum = sum + A[j];
            if (sum > right_sum)
            {
                right_sum = sum;
                max_right = j;
            }
        }


        return new Tuple(max_left, max_right, left_sum + right_sum);
    }

    public static Tuple findMaxCrossingSubarray(int[] A, int low, int high)
    {
        int mid = 0;
        Tuple left;
        Tuple right;
        Tuple cross;

        if(high == low)
        {
            return new Tuple(low, high, A[low]);
        }
        else
        {
            mid = (int) Math.Floor(Convert.ToDouble((low + high) / 2));

            left = findMaxCrossingSubarray(A, low, mid);
            right = findMaxCrossingSubarray(A, mid + 1, high);
            cross = findMaxCrossingSubarray(A, low, mid, high);

            if(left.getSum() >= right.getSum() && left.getSum() >= cross.getSum())
            {
                return left;
            }
            else if(right.getSum() >= left.getSum() && right.getSum() >= cross.getSum())
            {
                return right;
            }
            else
            {
                return cross;
            }
        }
    }

    static void Main(string[] args)
    {
        int[] A = { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };

        Tuple result = Program.findMaxCrossingSubarray(A, 0, 15);

        result.write();

    }

}


