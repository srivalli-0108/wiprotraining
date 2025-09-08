const express = require('express');
const app = express();
const port = 3000;

const bookRoutes = require('./services/bookService');

app.use(express.json());
app.use('/books', bookRoutes);

app.get('/', (req, res) => {
  res.json({ message: 'Welcome to Book Management API' });
});

app.listen(port, () => {
  console.log(`Server running at http://localhost:${port}`);
});
