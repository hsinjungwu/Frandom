# Frandom

實作各種隨機變數產生器

## Default

參考 [亂數產生器：Random 與 RNGCryptoServiceProvider](https://blog.miniasp.com/post/2008/05/13/Random-vs-RNGCryptoServiceProvider) 的內容。

## CMWC

參考 [RandomOps](https://github.com/Hvass-Labs/RandomOps) 與 [Multiply-with-carry pseudorandom number generator](https://en.wikipedia.org/wiki/Multiply-with-carry_pseudorandom_number_generator)

## Blum Micali

參考 [The Blum Micali Algorithm and Cryptographically Secure PRNGs (CSPRNGs)](https://www.codeproject.com/Tips/820896/The-Blum-Micali-Algorithm-and-Cryptographically-Se) 與 [Blum–Micali algorithm](https://en.wikipedia.org/wiki/Blum%E2%80%93Micali_algorithm)

+ 質數使用 [Mersenne prime](https://en.wikipedia.org/wiki/Mersenne_prime)
+ Primitive Root 參考這篇 [Least Primitive Root of Mersenne Primes](http://kenta.blogspot.com/2004/08/least-primitive-root-of-mersenne.html) 的 [介紹](https://oeis.org/A096393)
	+ 另外對一般整數計算 ModPow 可參考這篇 [Primitive root of a prime number n modulo n](https://www.geeksforgeeks.org/primitive-root-of-a-prime-number-n-modulo-n/)