const express = require('express');
const fs = require('fs').promises;
const path = require('path');
const { EventEmitter } = require('events');
const router = express.Router();

const dataPath = path.join(__dirname, '../data/books.json');
const emitter = new EventEmitter();

emitter.on('bookAdded', () => console.log('Book Added'));
emitter.on('bookUpdated', () => console.log('Book Updated'));
emitter.on('bookDeleted', () => console.log('Book Deleted'));

async function readBooks() {
  try {
    const data = await fs.readFile(dataPath, 'utf8');
    return JSON.parse(data);
  } catch (error) {
    console.error('Read error:', error);
    return [];
  }
}

async function writeBooks(books) {
  try {
    await fs.writeFile(dataPath, JSON.stringify(books, null, 2));
  } catch (error) {
    console.error('Write error:', error);
  }
}

// GET /books
router.get('/', async (req, res) => {
  const books = await readBooks();
  res.json(books);
});

// GET /books/:id
router.get('/:id', async (req, res) => {
  const books = await readBooks();
  const book = books.find(b => b.id === parseInt(req.params.id));
  book ? res.json(book) : res.status(404).json({ message: 'Book not found' });
});

// POST /books
router.post('/', async (req, res) => {
  const { title, author } = req.body;
  if (!title || !author) return res.status(400).json({ message: 'Title and Author required' });

  const books = await readBooks();
  const newBook = {
    id: books.length ? books[books.length - 1].id + 1 : 1,
    title,
    author
  };

  books.push(newBook);
  await writeBooks(books);
  emitter.emit('bookAdded');
  res.status(201).json(newBook);
});

// PUT /books/:id
router.put('/:id', async (req, res) => {
  const books = await readBooks();
  const index = books.findIndex(b => b.id === parseInt(req.params.id));
  if (index === -1) return res.status(404).json({ message: 'Book not found' });

  const { title, author } = req.body;
  books[index] = { ...books[index], title, author };
  await writeBooks(books);
  emitter.emit('bookUpdated');
  res.json(books[index]);
});

// DELETE /books/:id
router.delete('/:id', async (req, res) => {
  let books = await readBooks();
  const initialLength = books.length;
  books = books.filter(b => b.id !== parseInt(req.params.id));

  if (books.length === initialLength)
    return res.status(404).json({ message: 'Book not found' });

  await writeBooks(books);
  emitter.emit('bookDeleted');
  res.status(204).end();
});

module.exports = router;
