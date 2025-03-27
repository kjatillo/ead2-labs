// Recursive function to calculate the factorial of a number
// The factorial of n (n!) is the product of all positive integers from 1 to n
fn factorial(n: u32) -> u32 {
    if n <= 1 {
        // Base case: factorial of 0 or 1 is 1
        1
    } else {
        // Recursive case: n! = n * (n-1)!
        n * factorial(n - 1)
    }
}

fn main() {
    // Apply the factorial function to the range 1..9 (1 to 9 inclusive)
    // and print the results in the format "n! = result"
    for i in 1..10 {
        println!("{}! = {}", i, factorial(i));
    }

    // Create a vector (a dynamic array) containing some numbers
    let numbers = vec![3, 4, 5, 6];

    // Create an empty vector to store the factorial results
    let mut factorials = Vec::new();

    // Loop through each number in the `numbers` vector
    for num in &numbers {
        // Calculate the factorial of the current number and add it to the `factorials` vector
        factorials.push(factorial(*num)); // Dereference `num` because it's a reference
    }

    // Print the original numbers in the vector
    println!("Original numbers: {:?}", numbers);

    // Print the calculated factorials corresponding to the original numbers
    println!("Factorials: {:?}", factorials);
}
