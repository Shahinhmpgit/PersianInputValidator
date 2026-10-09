
# Changelog

All notable changes to PersianInputValidator will be documented in this file.

The project is currently under active development. This changelog records implemented work; it does not imply that a stable release has been published.

## [Unreleased]

### Added

- Persian, Arabic-Indic, and English digit normalization.
- Arabic-to-Persian normalization for common Yeh and Kaf characters.
- Whitespace normalization.
- Digit-script detection.
- Unicode control-character detection.
- Digit-only input validation.
- Input length validation.
- Required-field validation.
- Iranian mobile-number format validation.
- Iranian national identification code checksum validation.
- Basic email syntax validation.
- Unicode letter validation with configurable whitespace and hyphen support.
- Iranian postal-code format validation.
- Integer and decimal input validation with Persian, Arabic-Indic, and English digits.
- Common Iranian landline-number format validation.
- Automated unit tests and GitHub Actions workflow.
- Bilingual project documentation and contribution guidance.
- Security reporting guidance.

### Documentation

- Added installation and usage instructions.
- Documented development and test commands.
- Described important validation limitations.

### Notes

- No stable release or published NuGet package is announced by this changelog.
- Validation methods do not guarantee that a real-world phone number, email address, postal code, or identity is active, assigned, or genuine.
