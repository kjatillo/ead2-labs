// This function takes a vector of integers as input and returns a new vector containing only the unique items.
fn unique_items(numbers: Vec<i32>) -> Vec<i32> {
    // Create an empty vector to store unique numbers.
    let mut unique = Vec::new();
    
    // Iterate through each number in the input vector.
    for num in numbers {
        // Check if the number is not already in the unique vector.
        if !unique.contains(&num) {
            // If it's not present, add it to the unique vector.
            unique.push(num);
        }
    }

    // Return the vector containing only unique numbers.
    return unique;
}

fn main() {
    // Define a vector with some duplicate numbers.
    let num_vector = vec![1, 2, 2, 3, 4, 4, 5];
    
    // Call the `unique_items` function to get a vector with only unique numbers.
    let unique_num_vector = unique_items(num_vector);

    // Print the vector of unique numbers to the console.
    println!("Unique items: {:?}", unique_num_vector);
}
