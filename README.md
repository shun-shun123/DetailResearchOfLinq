# Why ImprovedLinq is better 
## FirstOrDefault
The FirstOrDefault function takes an argument of type IEnumerable<TSource>. When iterating through foreach, depending on the runtime type, compile-time optimization and getting the Enumerator may require high performance.
Therefore, implementing FirstOrDefault to receive concrete types such as Arrays, Lists, and Dictionary, we can achieve high performance.