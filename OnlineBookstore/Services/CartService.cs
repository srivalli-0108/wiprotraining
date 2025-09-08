using System.Text.Json;

public class CartService
{
    private readonly ISession _session;
    private const string CartKey = "CartItems";

    public CartService(IHttpContextAccessor accessor)
    {
        _session = accessor.HttpContext.Session;
    }

    public List<int> GetCartItems() =>
        JsonSerializer.Deserialize<List<int>>(_session.GetString(CartKey) ?? "[]");

    public void AddToCart(int bookId)
    {
        var cart = GetCartItems();
        cart.Add(bookId);
        _session.SetString(CartKey, JsonSerializer.Serialize(cart));
    }

    public void ClearCart() => _session.Remove(CartKey);
}
