using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindLowestCommon.DataStructure
{
  public class Node
  {
    public Node Left;
    public Node Right;
    public Node Parent;

    public Node(Node left, Node right)
    {
      if (left != null)
      {
        this.Left = left;
        this.Left.Parent = this;
      }

      if (right != null)
      {
        this.Right = right;
        this.Right.Parent = this;
      }
    }

    public Node()
    {
    }
  }
}
