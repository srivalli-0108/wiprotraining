const fruits: string[] = ['apple', 'banana', 'cherry'];
for (const fruit of fruits)
{
    console.log(fruit);
}
const scores1 = new Map ([
    ['Alice', 95],
    ['Bob', 87],
    ['Eve', 78],
]);
for (const [name, score1] of scores1)
{
    console.log(`${name}: ${score1}`);
}
const uniqueNumbers = new Set([1, 2, 3, 4, 5]);
for (const number of uniqueNumbers)
{
    console.log(number);
}