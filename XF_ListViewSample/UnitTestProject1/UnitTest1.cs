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

            //Initialize
            model.Items.Clear();
            // 0である
            Assert.AreEqual(0, model.Items.Count);

            // Add Item
            model.AddItem();
            // 1である
            Assert.AreEqual(0, model.Items.Count);
        }
    }
}
