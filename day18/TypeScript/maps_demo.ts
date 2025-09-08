let scores: Map<string, number> = new Map();

scores.set("Alice", 95);
scores.set("Bob", 82);
scores.set("Charlie", 100);

console.log(scores.get("Alice")); // output: 95
console.log(scores.has("Bob")); // output: true

for (let [name, score] of scores) {
    console.log(`${name} scored ${score}`);
}

scores.delete("Bob");
//Map size
console.log(scores.size); // output: 2
