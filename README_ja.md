# ImprovedLinqがなぜ高パフォーマンスなのか
## FirstOrDefault
FirstOrDefault関数は引数にIEnumerable<TSource>の型で受け取ります。そして受け取ったsourceをforeachでイテレートするわけですが、foreachでイテレートする際に、実行時の型によってコンパイル時の最適化や、Enumeratorの取得に高パフォーマンス化がかかる場合があります。

そのため、配列やList、Dictionaryといった具体的な型で受け取るFirstOrDefaultを実装することで高パフォーマンス化を実現しています。