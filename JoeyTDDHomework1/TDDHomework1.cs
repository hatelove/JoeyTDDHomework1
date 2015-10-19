using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace JoeyTDDHomework1
{
    /// <summary>
    /// 介面
    /// </summary>
    public interface INumberSumHandler
    {
        int[] add(int[] costArray, int groupSize);
    }

    /// <summary>
    ///  假的測試實作
    /// </summary>
    public class StubNumberSumHandler : INumberSumHandler
    {
        public int[] add(int[] costArray, int groupSize)
        {
            if (groupSize == 3)
            {
                return new int[] { 6, 15, 24, 21 };
            }
            else if (groupSize == 4)
            {
                return new int[] { 50, 66, 60 };
            }
            return new int[] { };
        }
    }

    /// <summary>
    /// 主要測試
    /// </summary>
    [TestClass]
    public class TDDHomework1
    {
        ///<summary>
        ///給予資料 {1,2,3,4,5,6,7,8,9,10,11}
        ///3筆一組，取Cost總和
        ///Result : 6,15,24,21
        /// </summary>
        [TestMethod]
        public void Test_Cost_sum_result_with_3_elements()
        {
            //todo by joey, 需求上的 domain model 是 product, 而不是只有一串 cost 的資料，所以這樣的測試案例無法表達出 product 有哪些東西，需要再調整
            //arrange
            int[] costArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int groupSize = 3;
            int[] expected = { 6, 15, 24, 21 };
            //todo by joey, 測試目標不需要用interface的宣告，在測試程式中，不會測試interface, 因為很明確的就是要測試我們的sut
            INumberSumHandler target = new StubNumberSumHandler();

            //Act
            //todo by joey, 同上面描述，我需要針對 product, 只 sum Cost 的 資料，這是需求的context。
            int[] actual = target.add(costArray, groupSize);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        ///<summary>
        ///給予資料 {1,2,3,4,5,6,7,8,9,10,11}
        ///3筆一組，取Cost總和
        ///Result : 6,15,24,21
        ///用 NSutb套件
        /// </summary>
        [TestMethod]
        public void Test_Cost_sum_result_with_3_elements_using_NSub()
        {
            //Arrange
            int[] costArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int groupSize = 3;
            int[] expected = { 6, 15, 24, 21 };
            
            //todo by joey, target 不會是用mock framework產生的動態instance, 
            INumberSumHandler target = Substitute.For<INumberSumHandler>();

            //Act & Assert
            //todo by joey, 這裡沒有任何assertion
            target.add(costArray, groupSize).Returns(expected);
        }

        /// <summary>
        /// 4筆一組，取Revenue總和
        /// 給予資料{ 11,12,13,14,15,16,17,18,19,20,21}
        /// Result {50,66,60}
        /// </summary>
        [TestMethod]
        public void Test_Revenue_sum_result_with_4_elements()
        {
            //todo by joey, 同上一個test case建議
            //Arrange
            int[] costArray = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };
            int groupSize = 4;
            int[] expected = { 50, 66, 60 };
            INumberSumHandler target = new StubNumberSumHandler();

            //Act
            int[] actual = target.add(costArray, groupSize);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 4筆一組，取Revenue總和
        /// 給予資料{ 11,12,13,14,15,16,17,18,19,20,21}
        /// Result {50,66,60}
        /// 用 NSutb套件
        /// </summary>
        [TestMethod]
        public void Test_Revenue_sum_result_with_4_elements_using_NSub()
        {
            //todo by joey, 同上一個test case建議
            
            //Arrange
            int[] costArray = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };
            int groupSize = 4;
            int[] expected = { 50, 66, 60 };
            INumberSumHandler target = Substitute.For<INumberSumHandler>();

            //Act & Assert
            target.add(costArray, groupSize).Returns(expected);
        }
    }
}
