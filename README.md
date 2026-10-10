# PersianInputValidator

[![Build and Test](https://github.com/Shahinhmpgit/PersianInputValidator/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Shahinhmpgit/PersianInputValidator/actions/workflows/dotnet.yml)
[![NuGet](https://img.shields.io/nuget/v/PersianInputValidator.svg)](https://www.nuget.org/packages/PersianInputValidator/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/PersianInputValidator.svg)](https://www.nuget.org/packages/PersianInputValidator/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A lightweight C# library for Persian-language applications. It provides digit normalization, text normalization, and input-format validation for common Iranian data.

کتابخانه‌ای سبک برای برنامه‌های فارسی‌زبان با قابلیت تبدیل ارقام، یکسان‌سازی متن و اعتبارسنجی قالب ورودی‌های رایج در برنامه‌های ایرانی.

## Features

### Digit and text normalization

- Convert Persian digits to English digits.
- Convert Arabic-Indic digits to English digits.
- Convert English digits to Persian digits.
- Convert Arabic-Indic digits to Persian digits.
- Normalize common Arabic Yeh and Kaf characters to Persian equivalents.
- Trim and collapse whitespace in text.
- Detect the digit script used in a string.
- Detect Unicode control characters.

### Input validation

- Check whether a string contains only supported digits.
- Validate minimum and maximum text lengths.
- Check required text fields.
- Validate common Iranian mobile-number formats.
- Validate Iranian national identification code checksums.
- Validate basic email address syntax.
- Check whether text contains letters with configurable whitespace and hyphen support.
- Validate the basic format of Iranian postal codes.
- Validate integer and decimal input containing Persian, Arabic-Indic, or English digits.
- Validate common Iranian landline-number formats.

## Requirements

- The library targets .NET Standard 2.0.
- Tests target .NET 8.0.
- .NET SDK 8.0 or compatible tooling is required to build and test the repository.
- Visual Studio or another compatible C# development environment can be used.

## Installation

Install the package from NuGet:

### Package Manager Console

```powershell
Install-Package PersianInputValidator -Version 0.1.1
```

### .NET CLI

```bash
dotnet add package PersianInputValidator --version 0.1.0
```

### Package Manager UI

1. Open your project in Visual Studio.
2. Right-click the project in Solution Explorer.
3. Select **Manage NuGet Packages**.
4. Search for `PersianInputValidator`.
5. Select version `0.1.0` and install it.

NuGet package: https://www.nuget.org/packages/PersianInputValidator/

## Usage

### Normalize digits

```csharp
using PersianInputValidator;

string english = PersianDigitNormalizer.ToEnglishDigits("شماره ۱۲۳");
// Result: "شماره 123"

string persian = PersianDigitNormalizer.ToPersianDigits("Order 123");
// Result: "Order ۱۲۳"
```

### Normalize Persian characters and whitespace

```csharp
using PersianInputValidator;

string text = PersianCharacterNormalizer.Normalize("علي كتاب");
// Result: "علی کتاب"

string clean = PersianTextNormalizer.NormalizeWhitespace("  سلام    دنیا  ");
// Result: "سلام دنیا"
```

### Validate numeric input

```csharp
using PersianInputValidator;

bool integerIsValid = NumericInputValidator.IsInteger("-۱۲۳");
// Expected: true

bool decimalIsValid = NumericInputValidator.IsDecimal("۱۲۳٫۵");
// Expected: true
```

The decimal validator supports a dot, comma, or Arabic decimal separator. Thousands separators are not supported.

### Validate Iranian mobile numbers

```csharp
using PersianInputValidator;

bool mobileIsValid =
    IranianMobileValidator.IsValid("09123456789");
```

This checks the supported number format; it does not verify whether the number is assigned or active.

### Validate Iranian national identification codes

```csharp
using PersianInputValidator;

bool nationalCodeIsValid =
    IranianNationalCodeValidator.IsValid("0084575948");
```

This checks the code's format and checksum. It does not verify a person's identity or confirm registration in an official database.

### Validate Iranian postal codes

```csharp
using PersianInputValidator;

bool postalCodeIsValid =
    IranianPostalCodeValidator.IsValid("1234567890");
```

This checks the basic ten-digit format only. It does not confirm that the postal code exists.

### Validate landline numbers

```csharp
using PersianInputValidator;

bool landlineIsValid =
    IranianLandlineValidator.IsValid("02112345678");
```

This checks a common number format and does not verify whether the line is assigned or active.

### Validate email syntax

```csharp
using PersianInputValidator;

bool emailIsValid =
    EmailValidator.IsValid("user@example.com");
```

Syntax validation does not guarantee that an address exists or can receive email.

## Development and testing

The repository contains the library source code, unit tests, and a GitHub Actions workflow.

Run the complete test suite from the repository root:

```bash
dotnet test tests/PersianInputValidator.Tests/PersianInputValidator.Tests.csproj
```

Build the library in Release configuration:

```bash
dotnet build src/PersianInputValidator/PersianInputValidator.csproj --configuration Release
```

Create a NuGet package:

```bash
dotnet pack src/PersianInputValidator/PersianInputValidator.csproj --configuration Release
```

Every proposed behavior change should include appropriate automated tests.

## Important limitations

- Format validation does not establish that a phone number, email address, or postal code exists or is active.
- National-code checksum validation does not verify a person's identity against official records.
- Numeric input validation checks the accepted character format; it does not guarantee that a value fits a particular numeric type or business range.
- Whitespace normalization and character normalization perform only the transformations documented by their respective methods.
- This project is an open-source utility library, not a complete application or identity-verification service.

## وضعیت پروژه | Project status

This project is under active development. Features should be considered supported according to their implemented behavior and automated tests. APIs may evolve before a stable release.

این پروژه در حال توسعه است. قابلیت‌ها بر اساس رفتار پیاده‌سازی‌شده و تست‌های خودکار ارزیابی می‌شوند و ممکن است رابط برنامه‌نویسی آن پیش از انتشار نسخه پایدار تغییر کند.

## Contributing

Bug reports, suggestions, and pull requests are welcome.

Please include:

- A clear description of the problem or proposed improvement.
- Reproducible examples when applicable.
- Automated tests for changes in behavior.

Please read [CONTRIBUTING.md](CONTRIBUTING.md) before submitting a pull request.

## Security

If you discover a potential security vulnerability, please follow the instructions in [SECURITY.md](SECURITY.md).

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.
