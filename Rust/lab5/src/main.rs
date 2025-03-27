// Define an enum to represent the days of the week
enum DayOfWeek {
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
}

impl DayOfWeek {
    // Function to check if the day is a weekend
    // Returns true if the day is Saturday or Sunday
    fn is_weekend(&self) -> bool {
        matches!(self, DayOfWeek::Saturday | DayOfWeek::Sunday)
    }

    // Function to check if the day is a weekday
    // Returns true if the day is not a weekend
    fn is_weekday(&self) -> bool {
        !self.is_weekend() // Use the is_weekend function to determine this
    }
}

fn main() {
    // Create a variable to represent a specific day
    let day = DayOfWeek::Friday;

    // Check if the day is a weekday or weekend and print the result
    if day.is_weekday() {
        println!("It's a weekday."); // Print this if it's a weekday
    } else if day.is_weekend() {
        println!("It's a weekend."); // Print this if it's a weekend
    }
}
