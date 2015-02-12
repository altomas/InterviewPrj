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
  public class Tests
  {

    Dictionary<string, Node> Nodes = new Dictionary<string, Node>();

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

      this.Nodes.Add("g", new Node());

      this.Nodes.Add("f", new Node(this.Nodes["g"], null));

      this.Nodes.Add("z", new Node());

      this.Nodes.Add("d", new Node(this.Nodes["z"], null));

      this.Nodes.Add("c", new Node(null, this.Nodes["f"]));

      this.Nodes.Add("e", new Node());


      this.Nodes.Add("b", new Node(this.Nodes["e"], this.Nodes["d"]));

      this.Nodes.Add("a", new Node(this.Nodes["b"], this.Nodes["c"]));


      this.Nodes.Add("i", new Node());
      this.Nodes.Add("k", new Node());
      this.Nodes.Add("h", new Node(this.Nodes["i"], this.Nodes["k"]));

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
    public void Test(string[] nodesArray, string node1, string node2, string resultNode)
    {
      Node[] underTest = nodesArray.Select(i => this.Nodes[i]).ToArray();

      Node result = ConnectionsFinder.FindLowestCommonAncestorUsingNode(underTest, this.Nodes[node1], this.Nodes[node2]);

      if (resultNode == null)
      {
        Assert.AreEqual(null, result);
        return;
      }

      Assert.AreEqual(this.Nodes[resultNode], result);
    }



  }
}