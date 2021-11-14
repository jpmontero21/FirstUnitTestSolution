using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Tests
{
    [TestFixture]
    public class MyStackTests
    {
        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            var stack = new MyStack<int>();
            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        public void Count_PushOne_RerurnsOne()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty);
        }

        [Test]
        public void Pop_EmptyStack_Exception()
        {
            var stack = new MyStack<int>();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Peek_PushTwoItems_ReturnsHeadItem()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);

            Assert.AreEqual(2, stack.Peek());
        }

        [Test]
        public void Peek_PushTwoItemsAndPop_ReturnsHeadElement()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            Assert.AreEqual(1, stack.Peek());
        }
    }
}
