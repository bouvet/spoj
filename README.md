# spoj
Solutions for the SPOJ competition

# How to submit a problem to SPOJ:

Every user requires an account at [SPOJ](http://www.spoj.com) which is free. After signing up, one needs to choose a problem and to write a solution. All input is read from *standard input*, all results need to be written to *standard output*.

For Java, these streams are represented by `System.in` and `System.out`. Most programming languages are equivalent constructs. All solutions are represented by a single class in the default package called `Main` with a default entry point as a `public static void main(String[] args)`. The class can use the Java standard library but no external dependencies. It is the easiest (but not the fastest) to read from the stream by using a `Scanner` on `System.in`.

Every problem offers an example file. For testing purposes, it often makes sense to stor the sample input as a file on the local system. Then, `System.in` can be easily replaced by `new FileInputStream("somefile")` while testing. Before submitting a problem, the stream needs to be replaced by `System.in` again.
