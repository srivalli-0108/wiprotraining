
db.products.insertMany([
  {
    name: "Samsung Galaxy S21",
    category: "Electronics",
    price: 699.99,
    stock: 120,
    specs: {
      color: "Phantom Gray",
      memory: "128GB",
      battery: "4000mAh"
    }
  },
  {
    name: "Nike Air Max 270",
    category: "Footwear",
    price: 150.00,
    stock: 300,
    specs: {
      size: "10",
      color: "Black"
    }
  },
  {
    name: "Apple MacBook Air M2",
    category: "Electronics",
    price: 1199.00,
    stock: 50,
    specs: {
      screenSize: "13.6 inch",
      ram: "8GB",
      storage: "256GB SSD"
    }
  }
]);


db.users.insertMany([
  {
    username: "john_doe",
    email: "john@example.com",
    password_hash: "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3",
    created_at: new Date("2025-08-01T12:00:00Z")
  },
  {
    username: "sri_valli",
    email: "srivalli004@gmail.com",
    password_hash: "d033e22ae348aeb5660fc2140aec35850c4da997",
    created_at: new Date("2025-07-15T10:30:00Z")
  }
]);


db.orders.insertMany([
  {
    user_id: ObjectId("64fe7c111111111111111111"),
    order_date: new Date("2025-07-31T14:45:00Z"),
    products: [
      {
        product_id: ObjectId("64fe7a111111111111111111"),
        name: "Apple MacBook Air M2",
        quantity: 1,
        price: 1199.00
      }
    ],
    total_cost: 1199.00
  },
  {
    user_id: ObjectId("64fe7c222222222222222222"),
    order_date: new Date("2025-08-01T10:00:00Z"),
    products: [
      {
        product_id: ObjectId("64fe7a333333333333333333"),
        name: "Samsung Galaxy S21",
        quantity: 1,
        price: 699.99
      },
      {
        product_id: ObjectId("64fe7a444444444444444444"),
        name: "Nike Air Max 270",
        quantity: 2,
        price: 150.00
      }
    ],
    total_cost: 999.99
  }
]);

db.products.createIndex({ category: 1 });
db.orders.createIndex({ user_id: 1 });
db.orders.createIndex({ order_date: -1 });


db.products.find({ category: "Electronics" });

db.orders.find({ user_id: ObjectId("64fe7c111111111111111111") });

// c. Get recent 5 orders
db.orders.find().sort({ order_date: -1 }).limit(5);