using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PowerCollections.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Constructor_create_stack_with_zero_count_and_requested_capacity()
        {
            Stack<int> stack = new Stack<int>(1);
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(1, stack.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),"Param bad format.Stack size must not be less than or equal to 0")]
        public void Constructor_CheckingForAnExceptionWithConstructorCreateStackWithSizeIsZero()
        {
            Stack<int> stack = new Stack<int>(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Param bad format.Stack size must not be less than or equal to 0")]
        public void Constructor_CheckingForAnExceptionWithConstructorCreateStackWithSizeIsLessThanZero()
        {
            Stack<int> stack = new Stack<int>(-1);
        }

        [TestMethod]
        public void Push_ItemInStackСheckingThatTopItemEqualsTheAddedValueAndCountIsEqualToOne()
        {
            Stack<int> stack = new Stack<int>(1);
            stack.Push(1);
            Assert.AreEqual(1, stack.Top());
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),"Overflow stack")]
        public void Push_ExceptionMessageIfPushItemsGreaterThanSizeStack()
        {
            Stack<string> stack = new Stack<string>(2);
            stack.Push("test");
            stack.Push("test");
            stack.Push("test");
;
        }

        [TestMethod]
        public void Pop_ItemInStackСheckingThatPopItemEqualsTheAddedValueAndCountIsEqualToZero()
        {
            Stack<int> stack = new Stack<int>(1);
            stack.Push(1);
            Assert.AreEqual(1, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Stack is empty")]
        public void Pop_ExceptionMessagePopItemIfStackIsEmpty()
        {
            Stack<string> stack = new Stack<string>(2);
            stack.Pop();
        }

        [TestMethod]
        public void Top_ItemInStackCheckingThatTopItemEqualsTheAddedValue()
        {
            Stack<int> stack = new Stack<int>(1);
            stack.Push(1);
            Assert.AreEqual(1, stack.Top());
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Stack is empty")]
        public void Top_ExceptionMessagePopItemIfStackIsEmpty()
        {
            Stack<string> stack = new Stack<string>(2);
            stack.Top();
        }

        [TestMethod]
        public void Enumerator_GetEnumeratorFromStackIsEmpty()
        {
            Stack<int> stack = new Stack<int>(2);
            IEnumerator enumerator = stack.GetEnumerator();
            Assert.AreEqual(false,enumerator.MoveNext());
            Assert.AreEqual(0, enumerator.Current);
        }
        [TestMethod]
        public void Enumerator_GetEnumeratorFromStackIsNotEmpty()
        {
            Stack<int> stack = new Stack<int>(1);
            IEnumerator enumerator = stack.GetEnumerator();
            stack.Push(1);
            enumerator.MoveNext();
            Assert.AreEqual(false, enumerator.MoveNext());
        }
        [TestMethod]
        public void Enumerator_GetEnumeratorGoFromTopToBottom()
        {
            Stack<int> stack = new Stack<int>(3);
            IEnumerator enumerator = stack.GetEnumerator();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            enumerator.MoveNext();
            Assert.AreEqual(3, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(2, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(1, enumerator.Current);
        }
    }
}
