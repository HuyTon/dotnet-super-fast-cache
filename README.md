# Super Fast Cache

This repository serves as a test bed for a cache implementation aimed at storing and retrieving 1 million records in memory with exceptional speed.

## Performance Metrics

Upon running the code, you will obtain performance metrics comparing the times between the slow run and the optimized, fast run. The metrics include the time taken to find the first, middle, and last items in the collection of 1,000,000 items. The test runs 100 times to compute an average for each find result.

## Installation and Usage

To install the dependencies, run the following command:

```
dotnet build testcacheclear.csproj
```

To start the server, run the following command:

```
dotnet run
```

```text
Super Slow Cache x1000 slower than it should be :-(

TestCache for Employee Model


Super Slow Cache x1000 slower that it should be :-(

First Item  3.100  (found=True ) | min:       90708 ticks | avg ms per find:      0.00 ms | max:      824375 ticks | #Tests:   3 | Total Time:       1 ms |
Mid Item    3.100  (found=True ) | min:   557270167 ticks | avg ms per find:      6.24 ms | max:   746975292 ticks | #Tests:   3 | Total Time:    1872 ms |
Last Item   3.100  (found=True ) | min:   896578917 ticks | avg ms per find:      9.02 ms | max:   907597292 ticks | #Tests:   3 | Total Time:    2707 ms |


Super Fast Cache

First Item  3.100  (found=True ) | min:       70417 ticks | avg ms per find:      0.00 ms | max:      487208 ticks | #Tests:   3 | Total Time:       0 ms |
Mid Item    3.100  (found=True ) | min:       68459 ticks | avg ms per find:      0.00 ms | max:       73208 ticks | #Tests:   3 | Total Time:       0 ms |
Last Item   3.100  (found=True ) | min:       69166 ticks | avg ms per find:      0.00 ms | max:       71083 ticks | #Tests:   3 | Total Time:       0 ms |


TestCache for Company Model


Super Slow Cache x1000 slower that it should be :-(

First Item  3.100  (found=True ) | min:       65542 ticks | avg ms per find:      0.00 ms | max:      260458 ticks | #Tests:   3 | Total Time:       0 ms |
Mid Item    3.100  (found=True ) | min:  1009005667 ticks | avg ms per find:     10.10 ms | max:  1012611375 ticks | #Tests:   3 | Total Time:    3031 ms |
Last Item   3.100  (found=True ) | min:  2020403125 ticks | avg ms per find:     20.31 ms | max:  2050707375 ticks | #Tests:   3 | Total Time:    6094 ms |


Super Fast Cache

First Item  3.100  (found=True ) | min:       68083 ticks | avg ms per find:      0.00 ms | max:      146125 ticks | #Tests:   3 | Total Time:       0 ms |
Mid Item    3.100  (found=True ) | min:       68958 ticks | avg ms per find:      0.00 ms | max:       80292 ticks | #Tests:   3 | Total Time:       0 ms |
Last Item   3.100  (found=True ) | min:       68166 ticks | avg ms per find:      0.00 ms | max:       69375 ticks | #Tests:   3 | Total Time:       0 ms |


OptimizedTestCache for Company Model


Super Slow Cache x1000 slower that it should be :-(

First Item  Test 1 completed.
First Item  Test 2 completed.
First Item  Test 3 completed.
(found=True ) | min:  1905141250 ticks | avg ms per find:     19.29 ms | max:  1941895250 ticks | #Tests:   3 | Total Time:    5787 ms |
Mid Item    Test 1 completed.
Mid Item    Test 2 completed.
Mid Item    Test 3 completed.
(found=True ) | min:  2840915959 ticks | avg ms per find:     28.84 ms | max:  2944331875 ticks | #Tests:   3 | Total Time:    8652 ms |
Last Item   Test 1 completed.
Last Item   Test 2 completed.
Last Item   Test 3 completed.
(found=True ) | min:  3897001250 ticks | avg ms per find:     39.16 ms | max:  3951877500 ticks | #Tests:   3 | Total Time:   11748 ms |


Super Fast Cache

First Item  Test 1 completed.
First Item  Test 2 completed.
First Item  Test 3 completed.
(found=True ) | min:        2125 ticks | avg ms per find:      0.00 ms | max:        3542 ticks | #Tests:   3 | Total Time:       0 ms |
Mid Item    Test 1 completed.
Mid Item    Test 2 completed.
Mid Item    Test 3 completed.
(found=True ) | min:        2250 ticks | avg ms per find:      0.00 ms | max:        3292 ticks | #Tests:   3 | Total Time:       0 ms |
Last Item   Test 1 completed.
Last Item   Test 2 completed.
Last Item   Test 3 completed.
(found=True ) | min:        2459 ticks | avg ms per find:      0.00 ms | max:        2625 ticks | #Tests:   3 | Total Time:       0 ms |
```
