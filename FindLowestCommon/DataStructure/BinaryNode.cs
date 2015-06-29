using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindLowestCommon.DataStructure
{
  public class BinaryNode
  {
    public BinaryNode Left;
    public BinaryNode Right;
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
      // TODO: Complete member initialization
      this.Data = p;
    }
  }
}
