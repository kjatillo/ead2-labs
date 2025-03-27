fn fibonacci(n: u32) -> u32 {
    // Recursive function to calculate the nth Fibonacci number
    // Base cases: if n is 0 or 1, return n
    if n <= 1 {
        n
    } else {
        // Recursive case: sum of the two preceding Fibonacci numbers
        fibonacci(n - 1) + fibonacci(n - 2)
    }
}

fn main() {
    // Create a vector (dynamic array) to store the first 10 Fibonacci numbers
    let mut fib_list = Vec::new();

    // Use a loop to calculate and store the first 10 Fibonacci numbers in the vector
    for i in 1..=10 {
        // Call the fibonacci function and add the result to the vector
        fib_list.push(fibonacci(i));
    }

    // Print the list of the first 10 Fibonacci numbers to the console
    println!("First 10 Fibonacci numbers: {:?}", fib_list);
}
