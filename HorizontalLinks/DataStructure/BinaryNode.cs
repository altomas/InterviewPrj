namespace HorizontalLinks.DataStructure
{
  public class BinaryNode
  {
    public BinaryNode Left;
    public BinaryNode Right;
    public BinaryNode Neighbor;
    public string Data;

    public BinaryNode(string data, BinaryNode left, BinaryNode right): this(data)
    {
      this.Left = left;
      this.Right = right;
    }

    public BinaryNode()
    {
    }

    public BinaryNode(string p)
    {
      this.Data = p;
    }
  }
}
