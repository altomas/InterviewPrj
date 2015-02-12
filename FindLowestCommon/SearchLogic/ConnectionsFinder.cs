// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectionsFinder.cs" company="Sitecore A/S">
//   Copyright (C) 2010 by Sitecore A/S
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FindLowestCommon.SearchLogic
{
  using System.Collections.Generic;
  using FindLowestCommon.DataStructure;

  /// <summary>
  ///   The connections finder.
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
      //Space O(h) h - deep of tree
      Stack<Node> path1 = GetPath(node1);
      Stack<Node> path2 = GetPath(node2);

      Node commonAncestor = null;

      while (path1.Count > 0 && path2.Count > 0)
      {
        Node point1 = path1.Pop();
        Node point2 = path2.Pop();

        if (point1 != point2)
        {
          return commonAncestor;
        }

        commonAncestor = point1;
      }

      return commonAncestor;
    }

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
    /// The <see cref="BinaryNode"/>.
    /// </returns>
    public static BinaryNode FindLowestCommonAncestorUsingNode(BinaryNode[] underTest, BinaryNode node1, BinaryNode node2)
    {
      //Complexity is O(n); n - amount of nodes 
      //Space O(h) h - deep of tree

      for (int i = 0; i < underTest.Length; i++)
      {
        LinkedList<BinaryNode> firstFoundPath = null;

        var parents = new LinkedList<BinaryNode>();

        BinaryNode node = underTest[i];

        BinaryNode lastVisited = null;

        // No recurcy to maintain deep tree
        // post order traverse 
        while (node != null || parents.Count > 0)
        {
          if (node != null)
          {
            parents.AddLast(node);
            node = node.Left;
          }
          else
          {
            var nodeToProcess = parents.Last.Value;

            if (nodeToProcess.Right != null && nodeToProcess.Right != lastVisited)
            {
              node = nodeToProcess.Right;
            }
            else
            {
              // Process Node
              if (nodeToProcess == node1 || nodeToProcess == node2)
              {
                if (firstFoundPath != null)
                {
                  BinaryNode commonAncestor = null;

                  while (firstFoundPath.Count > 0 && parents.Count > 0)
                  {
                    BinaryNode point1 = firstFoundPath.First.Value;
                    firstFoundPath.RemoveFirst();
                    
                    BinaryNode point2 = parents.First.Value;
                    parents.RemoveFirst();

                    if (point1 != point2)
                    {
                      return commonAncestor;
                    }

                    commonAncestor = point1;
                  }

                  return commonAncestor;
                }

                firstFoundPath = new LinkedList<BinaryNode>(parents);
              }
              
              lastVisited = parents.Last.Value;
              parents.RemoveLast();
            }
          }
        }

        if (firstFoundPath != null)
        {
          // there is no sense to look into others, nodes are not connected. 
          return null;
        }
      }

      return null;
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