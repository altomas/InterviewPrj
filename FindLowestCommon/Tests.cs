// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tests.cs" company="Sitecore A/S">
//   Copyright (C) 2010 by Sitecore A/S
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FindLowestCommon
{
  using System.Collections.Generic;
  using FindLowestCommon.DataStructure;
  using NUnit.Framework;

  /// <summary>
  /// The tests.
  /// </summary>
  [TestFixture]
  public class Tests
  {
    /// <summary>
    /// Gets or sets the node_ a.
    /// </summary>
    public Node Node_A { get; set; }

    /// <summary>
    /// Gets or sets the node_ b.
    /// </summary>
    public Node Node_B { get; set; }

    /// <summary>
    /// Gets or sets the node_ d.
    /// </summary>
    public Node Node_D { get; set; }

    /// <summary>
    /// Gets or sets the node_ z.
    /// </summary>
    public Node Node_Z { get; set; }

    /// <summary>
    /// Gets or sets the node_ c.
    /// </summary>
    public Node Node_C { get; set; }

    /// <summary>
    /// Gets or sets the node_ e.
    /// </summary>
    public Node Node_E { get; set; }

    /// <summary>
    /// Gets or sets the node_ f.
    /// </summary>
    public Node Node_F { get; set; }

    /// <summary>
    /// Gets or sets the node_ g.
    /// </summary>
    public Node Node_G { get; set; }

    /// <summary>
    /// Gets or sets the node_ i.
    /// </summary>
    public Node Node_I { get; set; }

    /// <summary>
    /// Gets or sets the node_ k.
    /// </summary>
    public Node Node_K { get; set; }

    /// <summary>
    /// Gets or sets the node_ h.
    /// </summary>
    public Node Node_H { get; set; }

    /// <summary>
    /// The get under test value.
    /// </summary>
    [TestFixtureSetUp]
    public void GetUnderTestValue()
    {

      //      For the following trees:
      //             a                     |                h      
      //        /        \                 |             /     \
      //       b          c                |           i        k         
      //     /   \          \              |
      //    d     e          f             |
      //   /                /              |
      //  z                g               | 

      this.Node_G = new Node();

      this.Node_F = new Node(this.Node_G, null);

      this.Node_Z = new Node();

      this.Node_D = new Node(this.Node_Z, null);

      this.Node_C = new Node(null, this.Node_F);

      this.Node_E = new Node();

      this.Node_B = new Node(this.Node_E, this.Node_D);

      this.Node_A = new Node(this.Node_B, this.Node_C);


      this.Node_I = new Node();
      this.Node_K = new Node();
      this.Node_H = new Node(this.Node_I, this.Node_K);
    }

    /// <summary>
    /// The test.
    /// </summary>
    [Test]

    // For rootNodes[a, h], firstNode=b , secondNode=c  =>  a
    public void Test()
    {
      var underTest = new[]
      {
        this.Node_A, this.Node_H
      };

      Node result = ConnectionsFinder.FindLowestCommonAncestorUsingNode(underTest, this.Node_B, this.Node_C);

      Assert.AreEqual(this.Node_A, result);
    }
  }

  /// <summary>
  /// The connections finder.
  /// </summary>
  public static class ConnectionsFinder
  {
    #region Public methods

    /// <summary>
    /// The find lowest common ancestor using node.
    /// </summary>
    /// <param name="underTest">
    /// The under test.
    /// </param>
    /// <param name="node1">
    /// The node 1.
    /// </param>
    /// <param name="node2">
    /// The node 2.
    /// </param>
    /// <returns>
    /// The <see cref="Node"/>.
    /// </returns>
    public static Node FindLowestCommonAncestorUsingNode(Node[] underTest, Node node1, Node node2)
    {
      // Complexity O(h) where h - deep of tree 
      Stack<Node> path1 = GetPath(node1);
      Stack<Node> path2 = GetPath(node2);

      Node commonAncestor = null;

      while (path1.Count > 0 && path2.Count > 0)
      {
        Node point1 = path1.Pop();
        Node point2 = path2.Pop();

        if (point1 == point2)
        {
          commonAncestor = point1;
        }
      }

      return commonAncestor;
    }

    #endregion

    #region Private methods

    /// <summary>
    /// The get path.
    /// </summary>
    /// <param name="node1">
    /// The node 1.
    /// </param>
    /// <returns>
    /// The <see cref="Stack"/>.
    /// </returns>
    private static Stack<Node> GetPath(Node node1)
    {
      var path = new Stack<Node>();

      Node upperNode = node1;

      while (upperNode != null)
      {
        path.Push(upperNode);
        upperNode = upperNode.Parent;
      }

      return path;
    }

    #endregion
  }
}