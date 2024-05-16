namespace Store.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_WithZeroCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = 0;
                new OrderItem(1, count, 0m);
            });
        }
        [Fact]
        public void OrderItem_WithNegativeCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = -1;
                new OrderItem(1, count, 0m);
            });
        }
        [Fact]
        public void OrderItem_WithPosetiveCount_SetsCount()
        {

            var ordetItem = new OrderItem(1, 2, 3m);
            Assert.Equal(1, ordetItem.BookId);
            Assert.Equal(2, ordetItem.Count);
            Assert.Equal(3m, ordetItem.Price);


        }
    }
}
