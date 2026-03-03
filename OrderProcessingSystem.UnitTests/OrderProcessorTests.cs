namespace OrderProcessingSystem.UnitTests
{

    [TestFixture]
    public class OrderProcessorTests
    {
        #region OrderItem Constructor Tests

        [Test]
        public void OrderItem_InvalidName_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() =>
                new OrderItem("", 100, 1));
        }

        [Test]
        public void OrderItem_InvalidPrice_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() =>
                new OrderItem("Item", 0, 1));
        }

        [Test]
        public void OrderItem_InvalidQuantity_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() =>
                new OrderItem("Item", 100, 0));
        }

        #endregion

        #region Subtotal

        [Test]
        public void CalculateSubtotal_ShouldReturnCorrectValue()
        {
            var processor = new OrderProcessor(false);
            processor.AddItem(new OrderItem("A", 100, 2));


            Assert.That(processor.CalculateSubtotal(), Is.EqualTo(200));

        }

        #endregion

        #region Discount Logic

        [Test]
        public void PremiumCustomer_ShouldGet10PercentDiscount()
        {
            var processor = new OrderProcessor(true);
            processor.AddItem(new OrderItem("A", 1000, 1));

            Assert.That(processor.CalculateDiscount(), Is.EqualTo(100));
        }

        [Test]
        public void BulkOrder_ShouldGet5PercentDiscount()
        {
            var processor = new OrderProcessor(false);
            processor.AddItem(new OrderItem("A", 11000, 1));

            Assert.That(processor.CalculateDiscount(), Is.EqualTo(550));
        }

        [Test]
        public void PremiumAndBulk_ShouldCombineDiscounts()
        {
            var processor = new OrderProcessor(true);
            processor.AddItem(new OrderItem("A", 20000, 1));

            var expected = 20000 * 0.10m + 20000 * 0.05m;
            Assert.That(processor.CalculateDiscount(), Is.EqualTo(expected));
        }

        #endregion

        #region Tax

        [Test]
        public void CalculateTax_ShouldApply18PercentAfterDiscount()
        {
            var processor = new OrderProcessor(true);
            processor.AddItem(new OrderItem("A", 1000, 1));

            var discount = 100; // 10%
            var taxable = 900;
            var expectedTax = taxable * 0.18m;

            Assert.That(processor.CalculateTax(), Is.EqualTo(expectedTax));
        }

        #endregion

        #region Final Amount

        [Test]
        public void CalculateFinalAmount_ShouldReturnCorrectValue()
        {
            var processor = new OrderProcessor(true);
            processor.AddItem(new OrderItem("A", 1000, 1));

            var subtotal = 1000;
            var discount = 100;
            var tax = (subtotal - discount) * 0.18m;

            var expected = subtotal - discount + tax;

            Assert.That(processor.CalculateFinalAmount(), Is.EqualTo(expected));
        }

        [Test]
        public void CalculateFinalAmount_EmptyOrder_ShouldThrow()
        {
            var processor = new OrderProcessor(false);

            Assert.Throws<InvalidOperationException>(() =>
                processor.CalculateFinalAmount());
        }

        #endregion

        #region ProcessOrder

        [Test]
        public void ProcessOrder_ShouldSetIsProcessedTrue()
        {
            var processor = new OrderProcessor(false);
            processor.AddItem(new OrderItem("A", 100, 1));

            processor.ProcessOrder();

            Assert.That(processor.IsProcessed, Is.True);
        }

        [Test]
        public void ProcessOrder_EmptyOrder_ShouldThrow()
        {
            var processor = new OrderProcessor(false);

            Assert.Throws<InvalidOperationException>(() =>
                processor.ProcessOrder());
        }

        [Test]
        public void AddItem_AfterProcess_ShouldThrow()
        {
            var processor = new OrderProcessor(false);
            processor.AddItem(new OrderItem("A", 100, 1));
            processor.ProcessOrder();

            Assert.Throws<InvalidOperationException>(() =>
                processor.AddItem(new OrderItem("B", 200, 1)));
        }

        #endregion
    }
}
