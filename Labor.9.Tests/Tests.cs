using Labor._9;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Labor._9.Tests
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public void PostConstructor_Default_SetsDefaults()
        {
            Post post = new Post();
            Assert.AreEqual(0, post.NumViews);
            Assert.AreEqual(0, post.NumComments);
            Assert.AreEqual(0, post.NumReactions);
        }

        [TestMethod]
        public void PostConstructor_WithParams_SetsValues()
        {
            Post post = new Post(100, 10, 5);
            Assert.AreEqual(100, post.NumViews);
            Assert.AreEqual(10, post.NumComments);
            Assert.AreEqual(5, post.NumReactions);
        }

        [TestMethod]
        public void PostConstructor_Copy_CreatesCopy()
        {
            Post original = new Post(50, 2, 1);
            Post copy = new Post(original);
            Assert.AreEqual(50, copy.NumViews);
            Assert.AreEqual(2, copy.NumComments);
            Assert.AreEqual(1, copy.NumReactions);
        }

        [TestMethod]
        public void NumViews_SetNegative_SetsToZero()
        {
            Post post = new Post();
            post.NumViews = -10;
            Assert.AreEqual(0, post.NumViews);
        }

        [TestMethod]
        public void NumComments_SetNegative_SetsToZero()
        {
            Post post = new Post();
            post.NumComments = -5;
            Assert.AreEqual(0, post.NumComments);
        }

        [TestMethod]
        public void NumReactions_SetNegative_SetsToZero()
        {
            Post post = new Post();
            post.NumReactions = -2;
            Assert.AreEqual(0, post.NumReactions);
        }

        [TestMethod]
        public void GetHashCode_EqualPosts_SameHashCodes()
        {
            Post post1 = new Post(100, 10, 5);
            Post post2 = new Post(100, 10, 5);
            Assert.AreEqual(post1.GetHashCode(), post2.GetHashCode());
        }

        [TestMethod]
        public void CalculateEngagementRateStatic_ValidPost_ReturnsCorrectRate()
        {
            Post post = new Post(500, 50, 20);
            double rate = Post.CalculateEngagementRateStatic(post);
            Assert.AreEqual(50, rate);  // 500 / 1000 * 100 = 50
        }

        [TestMethod]
        public void CalculateEngagementRate_ValidPost_ReturnsCorrectRate()
        {
            Post post = new Post(250, 25, 10);
            double rate = post.CalculateEngagementRate();
            Assert.AreEqual(25, rate); // 250 / 1000 * 100 = 25
        }

        [TestMethod]
        public void OperatorNot_IncrementsReactions()
        {
            Post post = new Post(10, 1, 0);
            post = !post;
            Assert.AreEqual(1, post.NumReactions);
        }

        [TestMethod]
        public void OperatorIncrement_IncrementsViews()
        {
            Post post = new Post(5, 0, 0);
            post++;
            Assert.AreEqual(6, post.NumViews);
        }

        [TestMethod]
        public void ExplicitBool_HasCommentsOrReactionsAndViews_ReturnsTrue()
        {
            Post post1 = new Post(10, 1, 0);
            Post post2 = new Post(10, 0, 1);
            Post post3 = new Post(10, 1, 1);

            Assert.IsTrue((bool)post1);
            Assert.IsTrue((bool)post2);
            Assert.IsTrue((bool)post3);
        }

        [TestMethod]
        public void ExplicitBool_NoCommentsNoReactions_ReturnsFalse()
        {
            Post post = new Post(0, 0, 0);
            Assert.IsFalse((bool)post);
        }

        [TestMethod]
        public void ImplicitDouble_ValidPost_ReturnsCorrectRate()
        {
            Post post = new Post(750, 75, 30);
            double rate = (double)post;
            Assert.AreEqual(75, rate); // 750 / 1000 * 100 = 75
        }

        [TestMethod]
        public void OperatorEquals_SameValues_ReturnsTrue()
        {
            Post post1 = new Post(20, 2, 1);
            Post post2 = new Post(20, 2, 1);
            Assert.IsTrue(post1 == post2);
        }

        [TestMethod]
        public void OperatorEquals_DifferentValues_ReturnsFalse()
        {
            Post post1 = new Post(20, 2, 1);
            Post post2 = new Post(21, 2, 1);
            Assert.IsFalse(post1 == post2);
        }

        [TestMethod]
        public void OperatorNotEquals_SameValues_ReturnsFalse()
        {
            Post post1 = new Post(20, 2, 1);
            Post post2 = new Post(20, 2, 1);
            Assert.IsFalse(post1 != post2);
        }

        [TestMethod]
        public void OperatorNotEquals_DifferentValues_ReturnsTrue()
        {
            Post post1 = new Post(20, 2, 1);
            Post post2 = new Post(21, 2, 1);
            Assert.IsTrue(post1 != post2);
        }
    }

    [TestClass]
    public class PostArrayTests
    {
        [TestMethod]
        public void PostArrayConstructor_Default_CreatesEmptyArray()
        {
            PostArray array = new PostArray();
            Assert.AreEqual(0, array.Length);
        }

        [TestMethod]
        public void PostArrayConstructor_WithSize_CreatesArrayOfCorrectSize()
        {
            PostArray array = new PostArray(5);
            Assert.AreEqual(5, array.Length);
        }

        [TestMethod]
        public void PostArrayConstructor_WithExistingArray_CreatesDeepCopy()
        {
            PostArray original = new PostArray(2);
            original[0] = new Post(100, 10, 5);
            original[1] = new Post(200, 20, 10);

            PostArray copy = new PostArray(original);

            Assert.AreEqual(original.Length, copy.Length);
            Assert.AreEqual(original[0].NumViews, copy[0].NumViews);
            Assert.AreEqual(original[1].NumViews, copy[1].NumViews);

            original[0].NumViews = 500;
            Assert.AreNotEqual(original[0].NumViews, copy[0].NumViews);
        }

        [TestMethod]
        public void Indexer_ValidIndex_ReturnsCorrectPost()
        {
            PostArray array = new PostArray(3);
            Post post1 = new Post(100, 10, 5);
            array[1] = post1;
            Assert.AreEqual(100, array[1].NumViews);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_InvalidIndex_ThrowsException()
        {
            PostArray array = new PostArray(2);
            Post post = array[5]; 
        }

        [TestMethod]
        public void CalculateTotalEngagementRate_EmptyArray_ReturnsZero()
        {
            PostArray array = new PostArray();
            double rate = array.CalculateTotalEngagementRate();
            Assert.AreEqual(0, rate);
        }

        [TestMethod]
        public void CalculateTotalEngagementRate_ValidArray_ReturnsCorrectRate()
        {
            PostArray array = new PostArray(2);
            array[0] = new Post(200, 20, 10);
            array[1] = new Post(300, 30, 15);

            double rate = array.CalculateTotalEngagementRate();
            Assert.AreEqual(25, rate);  // (20 + 30) / 2 = 25
        }
    }
}
