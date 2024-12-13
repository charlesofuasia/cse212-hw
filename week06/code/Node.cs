using NuGet.Frameworks;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if (Data == value)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            return true;
        }
        if (value < Data)
        {
            if (Left == null)
            {
                return false;
            }
            else
            {
                return Left.Contains(value);
            }
        }
        else
        {
            if (Right == null)
            {
                return false;
            }
            else
            {
                return Right.Contains(value);
            }
        }


    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int ltHt = 0;
        int rtHt = 0;
        if (Left == null && Right == null)
        {
            return 1;
        }
        else
        {
            if (Left != null)
            {
                ltHt = Left.GetHeight();
            }
            if (Right != null)
            {
                rtHt = Right.GetHeight();
            }
            int height = Math.Max(rtHt, ltHt);
            return height + 1;
        }



    }
}