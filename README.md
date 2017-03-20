# FlipFlopIterator
an outward-spiral iteration algorithm
____

Preemptive tldr; [here's the code.](https://github.com/adamstevencotner/FlipFlopIterator/blob/master/FlipFlopIterator/FlipFlopIterator.cs)

### Summary
Normal iteration is boring! Why not switch it up? In fact, why not switch it up on each iteration?

This outward-spiral iteration moves through a one-dimentional ordered set from a start-index outward in both directions. Meaning, if we have an array
```
int array[] = { 0, 1, 2, 3, 4 };
```
and a start index of `2`, we would iterate in this order:
```
// [ 2, 3, 1, 4, 0 ]
```

If your start-index doesn't happen to be smack-dab in the middle of an odd-numbered array, no worries. We just finish out the iteration in the logical, outward way. For example:
```
int array[] = { 0, 1, 2, 3, 4, 5, 6, 7 };
```
and a start index of `5`, we would iterate in this order:
```
// [ 5, 6, 4, 7, 3, 2, 1, 0 ]
```
