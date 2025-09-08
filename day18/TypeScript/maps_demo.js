var scores = new Map();
scores.set("Alice", 95);
scores.set("Bob", 82);
scores.set("Charlie", 100);
console.log(scores.get("Alice")); // output: 95
console.log(scores.has("Bob")); // output: true
for (var _i = 0, scores_1 = scores; _i < scores_1.length; _i++) {
    var _a = scores_1[_i], name_1 = _a[0], score = _a[1];
    console.log("".concat(name_1, " scored ").concat(score));
}
scores.delete("Bob");
//Map size
console.log(scores.size); // output: 2
