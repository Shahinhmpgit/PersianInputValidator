# PersianInputValidator

[![Build and Test](https://github.com/Shahinhmpgit/PersianInputValidator/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Shahinhmpgit/PersianInputValidator/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A lightweight C# library for normalizing Persian, Arabic-Indic, and English digits, with a focus on Persian-language applications and Windows Forms.

## Features

- Convert Persian digits to English digits.
- Convert Arabic-Indic digits to English digits.
- Convert English digits to Persian digits.
- Convert Arabic-Indic digits to Persian digits.
- Preserve non-digit characters.
- Handle null and empty string inputs.
- Automated build and unit-test workflow using GitHub Actions.

## Requirements

- .NET SDK 8.0 or compatible tooling for building and testing the repository.
- The library targets .NET Standard 2.0.

## Installation

The library is currently available as source code in this repository. A published NuGet package is not available yet.

To use the code in your own project, include `PersianDigitNormalizer.cs` in a compatible C# project or build the library from the repository.

## Usage

```csharp
using PersianInputValidator;

string english = PersianDigitNormalizer.ToEnglishDigits("شماره ۱۲۳");
// Result: "شماره 123"

string persian = PersianDigitNormalizer.ToPersianDigits("Order 123");
// Result: "Order ۱۲۳"
```

## Development

The repository contains the library source code, unit tests, and a GitHub Actions workflow.

Run the tests locally from the repository root:

```bash
dotnet test tests/PersianInputValidator.Tests/PersianInputValidator.Tests.csproj
```

## Project Status

This project is in early development. Its current focus is digit normalization. Additional validation features may be considered as they are implemented, tested, and documented.

## Contributing

Bug reports, suggestions, and pull requests are welcome. Please describe the issue clearly and include tests for proposed behavior changes.

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.
