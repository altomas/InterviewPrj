// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tests.cs" company="Sitecore A/S">
//   Copyright (C) 2010 by Sitecore A/S
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HorizontalLinks.Tests
{
  using System.Collections.Generic;
  using HorizontalLinks.DataStructure;
  using NUnit.Framework;

  /// <summary>
  /// The tests.
  /// </summary>
  [TestFixture]
  public class BinaryBinaryNodesTests
  {
    Dictionary<string, BinaryNode> Nodes = new Dictionary<string, BinaryNode>();

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

      this.Nodes.Add("g", new BinaryNode("g"));

      this.Nodes.Add("f", new BinaryNode("f", this.Nodes["g"], null));

      this.Nodes.Add("z", new BinaryNode("z"));

      this.Nodes.Add("d", new BinaryNode("d", this.Nodes["z"], null));

      this.Nodes.Add("c", new BinaryNode("c", null, this.Nodes["f"]));

      this.Nodes.Add("e", new BinaryNode("e"));


      this.Nodes.Add("b", new BinaryNode("b", this.Nodes["d"], this.Nodes["e"]));

      this.Nodes.Add("a", new BinaryNode("a", this.Nodes["b"], this.Nodes["c"]));
    }

    /// <summary>
    /// The test.
    /// </summary>
    [Test]
    [TestCase("b", "c")]
    [TestCase("d", "e")]
    [TestCase("z", "g")]
    [TestCase("f", null)]
    public void Test(string binaryNode, string expectedNode)
    {
      var underTest = this.Nodes["a"];

      ConnectionsFinder.SetLinks(underTest);

      var result = this.Nodes[binaryNode].Neighbor;

      if (expectedNode == null)
      {
        Assert.AreEqual(null, result);
        return;
      }

      Assert.AreEqual(this.Nodes[expectedNode], result);
    }

  }

  public class ConnectionsFinder
  {
    internal static void SetLinks(BinaryNode rootNode)
    {

      if (rootNode == null)
      {
        return;
      }

      Queue<BinaryNode> processing = new Queue<BinaryNode>();

      processing.Enqueue(rootNode);

      while (processing.Count > 0)
      {
        var tempStack = processing;

        processing = new Queue<BinaryNode>(tempStack.Count * 2);

        BinaryNode previous = null;

        while (tempStack.Count > 0)
        {
          var node = tempStack.Dequeue();

          if (node.Left != null)
          {
            processing.Enqueue(node.Left);
          }

          if (node.Right != null)
          {
            processing.Enqueue(node.Right);
          }

          if (previous != null)
          {
            previous.Neighbor = node;
          }

          previous = node;
        }
      }
    }
  }
}