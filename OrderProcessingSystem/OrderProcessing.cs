namespace OrderProcessingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderItem
    {
        public string ProductName { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        public OrderItem(string productName, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Product name is required.");

            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }

        public decimal GetTotal() => Price * Quantity;
    }

    public class OrderProcessor
    {
        private readonly List<OrderItem> _items = new();

        public bool IsPremiumCustomer { get; }
        public bool IsProcessed { get; private set; }

        public OrderProcessor(bool isPremiumCustomer)
        {
            IsPremiumCustomer = isPremiumCustomer;
        }

        public void AddItem(OrderItem item)
        {
            if (IsProcessed)
                throw new InvalidOperationException("Cannot add items after order is processed.");

            _items.Add(item);
        }

        public decimal CalculateSubtotal()
        {
            return _items.Sum(i => i.GetTotal());
        }

        public decimal CalculateDiscount()
        {
            var subtotal = CalculateSubtotal();

            decimal discount = 0;

            // Premium customers get 10%
            if (IsPremiumCustomer)
                discount += subtotal * 0.10m;

            // Bulk discount
            if (subtotal > 10000)
                discount += subtotal * 0.05m;

            return discount;
        }

        public decimal CalculateTax()
        {
            var taxableAmount = CalculateSubtotal() - CalculateDiscount();
            return taxableAmount * 0.18m; // 18% GST
        }

        public decimal CalculateFinalAmount()
        {
            var subtotal = CalculateSubtotal();

            if (subtotal == 0)
                throw new InvalidOperationException("Order must contain at least one item.");

            var discount = CalculateDiscount();
            var tax = CalculateTax();

            return subtotal - discount + tax;
        }

        public void ProcessOrder()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Cannot process empty order.");

            IsProcessed = true;
        }
    }
}

