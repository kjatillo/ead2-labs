# Setting Up and Running Rust Programs

Follow these steps to download, install, set up, and run Rust programs on your system.

## Table of Contents
1. [Step 1: Download and Install Rust](#step-1-download-and-install-rust)
2. [Step 2: Verify Installation](#step-2-verify-installation)
3. [Step 3: Set Up Your Rust Project](#step-3-set-up-your-rust-project)
4. [Step 4: Write Your Rust Code](#step-4-write-your-rust-code)
5. [Step 5: Build and Run Your Program](#step-5-build-and-run-your-program)
6. [Step 6: Test Your Program](#step-6-test-your-program)

## Step 1: Download and Install Rust
1. Go to `https://www.rust-lang.org/tools/install`.
2. Download the installer for your operating system.
3. Follow the on-screen instructions to complete the installation.
4. After installation, restart your terminal to ensure the `cargo` command is available.

## Step 2: Verify Installation
1. Check if Rust is installed by running:
    ```sh
    rustc --version
    ```
    This should display the installed Rust version.

## Step 3: Set Up Your Rust Project
1. Create a new directory for your project or navigate to an existing one.
2. Use Cargo (Rust's package manager) to create a new project:
    ```sh
    cargo new my_project
    ```
3. Navigate to the project directory:
    ```sh
    cd my_project
    ```

## Step 4: Write Your Rust Code
1. Open the `src/main.rs` file in your favorite text editor or IDE.
2. Modify the file to include your Rust code. For example:
    ```rust
    fn main() {
         println!("Hello, world!");
    }
    ```

## Step 5: Build and Run Your Program
1. Build your Rust program using Cargo:
    ```sh
    cargo build
    ```
2. Run your program:
    ```sh
    cargo run
    ```

## Step 6: Test Your Program
1. Write tests in the `tests` directory or in your source files.
2. Run tests using Cargo:
    ```sh
    cargo test
    ```

Now you're ready to start developing with Rust!
