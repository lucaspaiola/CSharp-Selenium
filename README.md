# CSharp Selenium Project

This project demonstrates automated UI testing using **C#**, **Selenium WebDriver**, and **NUnit**. The tests are written to validate functionalities on the [Practice Automation Testing](https://practice.automationtesting.in/) website.

## Features

- **Automated Tests**: Validates login, registration, and cart functionalities.
- **Page Object Model (POM)**: Implements POM design pattern for test structure and maintainability.
- **Cross-Browser Support**: Compatible with different web browsers through Selenium WebDriver.
- **GitHub Actions CI**: Integrates a pipeline for running tests automatically on every push.

---

## Prerequisites

Ensure you have the following installed:

- **.NET SDK** (version 6.0 or higher)
- **NUnit Framework**
- **Selenium WebDriver**
  
---

## Running Tests Locally

1. Execute the tests using the .NET CLI:
   ```bash
   dotnet test
   ```

---

## GitHub Actions Pipeline

The project includes a preconfigured **GitHub Actions pipeline** (`.github/workflows/ci.yml`) for running tests automatically. To enable the pipeline:

1. Push the project to a GitHub repository.
2. GitHub Actions will trigger on every push or pull request.

To view pipeline results:
- Navigate to the **Actions** tab in your GitHub repository.

---

## Project Structure

- **PageObjects**: Contains classes representing web pages for test modularity.
- **Tests**: NUnit test cases to validate specific functionalities.

---
