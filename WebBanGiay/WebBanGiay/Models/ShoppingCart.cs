namespace WebBanGiay.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddToCart(SanPham product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.MaSanPham == product.MaSanPham);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        public void RemoveFromCart(string productId)
        {
            var item = Items.FirstOrDefault(i => i.Product.MaSanPham == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }
        // Cập nhật số lượng của sản phẩm trong giỏ hàng
        public void UpdateQuantity(string productId, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.Product.MaSanPham == productId);
            if (item != null)
            {
                // Nếu số lượng > 0, cập nhật số lượng
                if (quantity > 0)
                {
                    item.Quantity = quantity;
                }
                // Nếu số lượng <= 0, xóa sản phẩm khỏi giỏ hàng
                else
                {
                    Items.Remove(item);
                }
            }
        }
        public decimal TotalPrice()
        {
            return Items.Sum(i => i.Product.GiaBan.Value * i.Quantity);
        }
    }

    public class CartItem
    {
        public SanPham Product { get; set; }
        public int Quantity { get; set; }
    }
}
