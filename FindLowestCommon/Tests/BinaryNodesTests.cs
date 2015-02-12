// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tests.cs" company="Sitecore A/S">
//   Copyright (C) 2010 by Sitecore A/S
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FindLowestCommon
{
  using System.Collections.Generic;
  using System.Linq;
  using FindLowestCommon.DataStructure;
  using FindLowestCommon.SearchLogic;
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

      this.Nodes.Add("f", new BinaryNode("f",this.Nodes["g"], null));

      this.Nodes.Add("z", new BinaryNode("z"));

      this.Nodes.Add("d", new BinaryNode("d",this.Nodes["z"], null));

      this.Nodes.Add("c", new BinaryNode("c",null, this.Nodes["f"]));

      this.Nodes.Add("e", new BinaryNode("e"));


      this.Nodes.Add("b", new BinaryNode("b",this.Nodes["e"], this.Nodes["d"]));

      this.Nodes.Add("a", new BinaryNode("a",this.Nodes["b"], this.Nodes["c"]));


      this.Nodes.Add("i", new BinaryNode("i"));
      this.Nodes.Add("k", new BinaryNode("k"));
      this.Nodes.Add("h", new BinaryNode("h",this.Nodes["i"], this.Nodes["k"]));

    }

    /// <summary>
    /// The test.
    /// </summary>
    [Test]
    [TestCase(new[] { "a", "h" }, "b", "c", "a")]
    [TestCase(new[] { "a", "h" }, "a", "h", null)]
    [TestCase(new[] { "a", "h" }, "f", "g", "f")]
    [TestCase(new[] { "a", "h" }, "z", "e", "b")]
    [TestCase(new[] { "a", "h" }, "e", "d", "b")]
    [TestCase(new[] { "a", "h" }, "d", "i", null)]
    public void Test(string[] binaryNodesArray, string BinaryNode1, string BinaryNode2, string resultNode)
    {
      BinaryNode[] underTest = binaryNodesArray.Select(i => this.Nodes[i]).ToArray();

      BinaryNode result = ConnectionsFinder.FindLowestCommonAncestorUsingNode(underTest, this.Nodes[BinaryNode1], this.Nodes[BinaryNode2]);

      if (resultNode == null)
      {
        Assert.AreEqual(null, result);
        return;
      }

      Assert.AreEqual(this.Nodes[resultNode], result);
    }



  }
}