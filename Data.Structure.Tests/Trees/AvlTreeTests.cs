using System;
using Data.Structure.Trees;
using Xunit;

namespace Data.Structure.Tests
{
    public class AvlTreeTests
    {
        private readonly AvlTree avlTree;

        public AvlTreeTests()
        {
            avlTree = new AvlTree();
        }

        [Fact]
        public void AvlTree_ShouldHave_InsertMethod() => avlTree.Insert(10);


        [Fact]
        public void AvlTree_AfterInsertRoot_ShouldHaveSameRoot()

        {
            avlTree.Insert(10);

            Assert.Equal(10, avlTree.Root.Value);
        }

        [Fact]
        public void AvlTree_AfterInsertRoot_InsertLeft_ShouldHaveSameValue()
        {
            avlTree.Insert(10);
            avlTree.Insert(5);

            Assert.Equal(5, avlTree.Root.Left.Value);
        }

        [Fact]
        public void AvlTree_AfterInsertRoot_InsertRight_ShouldHaveSameValue()
        {
            avlTree.Insert(10);
            avlTree.Insert(20);

            Assert.Equal(10, avlTree.Root.Left.Value);
        }

        [Fact]
        public void AvlTree_Root_ShouldHave_CorrectBalanceFactor_InRightSkewedTree()
        {
            avlTree.Insert(10);
            avlTree.Insert(20);
            avlTree.Insert(30);
            avlTree.Insert(40);

            Assert.True(avlTree.Root.Height >= 2);
        }

        [Fact]
        public void AvlTree_Root_ShouldHave_CorrectBalanceFactor_InLeftSkewedTree()
        {
            avlTree.Insert(40);
            avlTree.Insert(30);
            avlTree.Insert(20);
            avlTree.Insert(10);

            Assert.True(avlTree.Root.Left.Height - (avlTree.Root.Right?.Height ?? 0) > 0);
        }


        [Fact]
        public void AvlTree_ShouldBalance_RightSkewedTree()
        {
            avlTree.Insert(10);
            avlTree.Insert(20);
            avlTree.Insert(30);

            Assert.Equal(30, avlTree.Root.Value);
        }


        [Fact]
        public void AvlTree_ShouldBalance_LeftSkewedTree()
        {
            avlTree.Insert(30);
            avlTree.Insert(20);
            avlTree.Insert(10);

            Assert.Equal(20, avlTree.Root.Value);
        }


        [Fact]
        public void AvlTree_ShouldBalance_RightLeftTree()
        {
            // 10
            //   30
            //  20
            avlTree.Insert(10);
            avlTree.Insert(30);
            avlTree.Insert(20);

            Assert.Equal(20, avlTree.Root.Value);
        }

        [Fact]
        public void AvlTree_ShouldBalance_LeftRightTree()
        {
            //   30
            // 10
            //   20
            avlTree.Insert(10);
            avlTree.Insert(30);
            avlTree.Insert(20);

            Assert.Equal(20, avlTree.Root.Value);
        }
    }
}