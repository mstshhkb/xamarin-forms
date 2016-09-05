using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CheckItemCount
    {
        [TestMethod]
        public void TestMethod1()
        {
            var model = XF_ListViewSample.Models.Ramen.Instance;

            //InitializeするとItem_1が追加されるので初期状態で1
            model.Initialize();
            // 1である
            Assert.AreEqual(1, model.Items.Count);

            // Add Item
            model.AddItem();
            // 2である
            Assert.AreEqual(2, model.Items.Count);
        }
    }
}
